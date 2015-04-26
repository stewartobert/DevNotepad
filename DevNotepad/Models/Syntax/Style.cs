using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DevNotepad.Config;

namespace DevNotepad.Models.Syntax
{
    public class Style
    {
        /// <summary>
        /// Name of the style attribute
        /// </summary>
        [XmlAttribute("Name")]        
        public string Name { get; set; }

        /// <summary>
        /// Key - Corresponds to the scintilla style index.
        /// </summary>
        [XmlAttribute("Key")]
        public int Key { get; set; }

        /// <summary>
        /// Template for defining style by a base set of styles.
        /// </summary>
        [XmlAttribute("Template")]
        public string Template { get; set; }

        private bool _UseTemplate = true;
        /// <summary>
        /// Use the template if set.
        /// </summary>
        [XmlAttribute("UseTemplate")]
        public bool UseTemplate
        {
            get
            {
                return _UseTemplate;
            }
            set
            {
                _UseTemplate = value;
            }
        }

        /// <summary>
        /// Foreground color
        /// </summary>
        [XmlAttribute("Fore")]
        public string Fore { get; set; }


        /// <summary>
        /// Background color
        /// </summary>
        [XmlAttribute("Back")]
        public string Back { get; set; }

        #region Bold/Italic/Underline/EOLFilled

        /// <summary>
        /// Bold
        /// </summary>
        [XmlAttribute("Bold")]
        public bool Bold { get; set; }

        /// <summary>
        /// Italic
        /// </summary>
        [XmlAttribute("Italic")]
        public bool Italic { get; set; }

        /// <summary>
        /// Underline
        /// </summary>
        [XmlAttribute("Underline")]
        public bool Underline { get; set; }

        /// <summary>
        /// If line is filled to EOL
        /// </summary>
        [XmlAttribute("EOLFilled")]
        public bool EOLFilled { get; set; }

        #endregion

        [XmlAttribute("FontSize")]
        public int FontSize { get; set; }

        [XmlAttribute("Font")]
        public string Font { get; set; }
        
    }
}
