using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DevNotepad.Models.Syntax
{
    public class AutoComplete
    {
        /// <summary>
        /// Character to look for when matching a regex
        /// </summary>
        [XmlAttribute("AutoCompleteChar")]
        public string AutoCompleteChar { get; set; }

        [XmlAttribute("MatchString")]
        public string MatchString { get; set; }

        /// <summary>
        /// Regular expression to pull a list from the document
        /// </summary>        
        public string MethodRegexMatch { get; set; }

        /// <summary>
        /// Defines a regex to pull the appropriate part of the match
        /// out for displaying in the autocomplete and inserting
        /// </summary>
        public string MethodRegexInsertMatch { get; set; }


        /// <summary>
        /// Regular expression to pull a list from the document
        /// </summary>        
        public string PropertyRegexMatch { get; set; }

        /// <summary>
        /// Defines a regex to pull the appropriate part of the match
        /// out for displaying in the autocomplete and inserting
        /// </summary>
        public string PropertyRegexInsertMatch { get; set; }

        private int _StyleMin = -1;
        /// <summary>
        /// Minimum style key number
        /// </summary>
        [XmlAttribute("StyleMin")]
        public int StyleMin
        {
            get
            {
                return _StyleMin;
            }
            set
            {
                _StyleMin = value;
            }
        }


        private int _StyleMax = -1;
        /// <summary>
        /// Maximum style key number
        /// </summary>
        [XmlAttribute("StyleMax")]
        public int StyleMax
        {
            get
            {
                return _StyleMax;
            }
            set
            {
                _StyleMax = value;
            }
        }


        /// <summary>
        /// Regex to get a list of methods within the document. Automatically generates the regular
        /// expression on the first use and stores it within as a compiled regex for performance.
        /// </summary>
        private Regex _MethodRegEx = null;
        public Regex MethodRegEx
        {
            get
            {
                if (_MethodRegEx == null)
                {
                    _MethodRegEx = new Regex(MethodRegexMatch, RegexOptions.Compiled);
                }
                return _MethodRegEx;
            }
        }

        private Regex _MethodRegExInsert = null;
        public Regex MethodRegExInsert
        {
            get
            {
                if (_MethodRegExInsert == null)
                {
                    _MethodRegExInsert = new Regex(MethodRegexInsertMatch, RegexOptions.Compiled);
                }
                return _MethodRegExInsert;
            }
        }


        private Regex _PropertyRegEx = null;
        public Regex PropertyRegEx
        {
            get
            {
                if (_PropertyRegEx == null)
                {
                    _PropertyRegEx = new Regex(PropertyRegexMatch, RegexOptions.Compiled);
                }
                return _PropertyRegEx;
            }
        }

        private Regex _PropertyRegExInsert = null;
        public Regex PropertyRegExInsert
        {
            get
            {
                if (_MethodRegExInsert == null)
                {
                    _PropertyRegExInsert = new Regex(PropertyRegexInsertMatch, RegexOptions.Compiled);
                }
                return _PropertyRegExInsert;
            }
        }

        
        
    }
}
