using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DeVes.Bazaar.Server.Parameter;

namespace DeVes.Bazaar.Server
{
    internal static class Program
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
        public static string LocalAppDataDir
        {
            get
            {
                var _result = System.IO.Path.Combine(LocalAppDir, "Data");
                if (!System.IO.Directory.Exists(_result))
                {
                    System.IO.Directory.CreateDirectory(_result);
                }
                return _result;
            }
        }

        public static MainForm MainFormHwnd;
        public static CfgFile CfgFile;

        public static string PcCode;
        public static Dictionary<string, string> Activations;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Data.GParams.Instance.Initialice(Program.LocalAppDir, Program.LocalAppDataDir);

            Program.CfgFile = new CfgFile(System.IO.Path.Combine(Program.LocalAppDir, "Params.xml"));

            Program.PcCode = Data.Security.GandingSecurity.CreateBaseAccessCode();
            Program.ActivateLizence();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Program.MainFormHwnd = new MainForm();
            Application.Run(Program.MainFormHwnd);
        }

        public static bool OptionExist(string key)
        {
            return Program.Activations.ContainsKey(key);
        }
        public static bool ActivateLizence()
        {
            Program.CfgFile.Read();

            Program.Activations = Data.Security.GandingSecurity.CheckLizence(Program.CfgFile.getValue_AsString("General", "License", null), Program.PcCode);

            return Program.OptionExist("IsActivated");
        }


        public static void PlayBadSound()
        {
            var _sp = new System.Media.SoundPlayer(Properties.Resources.Windows_Battery_Critical);
            _sp.Play();
            _sp.Dispose();
        }
        public static void PlayGoodSound()
        {
            var _sp = new System.Media.SoundPlayer(Properties.Resources.Windows_Print_complete);
            _sp.Play();
            _sp.Dispose();
        }
        public static void PlayConfirmedSound()
        {
            var _sp = new System.Media.SoundPlayer(Properties.Resources.Speech_Sleep);
            _sp.Play();
            _sp.Dispose();
        }
    }
}
