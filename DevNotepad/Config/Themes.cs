using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using DevNotepad.Models.Themes;

namespace DevNotepad.Config
{
    public static class Themes
    {
        #region Events

        #region Active Document Changed

        public static event ThemeChangedEvent ThemeChanged;
        public delegate void ThemeChangedEvent(Theme ActiveTheme, EventArgs e);

        #endregion

        #region Display Name Dictionary

        public static Dictionary<string, string> _DisplayNames = new Dictionary<string, string>(){
            {"default", "Default"},
            {"attribute", "Attribute"},
            {"bracematch", "Brace Match"},
            {"bracemismatch", "Brace Mismatch"},
            {"character", "Character String"},
            {"class", "Class Name"},
            {"comment", "Comments"},
            {"boxcomment", "Box Comments"},
            {"doccomment", "Doc Comments"},
            {"commentline", "Line Comments"},
            {"controlchars", "Control Characters"},
            {"error", "Error Text"},
            {"function", "Function Name"},
            {"identifier", "Identifier"},
            {"keyword", "Language Keywords"},
            {"keyword2", "Other Keywords"},
            {"linenumbers", "Line Numbers"},
            {"number", "Numbers"},
            {"operator", "Operators"},
            {"preprocessor", "Preprocessor"},
            {"string", "Strings"},
            {"tag", "Tag"},
            {"unclosedstring", "Unclosed Single Line Strings"},
            {"unknownattribute", "Unknown Attribute"},
            {"unknowntag", "Unknown Tag"},
            {"whitespace", "Whitespace"},
            {"type", "Type"}
        };

        #endregion

        #endregion

        public static List<Theme> PresetList = new List<Theme>();
        private static Theme _CurrentPreset = null;

        public static Theme CurrentPreset
        {
            get
            {
                return _CurrentPreset;
            }
            set
            {
                _CurrentPreset = value;
                OnThemeChanged(_CurrentPreset, null);
            }
        }

        public static void LoadPresets()
        {
            string path = Paths.ThemesPath;
            if (Directory.Exists(path))
            {

                string[] files = Directory.GetFiles(path, "*.xml");

                foreach (string file in files)
                {
                    //                    Highlighter nHighlighter = JsonConvert.DeserializeObject<Highlighter>(File.ReadAllText(file));
                    Theme nPreset = null;
                    XmlSerializer x = new XmlSerializer(typeof(Theme));
                    try
                    {
                        
                        using (FileStream fs = File.OpenRead(file))
                        {
                            try
                            {
                                nPreset = (Theme)x.Deserialize(fs);

                                // Initialize the dictionary. A must for fast lookups.
                                nPreset.InitializeDictionary();
                                PresetList.Add(nPreset);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(file + "\r\n\r\n" + ex.ToString());
                            }
                        }
                        if (nPreset != null)
                        {
                            //File.Delete(file);
                            
                            // Rewrite for adding properties
                            //using (FileStream fs = File.OpenWrite(file))
                            //{
                            //    x.Serialize(fs, nPreset);
                            //}
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                    // Used for updating the presets with additional parameters when needed.
                    //if (nPreset != null)
                    //{
                    //    UpdatePreset(nPreset, file);
                    //}
                }

                CurrentPreset = GetPresetByName("default");

            }
        }

        private static void AddStyle(Theme theme, string key, string displayName)
        {
            //theme.Presets.Add(key, new PresetStyle()
            //{
            //    DisplayName = displayName,
            //    Name = key
            //});
        }

        private static readonly string DefaultStyles = "Margin Fore	marginfore|Default	default|Attribute	attribute|Brace Match	bracematch|Brace Mismatch	bracemismatch|Character Strings	character|Class Name	classname|Comment	comment|Box Comments	commentbox|Doc Comments	commentdoc|Line Comments	commentline|Control Characters	controlchars|Error Text	error|Function Name	function|Identifier	identifier|Language Keywords	keyword|Other Keywords	keyword2|Line Numbers	linenumbers|Numbers	number|Operators	operator|Preprocessor	preprocessor|Strings	string|Tag	tag|Unclosed Single-Line String	unclosedstring|Unknown Attribute	unknownattribute|Unknown Tag	unknowntag|Whitespace	whitepsace";
        /// <summary>
        /// Internally used to update presets by passing some new styling and setting
        /// a display name. Configuring the presets with hardcoded values.
        /// </summary>
        /// <param name="theme"></param>
        /// <param name="filename"></param>
        
        //private static void UpdatePreset(Theme theme, string filename)
        //{
        //    string[] rows = DefaultStyles.Split('|');
        //    foreach(string row in rows){
        //        string[] cols = row.Split('\t');
        //        if (cols.Length == 2)
        //        {
        //            string displayName = cols[0];
        //            string key = cols[1];
        //            try
        //            {
        //                PresetStyle style = theme.Presets.Where(m => m.Key.Equals(key, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault().Value;
        //                if (style != null)
        //                {
        //                    //style.DisplayName = displayName;
        //                }
        //                else
        //                {
        //                    AddStyle(theme, key, displayName);
        //                }
        //            }
        //            catch
        //            {
                        
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show("Missing cols on " + row);
        //        }
        //    }
        //    XmlSerializer serializer = new XmlSerializer(theme.GetType());
        //    if (File.Exists(filename))
        //        File.Delete(filename);
        //    using (FileStream stream = File.OpenWrite(filename))
        //    {
        //        serializer.Serialize(stream, theme);
        //    }
            
        //}

        /// <summary>
        /// Document changed
        /// </summary>
        /// <param name="doc"></param>
        public static void OnThemeChanged(Theme doc, EventArgs e)
        {
            if (ThemeChanged != null)
            {
                ThemeChanged(doc, e);
            }
        }

        public static Theme GetPresetByName(string Name)
        {
            try
            {
                Theme preset = PresetList.Where(m => m.Name.ToLowerInvariant().Equals(Name.ToLowerInvariant())).FirstOrDefault();
                if (preset != null)
                    return preset;
            }
            catch { }
            return null;
        }

        #region Display Name Mapping To From Classname

        public static string DisplayName(string key)
        {
            if (_DisplayNames.ContainsKey(key))
            {
                return _DisplayNames[key];
            }
            return string.Empty;
        }

        public static string ClassName(string displayName)
        {
            if (_DisplayNames.ContainsValue(displayName))
            {
                return _DisplayNames.FirstOrDefault(x => x.Value.Equals(displayName, StringComparison.InvariantCultureIgnoreCase)).Key;
            }
            return null;
        }

        #endregion
    }
}
