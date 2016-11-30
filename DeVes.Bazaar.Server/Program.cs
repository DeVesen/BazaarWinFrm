using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DeVes.Bazaar.Server.Parameter;

namespace DeVes.Bazaar.Server
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

        public static MainForm MainFormHwnd = null;
        public static CfgFile CfgFile = null;

        public static string PcCode = null;
        public static Dictionary<string, string> Activations = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DeVes.Bazaar.Data.GParams.Instance.Initialice(Program.LocalAppDir, Program.LocalAppDataDir);

            Program.CfgFile = new DeVes.Bazaar.Server.Parameter.CfgFile(System.IO.Path.Combine(Program.LocalAppDir, "Params.xml"));

            Program.PcCode = DeVes.Bazaar.Data.Security.GandingSecurity.CreateBaseAccessCode();
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

            Program.Activations = DeVes.Bazaar.Data.Security.GandingSecurity.CheckLizence(Program.CfgFile.getValue_AsString("General", "License", null), Program.PcCode);

            return Program.OptionExist("IsActivated");
        }


        public static void PlayBadSound()
        {
            System.Media.SoundPlayer _sp = new System.Media.SoundPlayer(Properties.Resources.Windows_Battery_Critical);
            _sp.Play();
            _sp.Dispose();
            _sp = null;
        }
        public static void PlayGoodSound()
        {
            System.Media.SoundPlayer _sp = new System.Media.SoundPlayer(Properties.Resources.Windows_Print_complete);
            _sp.Play();
            _sp.Dispose();
            _sp = null;
        }
        public static void PlayConfirmedSound()
        {
            System.Media.SoundPlayer _sp = new System.Media.SoundPlayer(Properties.Resources.Speech_Sleep);
            _sp.Play();
            _sp.Dispose();
            _sp = null;
        }
    }
}
