using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GP.UI.Mobile2.AppParameter;

namespace DVes.Basar.Client
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
        public static string LocalAppParamPath
        {
            get
            {
                return System.IO.Path.Combine(LocalAppDir, "Params.cfg");
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GParams.Instance.ServerAdress = "127.0.0.1";
            GParams.Instance.PortAdress = 1353;



            if (System.IO.File.Exists(Program.LocalAppParamPath))
            {
                CfgFile _cfgFile = new CfgFile(Program.LocalAppParamPath);

                if (_cfgFile.Read())
                {
                    if (!string.IsNullOrEmpty(_cfgFile.getValue("Comunication", "Adress", false)))
                    {
                        GParams.Instance.ServerAdress = _cfgFile.getValue("Comunication", "Adress", false);
                    }

                    if (GParams.ToInt32(_cfgFile.getValue("Comunication", "Port", false)).HasValue)
                    {
                        GParams.Instance.PortAdress = GParams.ToInt32(_cfgFile.getValue("Comunication", "Port", false)).Value;
                    }
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
