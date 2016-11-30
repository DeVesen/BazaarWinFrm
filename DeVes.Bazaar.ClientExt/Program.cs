using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DVes.Barsar.ClientExt.Forms;

namespace DVes.Barsar.ClientExt
{
    static class Program
    {
        public static string LocalAppDir
        {
            get
            {
                System.Reflection.Assembly _assembly = System.Reflection.Assembly.GetExecutingAssembly();
                string baseDir = System.IO.Path.GetDirectoryName(_assembly.ManifestModule.FullyQualifiedName);

                return baseDir;
            }
        }
        public static string LocalAppDataDir
        {
            get
            {
                string _result = System.IO.Path.Combine(LocalAppDir, "Data");
                if (!System.IO.Directory.Exists(_result))
                {
                    System.IO.Directory.CreateDirectory(_result);
                }
                return _result;
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DVes.Basar.Data.GParams.Instance.Initialice(Program.LocalAppDir, Program.LocalAppDataDir);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MaterialInputForm());
        }
    }
}
