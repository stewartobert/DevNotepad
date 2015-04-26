using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using DevNotepad.Config;

namespace DevNotepad.Models.Syntax
{
    public class Scheme
    {

        /// <summary>
        /// Name of the syntax
        /// </summary>
        [XmlAttribute("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Extensions which should default to this syntax.
        /// </summary>
        public string[] Extensions { get; set; }

        private bool _Folding = false;
        /// <summary>
        /// Folding is enabled.
        /// </summary>
        public bool Folding
        {
            get
            {
                return _Folding;
            }
            set
            {
                _Folding = value;
            }
        }

        private bool _FoldComments = false;
        /// <summary>
        /// Comment blocks are folded.
        /// </summary>
        public bool FoldComments
        {
            get
            {
                return _FoldComments;
            }
            set
            {
                _FoldComments = value;
            }
        }

        private bool _FoldCompact = false;
        /// <summary>
        /// Compact folding is enabled.
        /// </summary>
        public bool FoldCompact
        {
            get
            {
                return _FoldCompact;
            }
            set
            {
                _FoldCompact = value;
            }
        }

        private bool _FoldPreprocessors = false;
        /// <summary>
        /// Preprocessors are foldable.
        /// </summary>
        public bool FoldPreprocessors
        {
            get
            {
                return _FoldPreprocessors;
            }
            set
            {
                _FoldPreprocessors = value;
            }
        }

        private bool _FoldElse = false;
        /// <summary>
        /// Fold at else tags
        /// </summary>
        public bool FoldElse
        {
            get
            {
                return _FoldElse;
            }
            set
            {
                _FoldElse = value;
            }
        }

        /// <summary>
        /// Lexer name correlating to a scintilla lexer name.
        /// </summary>
        [XmlAttribute("Lexer")]
        public string Lexer { get; set; }

        /// <summary>
        /// Auto indenting enabled types are: smart, cpp, xml
        /// <strong>[NOTE]</strong> XML type also indents CPP type automatically on PHP and JavaScript
        /// </summary>
        [XmlAttribute("IndentType")]
        public string IndentType { get; set; }

        private bool _AutoCloseBraces = false;
        /// <summary>
        /// Braces []{}() are auto closed.
        /// </summary>
        public bool AutoCloseBraces
        {
            get
            {
                return _AutoCloseBraces;
            }
            set
            {
                _AutoCloseBraces = value;
            }
        }

        private bool _AutoCloseTags = false;
        /// <summary>
        /// XML/HTML tags are auto closed
        /// </summary>
        public bool AutoCloseTags
        {
            get
            {
                return _AutoCloseTags;
            }
            set
            {
                _AutoCloseTags = value;
            }
        }

        private bool _AutoCloseStrings = false;
        /// <summary>
        /// Strings (",') are auto closed.
        /// </summary>
        public bool AutoCloseStrings
        {
            get
            {
                return _AutoCloseStrings;
            }
            set
            {
                _AutoCloseStrings = value;
            }
        }

        /// <summary>
        /// List of keyword sets.
        /// </summary>
        public List<Keyword> Keywords { get; set; }

        /// <summary>
        /// List of styles
        /// </summary>
        public List<Style> Styles { get; set; }

        public List<AutoComplete> AutoCompletes { get; set; }

        [XmlIgnore]
        public Dictionary<char, AutoComplete> _AutoCompleteDict;

        public Scheme()
        {
            Keywords = new List<Keyword>();
            Styles = new List<Style>();
        }

        /// <summary>
        /// Save this object to the specified file.
        /// </summary>
        public void Save()
        {
            string path = Path.Combine(Paths.SyntaxPath, String.Format("{0}.xml", Name.Replace("\\", "_")));

            if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);
                }
                catch { }
            }

            XmlSerializer serializer = new XmlSerializer(this.GetType());

            using (FileStream stream = File.OpenWrite(path))
            {
                serializer.Serialize(stream, this);
            }
        }

        /// <summary>
        /// Converts the list of auto completes to a dictionary for quick lookups. Uses a list
        /// for logical XML storage but list lookups are far slower than dictionary lookups.
        /// </summary>
        public void InitAutoComplete()
        {
            _AutoCompleteDict = AutoCompletes.ToDictionary(l => l.AutoCompleteChar[0]);
        }


        public AutoComplete GetMatches(char ch, int style)
        {
            if (_AutoCompleteDict.ContainsKey(ch))
            {
                AutoComplete ac = _AutoCompleteDict[ch];
                if (ac.StyleMin <= style && ac.StyleMax >= style)
                {
                    return _AutoCompleteDict[ch];
                }
            }
            return null;
        }
    }
}
