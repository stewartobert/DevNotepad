using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevNotepad.Debug;

namespace DevNotepad.Config
{
    /// <summary>
    /// List of Paths used within the DevNotepad application.
    /// </summary>
    public static class Paths
    {

        #region Directory locations

        /// <summary>
        /// Base name used to generate the path name.
        /// </summary>
        private static readonly string _BaseName = "DevNotepad";

        private static string _BasePath = null;
        /// <summary>
        /// Base directory
        /// </summary>
        public static string BasePath
        {
            get
            {
                if (String.IsNullOrEmpty(_BasePath))
                {
                    _BasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), _BaseName);
                }
                return _BasePath;
            }
        }

        private static string _ParsersPath = null;
        /// <summary>
        /// Directory where parser libraries can be found.
        /// </summary>
        public static string ParsersPath
        {
            get
            {
                if (String.IsNullOrEmpty(_ParsersPath))
                {
                    _ParsersPath = Path.Combine(BasePath, "Parsers");
                }
                return _ParsersPath;
            }
        }


        private static string _SyntaxPath = null;
        /// <summary>
        /// Directory where syntax files for defining highlight colors can be found.
        /// </summary>
        public static string SyntaxPath
        {
            get
            {
                if (String.IsNullOrEmpty(_SyntaxPath))
                {
                    _SyntaxPath = Path.Combine(BasePath, "Syntax");
                }
                return _SyntaxPath;
            }
        }


        private static string _PluginsPath = null;
        /// <summary>
        /// Directory where plugins path can be found.
        /// </summary>
        public static string PluginsPath
        {
            get
            {
                if (String.IsNullOrEmpty(_PluginsPath))
                {
                    _PluginsPath = Path.Combine(BasePath, "Plugins");
                }
                return _PluginsPath;
            }
        }

        private static string _SettingsPath = null;
        /// <summary>
        /// Directory where settings should be stored.
        /// </summary>
        public static string SettingsPath
        {
            get
            {
                if (String.IsNullOrEmpty(_SettingsPath))
                {
                    _SettingsPath = Path.Combine(BasePath, "Settings");
                }
                return _SettingsPath;
            }
        }

        private static string _ThemesPath = null;
        /// <summary>
        /// Path where themes are stored.
        /// </summary>
        public static string ThemesPath
        {
            get
            {
                if (String.IsNullOrEmpty(_ThemesPath))
                {
                    _ThemesPath = Path.Combine(BasePath, "Themes_New");
                }
                return _ThemesPath;
            }
            set
            {
                _ThemesPath = value;
            }
        }

        private static string _LogPath = null;
        /// <summary>
        /// Return directory where log files should be stored.
        /// </summary>
        public static string LogPath
        {
            get
            {
                if (String.IsNullOrEmpty(_LogPath))
                {
                    _LogPath = Path.Combine(BasePath, "Logging");
                }
                return _LogPath;
            }
        }


        private static string _LanguagePath = null;
        /// <summary>
        /// Returns the directory where languages can be found.
        /// </summary>
        public static string LanguagePath
        {
            get
            {
                if (String.IsNullOrEmpty(_LanguagePath))
                {
                    _LanguagePath = Path.Combine(_BasePath, "Languages");
                }
                return _LanguagePath;
            }
        }


        #endregion

        #region File Locations

        private static string _MainSettings = null;
        /// <summary>
        /// Location for storing the main application settings.
        /// </summary>
        public static string MainSettings
        {
            get
            {
                if (String.IsNullOrEmpty(_MainSettings))
                {
                    _MainSettings = Path.Combine(SettingsPath, "Settings.xml");
                }
                return _MainSettings;
            }
        }

        private static string _ReadmeFile = null;
        public static string ReadmeFile
        {
            get
            {
                if (String.IsNullOrEmpty(_ReadmeFile))
                {
                    _ReadmeFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Readme.md");
                }
                return _ReadmeFile;
            }
        }

        private static string _DockingPath = null;
        /// <summary>
        /// Location for storing the docking config file
        /// </summary>
        public static string DockingPath
        {
            get
            {
                if (String.IsNullOrEmpty(_DockingPath))
                {
                    _DockingPath = Path.Combine(SettingsPath, "Docking.xml");
                }
                return _DockingPath;
            }
        }


        private static string _TemplatesPath = null;
        /// <summary>
        /// Path to the Templates file containing base templates.
        /// </summary>
        public static string TemplatesPath
        {
            get
            {
                if (String.IsNullOrEmpty(_TemplatesPath))
                {
                    _TemplatesPath = Path.Combine(SettingsPath, "Templates.xml");
                }
                return _TemplatesPath;
            }
        }

        #endregion

        #region Check/Create directories

        /// <summary>
        /// Checks to see if the directory exists. If not passes the
        /// directory to the CreatePath method.
        /// </summary>
        /// <param name="path"></param>
        private static void CheckPath(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    CreatePath(path);
                }
            }
            catch { }
        }

        /// <summary>
        /// Creates the directory passed to it.
        /// </summary>
        /// <param name="path"></param>
        private static void CreatePath(string path)
        {
            try
            {
                Directory.CreateDirectory(path);
            }
            catch { }
        }

        #endregion

        #region Initialize the Paths object.

        /// <summary>
        /// Initialize the Paths object. Make sure all the directories
        /// are created, available and ready to use.
        /// </summary>
        public static void Initialize()
        {
            try
            {
                CheckPath(BasePath);
                CheckPath(ParsersPath);
                CheckPath(SyntaxPath);
                CheckPath(PluginsPath);
                CheckPath(SettingsPath);
                CheckPath(LogPath);
                CheckPath(LanguagePath);
                CheckPath(ThemesPath);
            }
            catch { }
        }

        #endregion

        #region Form Paths

        public static string GetFormPath(string formName)
        {
            return Path.Combine(SettingsPath, String.Format("{0}.xml", formName));
        }

        #endregion
    }
}
