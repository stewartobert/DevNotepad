using DevNotepad.Tools;
using DevNotepad.Models.Syntax;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DevNotepad.Config
{
    public static class Schemes
    {
        /// <summary>
        /// Store a list of highlighters
        /// </summary>
        public static List<Scheme> Highlighters = new List<Scheme>();

        private static string _Extensions = null;
        public static string Extensions
        {
            get
            {
                if (_Extensions == null)
                {
                    BuildExtensions();
                }
                return _Extensions;
            }
        }

        /// <summary>
        /// Builds out an extensions string from all extensions.
        /// </summary>
        public static void BuildExtensions()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder all = new StringBuilder();
            foreach (Scheme scheme in Highlighters)
            {
                if (scheme.Extensions != null && scheme.Extensions.Length > 0)
                {
                    StringBuilder inner = new StringBuilder();

                    foreach (string ext in scheme.Extensions)
                    {
                        inner.Append((inner.Length > 0 ? ";" : "") + "*" + ext);
                    }
                    all.Append((all.Length > 0 ? ";" : "") + inner.ToString());
                    sb.Append("|" + String.Format("{0} Files ({1})|{1}", scheme.Name, inner.ToString()));
                }
            }
            _Extensions = String.Format("All Supported Files|{0}{1}", all.ToString(), sb.ToString());
        }

        /// <summary>
        /// Returns a highlighter based on the extension. If no highlighter can be found
        /// then returns null.
        /// </summary>
        /// <param name="extension"></param>
        /// <returns>Scheme or Null</returns>
        public static Scheme GetHighlighterByExtension(string extension)
        {
            if (extension == null || extension.Length == 0){
                return null;
            }

            if (extension[0] != '.')
            {
                extension = "." + extension;
            }
            foreach (Scheme scheme in Highlighters)
            {
                
                if (scheme.Extensions != null && scheme.Extensions.Contains(extension))
                {
                    return scheme;
                }
                
            }
            return null;
        }

        /// <summary>
        /// Initializes the Highlighters array for access
        /// </summary>
        public static void LoadHighlighters()
        {
            string path = Paths.SyntaxPath;
            if (Directory.Exists(path))
            {

                string[] files = Directory.GetFiles(path, "*.xml");

                foreach (string file in files)
                {
                    XmlSerializer x = new XmlSerializer(typeof(Scheme));


                    using (FileStream fs = File.OpenRead(file))
                    {
                        try
                        {
                            Scheme nHighlighter = (Scheme)x.Deserialize(fs);
                            // Initialize the autocomplete stuff into a dictionary for performance.
                            nHighlighter.InitAutoComplete();
                            //nHighlighter.FileName = file;
                            //nHighlighter.InitializePreset(Themes.CurrentPreset);
                            Highlighters.Add(nHighlighter);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }

                }

            }
        }


        /// <summary>
        /// Gets a highlighter by name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Scheme HighlighterByName(string name)
        {
            try
            {
                Scheme nh = Highlighters.Where(m => m.Name.ToLowerInvariant().Equals(name)).FirstOrDefault();
                return nh;
            }
            catch { }
            return null;
        }

    }
}
