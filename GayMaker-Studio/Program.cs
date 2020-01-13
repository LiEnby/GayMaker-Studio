using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GayMaker_Studio
{
    static class Program
    {
        public static GayMakerStudio GMS;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        { 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GMS = new GayMakerStudio();
            Application.Run(GMS);
        }
    }
}
