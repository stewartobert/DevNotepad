using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DevNotepad.Config;
using DevNotepad.Library.Objects;
using DevNotepad.Models.Syntax;

namespace DevNotepad.Models.Themes
{
    public class UITheme
    {
        public string TabBackGradientStart { get; set; }
        public string TabBackGradientEnd { get; set; }
        public string ActiveTabStart { get; set; }
        public string ActiveTabEnd { get; set; }
        public string TabStart { get; set; }
        public string TabEnd { get; set; }
        public string TabFore { get; set; }
        public string ActiveTabFore { get; set; }
        public string TitleStart { get; set; }
        public string TitleEnd { get; set; }
        public string MainBG { get; set; }
        public string WindowBG { get; set; }
        public string WindowFore { get; set; }
        public string WindowSelect { get; set; }
        public string WindowSelectFore { get; set; }
    }
    public class Theme
    {

        [XmlAttribute("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Dictionary of Preset styles. Use a dictionary to facilitate faster lookups
        /// by name for rendering styles.
        /// </summary>
        //public SerializableDictionary<string, PresetStyle> Presets { get; set; }
        public List<PresetStyle> Presets { get; set; }

        [XmlIgnore]
        private Dictionary<string, PresetStyle> _PresetsDict { get; set; }

        private string _FoldBackground = null;
        /// <summary>
        /// Background color of fold margin
        /// </summary>
        [XmlAttribute("FoldBackground")]
        public string FoldBackground
        {
            get
            {
                if (_FoldBackground == null)
                {
                    try
                    {
                        // Try to set to the default background color if nothing is defined.
                        _FoldBackground = DefaultPreset.Back;// this.Presets.Where(m => m.Key.Equals("default")).FirstOrDefault().Value.Back;
                    }
                    catch { }
                }
                return _FoldBackground;
            } set {
                _FoldBackground = value;
            }
        }

        public UITheme UITheme { get; set; }

        /// <summary>
        /// Background color of number margin
        /// </summary>
        [XmlAttribute("NumberBackground")]
        public string NumberBackground { get; set; }

        /// <summary>
        /// Foreground color of number margin.
        /// </summary>
        [XmlAttribute("NumberForeground")]
        public string NumberForeground { get; set; }

        /// <summary>
        /// Cursor color
        /// </summary>
        [XmlAttribute("CursorColor")]
        public string CursorColor { get; set; }

        /// <summary>
        /// Used internally for tracking a filename
        /// </summary>
        [XmlIgnore]
        public string Filename { get; set; }

        public Theme()
        {
            //Presets = new SerializableDictionary<string, PresetStyle>();
            Presets = new List<PresetStyle>();
            UITheme = new UITheme()
            {
                ActiveTabEnd = "",
                ActiveTabFore = "",
                ActiveTabStart = "",
                TabBackGradientEnd = "",
                TabBackGradientStart = "",
                TabEnd = "",
                TabFore = "",
                TabStart = "",
                TitleStart = "",
                TitleEnd = ""
            };
        }

        private PresetStyle _DefaultPreset = null;
        public PresetStyle DefaultPreset
        {
            get
            {
                if (_DefaultPreset == null)
                {
                    if (_PresetsDict.ContainsKey("default"))
                    {
                        _DefaultPreset = _PresetsDict["default"];
                    }
                    
                }
                return _DefaultPreset;
            }
        }

        /// <summary>
        /// Retreives a style by the theme key.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Style GetStyle(string key)
        {
            //foreach (PresetStyle preset in Presets)
            //{
            //    if (preset.Name.Equals(key, StringComparison.InvariantCultureIgnoreCase))
            //    {
            //        return new Style()
            //        {
            //            Back = preset.Back,
            //            Fore = preset.Fore,
            //            Italic = preset.Italic,
            //            Underline = preset.Underline,
            //            Bold = preset.Bold,
            //            EOLFilled = preset.EOLFilled,
            //            Font = preset.Font,
            //            FontSize = preset.FontSize
            //        };
            //    }
            //}
            if (_PresetsDict.ContainsKey(key))
            {
                return new Style()
                {
                    Back = _PresetsDict[key].Back,
                    Fore = _PresetsDict[key].Fore,
                    Italic = _PresetsDict[key].Italic,
                    Underline = _PresetsDict[key].Underline,
                    Bold = _PresetsDict[key].Bold,
                    EOLFilled = _PresetsDict[key].EOLFilled,
                    Font = _PresetsDict[key].Font,
                    FontSize = _PresetsDict[key].FontSize
                };
            }
            return null;
        }

        public PresetStyle GetPresetStyle(string name)
        {
            string key = DevNotepad.Config.Themes.ClassName(name);
            if (_PresetsDict.ContainsKey(key))
            {
                return _PresetsDict[key];
            }
            PresetStyle style = new PresetStyle()
            {
                Name = key
            };
            _PresetsDict.Add(key, style);
            Presets.Add(style);
            return style;
        }

        

        public void InitializeDictionary()
        {
            _PresetsDict = Presets.ToDictionary(l => l.Name);
        }

        /// <summary>
        /// Save this object to a file.
        /// </summary>
        public void Save()
        {
            string path = Path.Combine(Paths.ThemesPath, String.Format("{0}.xml", Name.Replace("\\", "_")));

            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch { }
            }

            using (FileStream stream = File.OpenWrite(path))
            {
                XmlSerializer serializer = new XmlSerializer(this.GetType());
                serializer.Serialize(stream, this);
            }
        }

    }
}
