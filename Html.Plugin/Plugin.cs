using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevNotepad.PluginFramework.Interfaces;
using DevNotepad.Library.Extensions;
using System.IO;
using System.Drawing;

namespace Html.Helper
{
    public class Plugin : IPlugin
    {

        /// <summary>
        /// Internal access to host object.
        /// </summary>
        private IPluginHost _Host;

        /// <summary>
        /// Access to host object.
        /// </summary>
        public IPluginHost Host
        {
            get
            {
                return _Host;
            }
            set
            {
                _Host = value;
                _Host.Register(this);
            }
        }

        /// <summary>
        /// Image list to store icons for displaying the autocomplete
        /// for paths.
        /// </summary>
        private ImageList imageList = null;

        /// <summary>
        /// List of HTML tags.
        /// </summary>
        private List<string> _HtmlTags = new List<string>(){
            "!doctype",
            "a",
            "abbr",
            "address",
            "area",
            "article",
            "aside",
            "audio",
            "b",
            "base",
            "bdi",
            "bdo",
            "blockquote",
            "body",
            "br",
            "button",
            "canvas",
            "caption",
            "cite",
            "code",
            "col",
            "colgroup",
            "data",
            "datalist",
            "dd",
            "del",
            "details",
            "dfn",
            "dialog",
            "div",
            "dl",
            "dt",
            "em",
            "embed",
            "fieldset",
            "figcaption",
            "figure",
            "footer",
            "form",
            "h1",
            "h2",
            "h3",
            "h4",
            "h5",
            "h6",
            "head",
            "header",
            "hgroup",
            "hr",
            "html",
            "i",
            "iframe",
            "img",
            "input",
            "ins",
            "kbd",
            "keygen",
            "label",
            "legend",
            "li",
            "link",
            "main",
            "map",
            "mark",
            "menu",
            "menuitem",
            "meta",
            "meter",
            "nav",
            "noscript",
            "object",
            "ol",
            "optgroup",
            "option",
            "output",
            "p",
            "param",
            "pre",
            "progress",
            "q",
            "rb",
            "rp",
            "rt",
            "rtc",
            "ruby",
            "s",
            "samp",
            "script",
            "section",
            "select",
            "small",
            "source",
            "span",
            "strong",
            "style",
            "sub",
            "summary",
            "sup",
            "table",
            "tbody",
            "td",
            "template",
            "textarea",
            "tfoot",
            "th",
            "thead",
            "time",
            "title",
            "tr",
            "track",
            "u",
            "ul",
            "var",
            "video",
            "wbr"
        };

        /// <summary>
        /// List of HTML attributes
        /// </summary>
        private List<string> _HtmlAttributes = new List<string>(){
            "hidden",
			"high",
			"href",
			"hreflang",
			"http-equiv",
			"icon",
			"id",
			"ismap",
			"itemprop",
			"keytype",
			"kind",
			"label",
			"lang",
			"language",
			"list",
			"loop",
			"low",
			"manifest",
			"max",
			"maxlength",
			"media",
			"method",
			"min",
			"multiple",
			"name",
			"novalidate",
			"open",
			"optimum",
			"pattern",
			"ping",
			"placeholder",
			"poster",
			"preload",
			"pubdate",
			"radiogroup",
			"readonly",
			"rel",
			"required",
			"reversed",
			"rows",
			"rowspan",
			"sandbox",
			"spellcheck",
			"scope",
			"scoped",
			"seamless",
			"selected",
			"shape",
			"size",
			"sizes",
			"span",
			"src",
			"srcdoc",
			"srclang",
			"srcset",
			"start",
			"step",
			"style",
			"summary",
			"tabindex",
			"target",
			"title",
			"type",
			"usemap",
			"value",
			"width",
			"wrap",
			"border",
			"buffered",
			"challenge",
			"charset",
			"checked",
			"cite",
			"class",
			"code",
			"codebase",
			"color",
			"cols",
			"colspan",
			"content",
			"contenteditable",
			"contextmenu",
			"controls",
			"coords",
			"data",
			"data-*",
			"datetime",
			"default",
			"defer",
			"dir",
			"dirname",
			"disabled",
			"download",
			"draggable",
			"dropzone",
			"enctype",
			"for",
			"form",
			"formaction",
			"headers",
			"height",
			"accept",
			"accept-charset",
			"accesskey",
			"action",
			"align",
			"alt",
			"async",
			"autocomplete",
			"autofocus",
			"autoplay",
			"autosave",
			"bgcolor"
        };

