using HtmlAgilityPack;
using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMTools
{
    class CDNUrls
    {
        //GMS14
        public const String GMS14 = "http://store.yoyogames.com/downloads/gm-studio/update-studio.rss";
        public const String GMS14EA = "http://store.yoyogames.com/downloads/gm-studio-ea/update-studio-ea.rss";

        //GMS2
        public const String GMS2 = "http://gms.yoyogames.com/Zeus-Runtime.rss";
        public const String GMS2Beta = "http://gms.yoyogames.com/Zeus-Runtime-Beta.rss";


        public static String FromIndex(int cdnIndex)
        {
            switch (cdnIndex)
            {
                case 1:
                    return CDNUrls.GMS14;
                case 2:
                    return CDNUrls.GMS14EA;
                case 3:
                    return CDNUrls.GMS2;
                case 4:
                    return CDNUrls.GMS2Beta;
            }
            return "NF";
        }

    }

    class CDN
    {
        private static string xmlData = "";

        private static string bypassAuthentication(string url)
        {
            if (url.StartsWith("https://updater.yoyogames.com") && !url.Contains("original"))
            {
                return "http://updatecdn.yoyogames.com/" + Path.GetFileName(url);
            }
            else
            {
                return url;
            }
        }

        private static string getOriginalUrl(string version)
        {
            if (version.StartsWith("1."))
            {
                return "https://updater.yoyogames.com/api/download/original?filename=Original-" + version + ".zip";
            }
            else if(version.StartsWith("2."))
            {
                var doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(xmlData);
                var versions = doc.DocumentNode.SelectNodes("/rss/channel/item/enclosure");
                foreach (HtmlNode ver in versions)
                {
                    string verName = ver.GetAttributeValue("sparkle:version", "0.0.0.0");
                    if (verName == version)
                    {
                        return ver.GetAttributeValue("url", "http://example.com/").ToString();
                    }
                }
            }
            return "NF"; 
        }





        public static void UseCDN(String CDN)
        {
            try
            {
                WebClient wc = new WebClient();
                wc.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                xmlData = wc.DownloadString(CDN);
            }
            catch (Exception)
            {
                MessageBox.Show("Could not connect to: " + CDN, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public static String GetModuleForVersion(String Version, String Module)
        {

            Module = Module.ToLower();

            if (Module == "original")
                return getOriginalUrl(Version);

            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(xmlData);
            var versions = doc.DocumentNode.SelectNodes("/rss/channel/item/enclosure");


            foreach (HtmlNode version in versions)
            {
                string verName = version.GetAttributeValue("sparkle:version", "0.0.0.0");
                if (verName == Version)
                {
                    var modules = version.Elements("module");
                    foreach (var module in modules)
                    {
                        string moduleName = module.GetAttributeValue("name", "Original").ToLower();
                        string moduleUrl = module.GetAttributeValue("url", "http://127.0.0.1");
                        if (moduleName == Module)
                        {
                            return bypassAuthentication(moduleUrl);
                        }
                    }
                }

            }



            return "NF"; // Not Found
        }


        public static String[] GetVersions(String Filter = "")
        {
            var doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(xmlData);
            var versions = doc.DocumentNode.SelectNodes("/rss/channel/item/enclosure");

            List<string> verList = new List<string>();

            foreach (HtmlNode version in versions)
            {
                string versionName = version.GetAttributeValue("sparkle:version", "0.0.0.0");

                if (Filter == "")
                {
                    verList.Add(versionName);
                }
                else
                {
                    if(GetModuleForVersion(versionName,Filter) != "NF")
                    {
                        verList.Add(versionName);
                    }
                }
            }

            return verList.ToArray();

        }

    
        public static String GetPassword(String ZipName)
        {
            if (ZipName.ToLower().StartsWith("original") || ZipName.ToLower().StartsWith("gmstudio"))
            {
                return "12#_p@o3w$ir_ADD-_$#";
            }
            MD5Digest md5Digest = new MD5Digest();
            byte[] array = new byte[16];
            byte[] bytes = Encoding.UTF8.GetBytes("MRJA" + Path.GetFileName(ZipName) + "PHMD");
            md5Digest.Reset();
            md5Digest.BlockUpdate(bytes, 0, bytes.Length);
            md5Digest.Finish();
            md5Digest.DoFinal(array, 0);
            string password = Convert.ToBase64String(array);
            return password;
        }

    }
}
