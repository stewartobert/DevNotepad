using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using DevNotepad.Debug;
using DevNotepad.Models.Languages;

namespace DevNotepad.Models.Languages
{
    public class LanguageItem
    {
        public string Text { get; set; }
        public string Tip { get; set; }

        public LanguageItem(string text, string tip){
            Text = text;
            Tip = tip;
        }
    }
    public class Language
    {
        /// <summary>
        /// Name of the language
        /// </summary>
        public Dictionary<string, LanguageItem> LanguageKeys { get; set; }

        public Language()
        {
            LanguageKeys = new Dictionary<string, LanguageItem>(StringComparer.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Loads a file into Dictionary
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool LoadFile(string fileName)
        {
            try
            {
                string[] rows = File.ReadAllText(fileName).Split('\r');
                foreach (string row in rows)
                {
                    string[] cols = row.Split(new char[] { ':' }, 2);
                    if (cols.Length == 2)
                    {
                        string key = cols[0].Trim(new char[] { '\r', '\n', '\t', ' ', '\0' });
                        // Ignore comments beginning with #
                        if (!key.StartsWith("#") && !LanguageKeys.ContainsKey(key))
                        {
                            string content = cols[1].Trim(new char[] { '\r', '\n', '\t', ' ', '\0' }).Replace("\\n", "\n");
                            // See if there is a tip in place

                            string[] contents = content.Split('\t');
                            if (contents.Length > 0)
                            {
                                string tip = String.Empty;
                                string text = contents[0];
                                if (contents.Length > 1)
                                {
                                    tip = contents[1];
                                }
                                LanguageKeys.Add(String.Format("{{{0}}}", key), new LanguageItem(text, tip));
                            }
                        }

                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
            return false;
        }


        /// <summary>
        /// Returns the text.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public LanguageItem GetItem(string key)
        {
            if (!key.StartsWith("{"))
                key = "{" + key;
            if (!key.EndsWith("}"))
                key += "}";
            
            if (LanguageKeys.ContainsKey(key))
            {
                return LanguageKeys[key];
            }
            return null;
        }


    }
}