        /// <summary>
        /// Plugin initialized.
        /// </summary>
        public void Initialize()
        {
            imageList = new ImageList();
            imageList.Images.Add(Properties.Resources.file);
            imageList.Images.Add(Properties.Resources.folder);

            // Sort the tags/attributes.
            _HtmlAttributes.Sort();
            _HtmlTags.Sort();

            _Host.DocumentCreated += _Host_DocumentCreated;
        }

        /// <summary>
        /// Document created so attach to the appropriate events and listen.
        /// </summary>
        /// <param name="Editor"></param>
        void _Host_DocumentCreated(ScintillaNET.Scintilla Editor)
        {
            Editor.AutoComplete.RegisterImages(imageList, Color.FromArgb(255,255,0,255));
            Editor.AutoComplete.MaxHeight = 15;
            Editor.CharAdded += Editor_CharAdded;
        }

        /// <summary>
        /// Gets the document from the sender.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        IDocument GetDocument(object sender)
        {
            try
            {
                IDocument doc = (IDocument)(((ScintillaNET.Scintilla)sender).Parent);
                return doc;
            }
            catch { }
            return null;
        }

        /// <summary>
        /// Gets the Scintilla component from the sender
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        ScintillaNET.Scintilla GetScintilla(object sender)
        {
            try
            {
                ScintillaNET.Scintilla edit = (((ScintillaNET.Scintilla)sender));
                return edit;
            }
            catch { }
            return null;
        }


        /// <summary>
        /// Gets the attribute name if within a string
        /// </summary>
        /// <param name="curPos"></param>
        /// <param name="editor"></param>
        /// <returns></returns>
        private string getAttribute(int curPos, ScintillaNET.Scintilla editor)
        {
            // Start parsing backwards...
            StringBuilder sb = new StringBuilder();
            bool foundStringStart = false;
            
            for (int i = curPos - 1; i >= 0; i--)
            {
                if (foundStringStart)
                {
                    if (editor.Text[i].IsWordChar())
                    {
                        sb.Insert(0, editor.Text[i]);
                    }
                    else
                    {
                        if (editor.Text[i] != '=')
                        {

                            break;
                        }
                    }
                }
                else
                {
                    if (editor.Text[i] == '"')
                        foundStringStart = true;
                }
            }
            return sb.ToString();

        }


        /// <summary>
        /// Gets the top path of of the file relative to the 
        /// base path and converts \ to / to make it web 
        /// path friendly.
        /// </summary>
        /// <param name="rootDir"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        private string GetTopPath(string rootDir, string path)
        {
            if (rootDir == null || String.IsNullOrEmpty(path))
                return String.Empty;
            // Strip off the root path.
            path = path.Replace(rootDir, "");

            // Switch back slashes to forward slashes for web
            path = path.Replace("\\", "/");

            if (path[0] != '/')
            {
                path = "/" + path;
            }
            return path;
        }

