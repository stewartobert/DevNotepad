using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DevNotepad.Models.Languages
{
    public class LanguageItem
    {
        /// <summary>
        /// Name of the object
        /// </summary>
        [XmlAttribute("Text")]
        public string Name { get; set; }

        /// <summary>
        /// Text of the object
        /// </summary>
        [XmlAttribute("Text")]
        public string Text { get; set; }

        public LanguageItem()
        {
            Name = String.Empty;
            Text = String.Empty;
        }
    }
}
