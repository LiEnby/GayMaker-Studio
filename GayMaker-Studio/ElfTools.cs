

using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace ELF
{
    class Tools
    {
        [DllImport("DotsTheBee.dll", SetLastError = true, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SceVerDown([MarshalAs(UnmanagedType.LPStr)]string ElfPath, UInt32 version);

        public static void MakeFself(string elf, string self)
        {
            Process makefself = new Process();
            makefself.StartInfo.FileName = @"make_fself\\make_fself.exe";
            makefself.StartInfo.Arguments = elf + " " + self;
            makefself.StartInfo.UseShellExecute = false;
            makefself.StartInfo.RedirectStandardOutput = true;
            makefself.StartInfo.RedirectStandardError = true;
            makefself.StartInfo.CreateNoWindow = true;
            makefself.Start();
            makefself.WaitForExit();
            makefself.Dispose();
            File.Delete(elf);
        }
    }
}
