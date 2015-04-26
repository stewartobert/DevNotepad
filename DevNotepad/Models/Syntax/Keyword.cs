using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DevNotepad.Models.Syntax
{
    public class Keyword
    {

        /// <summary>
        /// The name of the keyword set.
        /// </summary>
        [XmlAttribute("Name")]
        public string Name { get; set; }

        /// <summary>
        /// The key associated with Scintilla for the lexer.
        /// </summary>
        [XmlAttribute("Key")]
        public int Key { get; set; }

        /// <summary>
        /// The list of keywords.
        /// </summary>        
        public string Keywords { get; set; }

    }
}