        /// <summary>
        /// Displays a popup containing a list of files relative to either the path of the
        /// file being edited or if the file hasn't been saved relative to the DevNotepad
        /// strorage path on the Local app data.
        /// </summary>
        /// <param name="curPos"></param>
        /// <param name="editor"></param>
        /// <param name="doc"></param>
        private void showFilePopup(int curPos, ScintillaNET.Scintilla editor, IDocument doc)
        {
            
            if (doc != null)
            {
                string[] displayFiles = null;
                string[] displayDirs = null;
                string rootDir = "";
                if (!String.IsNullOrEmpty(doc.FileName))
                {
                    rootDir = Path.GetDirectoryName(doc.FileName);
                    displayFiles = Directory.GetFiles(rootDir, "*.*", SearchOption.AllDirectories);
                    displayDirs = Directory.GetDirectories(rootDir, "*.*", SearchOption.AllDirectories);
                }
                else
                {
                    rootDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DevNotepad");
                    displayFiles = Directory.GetFiles(rootDir, "*.*", SearchOption.AllDirectories);
                    displayDirs = Directory.GetDirectories(rootDir, "*.*", SearchOption.AllDirectories);
                }
                if (displayFiles != null || displayDirs != null)
                {
                    for (int i = 0; i < displayFiles.Length; i++)
                    {

                        displayFiles[i] = String.Format("{0}?0", GetTopPath(rootDir, displayFiles[i]));
                    }

                    for (int i = 0; i < displayDirs.Length; i++)
                    {
                        displayDirs[i] = String.Format("{0}/?1", GetTopPath(rootDir, displayDirs[i]));
                    }

                    List<string> display = new List<string>();
                    if (displayDirs != null)
                        display.AddRange(displayDirs);
                    if (displayFiles != null)
                        display.AddRange(displayFiles);

                    editor.AutoComplete.ListSeparator = '|';
                    editor.AutoComplete.List = display;
                    editor.AutoComplete.Show();

                }
            }
        }

        /// <summary>
        /// Generic check to determine if the cursor position places it inside of an HTML tag.
        /// </summary>
        /// <param name="curPos"></param>
        /// <param name="editor"></param>
        /// <returns></returns>
        private bool InTag(int curPos, ScintillaNET.Scintilla editor)
        {
            for (int i = curPos-1; i >= 0; i--)
            {
                if (editor.Text[i] == '>')
                    return false;
                if (editor.Text[i] == '\r')
                    return false;
                if (editor.Text[i] == '\n')
                    return false;

                if (editor.Text[i] == '<')
                    return true;
            }
            return false;
        }

        /// <summary>
        /// CharAdded event attached to scintilla control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Editor_CharAdded(object sender, ScintillaNET.CharAddedEventArgs e)
        {
            if (e.Ch == '"')
            {
                
                ScintillaNET.Scintilla editor = GetScintilla(sender);
                if (editor != null)
                {
                    int curPos = editor.CurrentPos;

                    // We only care about hypertext
                    if (editor.Lexing.Lexer != ScintillaNET.Lexer.Hypertext)
                        return;

                    int curStyle = editor.Styles.GetStyleAt(curPos);

                    if (curStyle == 6 || curStyle > 20)
                        return;

                    string att = getAttribute(curPos, editor);
                    
                    if (att == "src")
                    {
                        IDocument doc = GetDocument(sender);
                        if (doc != null)
                            showFilePopup(curPos, editor, doc);
                    }
                }
            }
            if (e.Ch == '<')
            {
                ScintillaNET.Scintilla editor = GetScintilla(sender);
                if (editor != null)
                {
                    int curPos = editor.CurrentPos;
                    if (editor.Lexing.Lexer != ScintillaNET.Lexer.Hypertext)
                        return;

                    int curStyle = editor.Styles.GetStyleAt(curPos);

                    if (curStyle > 20)
                        return;
                    editor.AutoComplete.List = _HtmlTags;
                    editor.AutoComplete.Show();
                }

            }
            if (e.Ch == ' ')
            {
                ScintillaNET.Scintilla editor = GetScintilla(sender);
                if (editor != null)
                {
                    int curPos = editor.CurrentPos;
                    // Don't handle these in strings
                    if (editor.Lexing.Lexer != ScintillaNET.Lexer.Hypertext)
                        return;

                    if (InTag(curPos, editor))
                    {
                        int curStyle = editor.Styles.GetStyleAt(curPos);
                        
                        if (curStyle == 6 || curStyle > 20)
                            return;
                        editor.AutoComplete.List = _HtmlAttributes;
                        editor.AutoComplete.Show();
                    }
                }
            }
        }

    }
}
