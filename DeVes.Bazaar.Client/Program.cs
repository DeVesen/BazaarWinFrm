using System;
using System.Windows.Forms;
using GP.UI.Mobile2.AppParameter;

namespace DeVes.Bazaar.Client
{
    static class Program
    {
        public static string LocalAppDir
        {
            get
            {
                var _assembly = System.Reflection.Assembly.GetExecutingAssembly();
                var _baseDir = System.IO.Path.GetDirectoryName(_assembly.ManifestModule.FullyQualifiedName);

                return _baseDir;
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
                var _cfgFile = new CfgFile(Program.LocalAppParamPath);

                if (_cfgFile.Read())
                {
                    if (!string.IsNullOrEmpty(_cfgFile.GetValue("Comunication", "Adress", false)))
                    {
                        GParams.Instance.ServerAdress = _cfgFile.GetValue("Comunication", "Adress", false);
                    }

                    if (GParams.ToInt32(_cfgFile.GetValue("Comunication", "Port", false)).HasValue)
                    {
                        GParams.Instance.PortAdress = GParams.ToInt32(_cfgFile.GetValue("Comunication", "Port", false)) ?? 0;
                    }
                }
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
