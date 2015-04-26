using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DevNotepad.Models.Themes
{
    public class PresetStyle
    {
        /// <summary>
        /// Class name of preset
        /// </summary>
        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlIgnore]
        public string DisplayName
        {
            get
            {
                return DevNotepad.Config.Themes.DisplayName(Name);
            }
        }

        /// <summary>
        /// Preset foreground color
        /// </summary>
        [XmlAttribute("Fore")]
        public string Fore { get; set; }

        /// <summary>
        /// Preset background color
        /// </summary>
        [XmlAttribute("Back")]
        public string Back { get; set; }

        /// <summary>
        /// Preset bold
        /// </summary>
        [XmlAttribute("Bold")]
        public bool Bold { get; set; }

        /// <summary>
        /// Preset italic
        /// </summary>
        [XmlAttribute("Italic")]
        public bool Italic { get; set; }

        /// <summary>
        /// Preset underline
        /// </summary>
        [XmlAttribute("Underline")]
        public bool Underline { get; set; }

        /// <summary>
        /// Preset EOL Filled
        /// </summary>
        [XmlAttribute("EOLFilled")]
        public bool EOLFilled { get; set; }

        private string _Font = "Courier New";
        /// <summary>
        /// Preset font.
        /// </summary>
        [XmlAttribute("Font")]
        public string Font
        {
            get
            {
                return _Font;
            }
            set
            {
                _Font = value;
            }
        }

        private int _FontSize = 10;
        [XmlAttribute("FontSize")]
        public int FontSize
        {
            get
            {
                return _FontSize;
            }
            set
            {
                _FontSize = value;
            }
        }

        /// <summary>
        /// For providing feedback for a listview when added.
        /// </summary>
        public override string ToString()
        {
            return DisplayName;
        }
    }
}
