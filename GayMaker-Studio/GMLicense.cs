/*
 * In GMS2 they made the GMAssetCompiler verify your license file
 * It uses RSA to do it
 * ... and then they added the option to specify your own keys
 * good fucking job
 */

using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace GMLicense
{
    class Keys
    {
        public const String Modulus = "AEFD4A9B137D5EC3D80B11094948770D342E87CBF81E418A54FB61BBCDB8D40F241E242822C50327E20003EE57CCA877BF35A2A55A0EB06537F369B722C9DAAB943F33593CC458A7055C0D80CAE9112FD0F4BBC53AD1FEE67C83DDED354216F30EA7126200DE83FAEB7A9880647BFE16B9A0406C7B90D20315F011CCBB85070B";
        public const String PublicExponent = "03";
        public const String PrivateExponent = "74A8DC6762539482900760B0DB85A4B3781F0532A5698106E3524127DE7B380A1814181AC1D8ACC5415557F43A88704FD4CE6C6E3C09CAEE254CF124C1DBE71BF2B1BD2C550A95AEC64E1859444BD879815A820CD22A66E50C6B0658C475FEB83DB423101295BE269315353DFD2B5515A827C4C43C7FF28EDB13ECDA76EF125B";
        public const String Prime1 = "E1E58992501733C45719035DBC615326809E41B49D46A838A1EAAD0807B8866D4206DAEB7DE63BE374D73F9A560393BF9B1884B8CDFEDE9D6BCD0B245CDCA677";
        public const String Prime2 = "C64F0E046D1D445C84CDE59D2815F9530E4EB6FD624BBC5647F8A76006D89271701202DE6717AADD9A03890912B76AB6A24C148D52D2078F61852360AC41C50D";
        public const String Exponent1 = "969906618ABA2282E4BB5793D2EB8CC455BED67868D9C57B169C735AAFD0599E2C0491F253EED297A33A2A66E402627FBCBB0325DEA9E9BE47DE076D933DC44F";
        public const String Exponent2 = "8434B402F368D83DADDE9913700EA6375EDF24A8EC327D8EDAA5C4EAAF3B0C4BA00C01E99A0FC73E66AD06060C7A47246C32B85E3736AFB4EBAE1795C82BD8B3";
        public const String Coefficent = "2659d9ec51d4886df62574301fbce9b18d8479b36f33e8961ba6179395bb73dcf019c641c4efb4d88f10fdf2351117744fe65a1a9b7a45e63dfc9ce135bec994";

        public static RsaKeyParameters GetPublicKey()
        {
            return new RsaKeyParameters(false, new BigInteger(Modulus, 16), new BigInteger(PublicExponent, 16));
        }

        public static RsaPrivateCrtKeyParameters GetPrivateKey()
        {
            return new RsaPrivateCrtKeyParameters(new BigInteger(Modulus, 16), new BigInteger(PublicExponent, 16), new BigInteger(PrivateExponent, 16), new BigInteger(Prime1, 16), new BigInteger(Prime2, 16), new BigInteger(Exponent1, 16), new BigInteger(Exponent2, 16), new BigInteger(Coefficent, 16));
        }
    }

    class Crypto
    {
        public static String SignData(RsaPrivateCrtKeyParameters PrivateKey, String ToBeSigned)
        {
            byte[] Data = Encoding.UTF8.GetBytes(ToBeSigned);
            byte[] sha1Hash = SHA1.Create().ComputeHash(Data);

            Pkcs1Encoding pkcs1Encoding = new Pkcs1Encoding(new RsaEngine());
            pkcs1Encoding.Init(true, PrivateKey);
            int inputBlockSize = pkcs1Encoding.GetInputBlockSize();
           
            byte[] EncryptedData  = pkcs1Encoding.ProcessBlock(sha1Hash, 0, sha1Hash.Length);

            var signedString = Convert.ToBase64String(EncryptedData);
            return signedString;
        }
    }

    class LicenseFormat
    {
        private static Dictionary<string, string> Parse_Plist(string string_36)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (StringReader stringReader = new StringReader(string_36))
            {
                string text;
                while ((text = stringReader.ReadLine()) != null)
                {
                    if (!text.Contains("DOCTYPE") || !text.Contains("DTD"))
                    {
                        stringBuilder.Append(text);
                    }
                }
            }
            string s = stringBuilder.ToString();
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.IgnoreComments = true;
            xmlReaderSettings.ProhibitDtd = true;
            using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(s)))
            {
                using (XmlReader xmlReader = XmlReader.Create(memoryStream, xmlReaderSettings))
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.XmlResolver = null;
                    xmlDocument.Load(xmlReader);
                    XmlNode xmlNode = xmlDocument.SelectSingleNode("plist/dict");
                    for (int i = 0; i < xmlNode.ChildNodes.Count; i++)
                    {
                        if (xmlNode.ChildNodes[i].Name == "key")
                        {
                            dictionary.Add(xmlNode.ChildNodes[i].InnerText, xmlNode.ChildNodes[i + 1].InnerText);
                            i++;
                        }
                    }
                }
            }
            return dictionary;
        }

        private static string createLicenseString(string plist)
        {
            Dictionary<string, string> PlistDict = Parse_Plist(plist);
            List<string> PlistEntryList = PlistDict.Keys.ToList<string>();
            PlistEntryList.Sort();
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string PlistEntry in PlistEntryList)
            {
                string value = PlistDict[PlistEntry];
                if (string.Compare(PlistEntry, "Signature", true) != 0)
                {
                    stringBuilder.Append(value);
                }
            }
            return stringBuilder.ToString();
        }

        public static String CreateLicense(String AllowedPlatforms, RsaPrivateCrtKeyParameters PrivateKey)
        {
            String PlistFile = new XElement("plist",
                            new XElement("dict",
                            new XElement("key", "Signature"),
                            new XElement("data", "---SIGNATURE GOES HERE---"),
                            new XElement("key", "public_key"), //Thanks yoyo 4 backdoor lol
                            new XElement("string", Keys.Modulus),
                            new XElement("key", "components"),
                            new XElement("string", AllowedPlatforms),
                            new XElement("key", "expiry_date"),
                            new XElement("string", DateTime.UtcNow.AddDays(3).ToString("yyyy-mm-dd HH:mm:ss UTC")),
                            new XElement("key", "id"),
                            new XElement("string", "1337"),
                            new XElement("key", "email"),
                            new XElement("string", "girls@dying.moe"))).ToString();
            
            //Sign license with private key
            string licenseString = createLicenseString(PlistFile);
            string signature = Crypto.SignData(PrivateKey, licenseString);
            return PlistFile.Replace("---SIGNATURE GOES HERE---",signature);
        }



    }
}


