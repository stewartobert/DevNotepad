using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevNotepad.Config;
using DevNotepad.Models.Syntax;
using DevNotepad.Models.Themes;
using DevNotepad.Library.Extensions;
using System.IO;
using DevNotepad.Debug;
using DevNotepad.Tools;
using DevNotepad.Models;
using System.Threading;
using DevNotepad.PluginFramework.Interfaces;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace DevNotepad.GUI.Forms
{
    /// <summary>
    /// Includes the IDocument interface to give some level of access of the document to plugins.
    /// </summary>
    public partial class FormDocument : WeifenLuo.WinFormsUI.Docking.DockContent, IDocument
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool InvalidateRect(IntPtr hWnd, IntPtr rect, bool bErase);
        #region Properties

        private string _FileName = null;
        /// <summary>
        /// Filename
        /// </summary>
        public string FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                _FileName = value;
            }
        }

        private bool _Invalidating = false;

        #region Search Properties

        private string _FindText = "";
        private bool _MatchWholeWord = false;
        private bool _MatchCase = false;
        private bool _Wrap = false;
        private int _SearchMode = 2;

        #endregion

        private bool _Modified = false;
        /// <summary>
        /// Track modified state of document
        /// </summary>
        public bool Modified
        {
            get
            {
                return _Modified;
            }
            set
            {
                _Modified = value;
            }
        }

        private string _BaseTabText = "";
        public string BaseTabText
        {
            get
            {
                return _BaseTabText;
            }
            set
            {
                _BaseTabText = value;
            }
        }

        private Scheme _CurScheme = null;

        #endregion

        #region Internal Tracking

        private int _prevTop = -1;
        private int _prevBot = -1;

        #endregion

        public FormDocument()
        {
            InitializeComponent();
            Editor.NativeInterface.UpdateUI += NativeInterface_UpdateUI;            
        }

        void NativeInterface_UpdateUI(object sender, ScintillaNET.NativeScintillaEventArgs e)
        {
            
            XmlMatchedTagHighlighter.tagMatch(false, Editor);
            Editor.Indicators[8].Style = ScintillaNET.IndicatorStyle.RoundBox;

            DocumentManager.UpdatePosition(Editor.NativeInterface.LineFromPosition(Editor.CurrentPos)+1, Editor.GetColumn(Editor.CurrentPos)+1);

            if (!_Modified && Editor.Modified)
            {
                _Modified = Editor.Modified;
                TabText = _BaseTabText + " *";
            }

            if (_Modified && !Editor.Modified)
            {
                _Modified = Editor.Modified;
                TabText = _BaseTabText;
            }

            HighlightFoldRegion();
            
            // Experimental attempt to find a way to highlight the currently active field region with a background color.
            // So far not a plausable option but worth digging further as this would be a nice feature to support. If 
            // impossible to achieve within the 
            
            
            //Editor.GetRange(0, Editor.Text.Length).SetIndicator(8, (int)Constants.INDIC_ROUNDBOX);
            //Editor.NativeInterface.Style, Constants.INDIC_ROUNDBOX);
            //Editor.
            Editor.NativeInterface.SetIndicatorCurrent(8);
        }


        #region Set styling

        public void SetStyle(Scheme syntax = null)
        {
            if (syntax == null)
            {
                syntax = _CurScheme;
            }
            
            string defFore = "#000000";
            string defBack = "#ffffff";
            
            Theme theme = Themes.CurrentPreset;

            if (syntax != null)
            {
                    int lex = 0;
                    if (Int32.TryParse(syntax.Lexer, out lex))
                    {
                        Editor.NativeInterface.SetLexer(lex);
                    }
                    else
                    {
                        Editor.Lexing.LexerName = syntax.Lexer;
                    }
            }

            #region Setup Keywords
            if (syntax != null)
            {
                foreach (Keyword keyword in syntax.Keywords)
                {
                    Editor.NativeInterface.SetKeywords(keyword.Key, keyword.Keywords);
                }
            }

            #endregion

            #region Setup Styles

            #region Setup the defaults
            try
            {
                PresetStyle preStyle = theme.DefaultPreset; // theme.Presets.Where(m => m.Key.Equals("default", StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault().Value;
                if (preStyle != null)
                {
                    try
                    {
                        BackColor = preStyle.Back.ToColor();
                    }
                    catch { }
                    for (int i = 0; i < 128; i++)
                    {
                        Editor.Styles[i].ForeColor = preStyle.Fore.ToColor();
                        Editor.Styles[i].BackColor = preStyle.Back.ToColor();
                        Editor.Styles[i].Bold = preStyle.Bold;
                        Editor.Styles[i].Italic = preStyle.Italic;
                        Editor.Styles[i].Underline = preStyle.Underline;
                        Editor.Styles[i].FontName = FontName(preStyle.Font);
                        Editor.Styles[i].Size = (float)preStyle.FontSize;
                        Editor.Styles[i].IsSelectionEolFilled = preStyle.EOLFilled;
                        
                        Editor.Styles.ClearAll();
                    }
                    defFore = preStyle.Fore;
                    defBack = preStyle.Back;
                    Editor.Caret.Color = defBack.ToColor().Invert();
                }
            }
            catch { } // Fail quietly
            #endregion

            #region Setup brace styles specifically.

            Editor.Styles[34].ForeColor = "#8080ff".ToColor();
            Editor.Styles[35].ForeColor = "#ff0000".ToColor();

            Editor.Styles[34].BackColor = "#ffff80".ToColor();
            Editor.Styles[35].BackColor = "#ffff80".ToColor();

            Editor.Styles[34].Bold = true;
            Editor.Styles[35].Bold = true;

            Editor.Styles[34].FontName = "Consolas";
            Editor.Styles[35].FontName = "Consolas";

            Editor.Styles[34].Size = 10;
            Editor.Styles[35].Size = 10;

            #endregion

            if (syntax != null)
            {
                foreach (Style style in syntax.Styles)
                {

                    if (!style.UseTemplate || String.IsNullOrEmpty(style.Template))
                    {
                        Editor.Styles[style.Key].ForeColor = style.Fore.ToColor(defFore);
                        Editor.Styles[style.Key].BackColor = style.Back.ToColor(defBack);
                        Editor.Styles[style.Key].FontName = FontName(style.Font);
                        Editor.Styles[style.Key].Size = (float)style.FontSize;
                        Editor.Styles[style.Key].Bold = style.Bold;
                        Editor.Styles[style.Key].Italic = style.Italic;
                        Editor.Styles[style.Key].Underline = style.Underline;
                    }
                    else
                    {
                        Style tempStyle = theme.GetStyle(style.Template);
                        if (tempStyle != null && !String.IsNullOrEmpty(tempStyle.Fore.FormatColor()))
                        {
                            Editor.Styles[style.Key].ForeColor = tempStyle.Fore.ToColor(defFore);
                            Editor.Styles[style.Key].BackColor = tempStyle.Back.ToColor(defBack);
                            Editor.Styles[style.Key].FontName = FontName(tempStyle.Font);
                            Editor.Styles[style.Key].Size = (float)tempStyle.FontSize;
                            Editor.Styles[style.Key].Bold = tempStyle.Bold;
                            Editor.Styles[style.Key].Italic = tempStyle.Italic;
                            Editor.Styles[style.Key].Underline = tempStyle.Underline;
                        }
                    }
                }
            }
            Editor.Folding.Flags = ScintillaNET.FoldFlag.LineAfterContracted;

            #endregion

            #region Setup folding
            if (syntax != null)
            {
                if (syntax.Folding)
                {
                    Editor.Lexing.SetProperty("fold", "1");
                    Editor.Lexing.SetProperty("fold.preprocessor", "1");
                }
                else
                {
                    Editor.Lexing.SetProperty("fold", "0");
                }
            }

            #endregion

            #region Margin Colors

            if (!String.IsNullOrEmpty(theme.FoldBackground))
            {
                Editor.NativeInterface.SetFoldMarginColour(true, System.Drawing.ColorTranslator.ToWin32(ColorTranslator.FromHtml(theme.FoldBackground)));
                Editor.Margins.FoldMarginHighlightColor = ColorTranslator.FromHtml(theme.FoldBackground);

                // Set the fold boxes to invert the background color to get a consistent look.
                Editor.Folding.MarkerScheme = ScintillaNET.FoldMarkerScheme.BoxPlusMinus;
                Editor.Markers.Folder.ForeColor = theme.FoldBackground.ToColor();
                Editor.Markers.FolderEnd.ForeColor = theme.FoldBackground.ToColor();
                Editor.Markers.FolderOpen.ForeColor = theme.FoldBackground.ToColor();
                Editor.Markers.FolderOpenMid.ForeColor = theme.FoldBackground.ToColor();
                Editor.Markers.FolderOpenMidTail.ForeColor = theme.FoldBackground.ToColor();
                Editor.Markers.FolderSub.ForeColor = theme.FoldBackground.ToColor();
                Editor.Markers.FolderTail.ForeColor = theme.FoldBackground.ToColor();

                
                Editor.Markers.Folder.BackColor = Editor.Markers.Folder.ForeColor.Invert();
                Editor.Markers.FolderEnd.BackColor = Editor.Markers.FolderEnd.ForeColor.Invert();
                Editor.Markers.FolderOpen.BackColor = Editor.Markers.FolderOpen.ForeColor.Invert();
                Editor.Markers.FolderOpenMid.BackColor = Editor.Markers.FolderOpenMid.ForeColor.Invert();
                Editor.Markers.FolderOpenMidTail.BackColor = Editor.Markers.FolderOpenMidTail.ForeColor.Invert();
                Editor.Markers.FolderSub.BackColor = Editor.Markers.FolderSub.ForeColor.Invert();
                Editor.Markers.FolderTail.BackColor = Editor.Markers.FolderTail.ForeColor.Invert();

                Editor.NativeInterface.SetHighlightFold(true);
            }

            #endregion

            #region Setup Indent type

            if (syntax != null)
            {
                switch (syntax.IndentType.ToLower())
                {
                    case "cpp":
                        Editor.Indentation.SmartIndentType = ScintillaNET.SmartIndent.CPP;
                        break;
                    case "xml":
                        Editor.Indentation.SmartIndentType = ScintillaNET.SmartIndent.XML;
                        break;
                    default:
                        Editor.Indentation.SmartIndentType = ScintillaNET.SmartIndent.Simple;
                        break;
                }
            }

            #endregion

            Editor.Indentation.ShowGuides = true;
            
            
            Editor.NativeInterface.Colourise(0, -1);

            Editor.NativeInterface.SetProperty("fold.compact", "0");

            _CurScheme = syntax;


            SetHighlightColor();

        }

        /// <summary>
        /// Open a file
        /// </summary>
        /// <param name="fileName"></param>
        public void OpenFile(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    SetStyle(Schemes.GetHighlighterByExtension(Path.GetExtension(fileName)));
                    Editor.Text = "";
                    string openText = File.ReadAllText(fileName);
                    bool verifyBinary = false;
                    for (int i = 0; i < openText.Length; i++)
                    {
                        if (openText[i] == '\0')
                        {
                            verifyBinary = true;
                            break;
                        }
                    }
                    if (verifyBinary)
                    {
                        if (MessageBox.Show(LanguageManager.GetText("{BINARYFILE}"), "Binary File", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No){
                            this.Close();
                        }
                    }
                    Editor.AppendText(openText);

                    Colourise();

                    Editor.UndoRedo.EmptyUndoBuffer();
                    Editor.Modified = false;
                    Icon = Icon.ExtractAssociatedIcon(fileName);
                    
                    _FileName = fileName;
                    _BaseTabText = Path.GetFileName(_FileName);
                    TabText = _BaseTabText;
                    _Modified = false;
                }
                else
                {
                    MessageBox.Show(String.Format(LanguageManager.GetText("INVALIDFILENAME"), fileName), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }

        private void Colourise()
        {
            Editor.NativeInterface.Colourise(0, -1);
        }

        /// <summary>
        /// Save the document as
        /// </summary>
        /// <returns></returns>
        public bool SaveAs()
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = Schemes.Extensions;
                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    if (!String.IsNullOrEmpty(dialog.FileName))
                    {
                        if (Save(dialog.FileName))
                        {
                            SetStyle(Schemes.GetHighlighterByExtension(Path.GetExtension(dialog.FileName)));
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        ///  Save the file using a specific filename
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public bool Save(string fileName = null)
        {
            try
            {
                if (String.IsNullOrEmpty(fileName))
                {
                    if (String.IsNullOrEmpty(_FileName))
                        return SaveAs();
                    fileName = _FileName;
                }
                using (FileStream fs = File.Create(fileName))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        bw.Write(Editor.RawText, 0, Editor.RawText.Length - 1); // Omit trailing NULL
                    }
                }

                Text = fileName;
                TabText = Path.GetFileName(fileName);
                _BaseTabText = TabText;
                _Modified = false;
                Editor.Modified = false;
                try
                {
                    Icon = Icon.ExtractAssociatedIcon(fileName);
                }
                catch { }
                _FileName = fileName;
                return true;
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
            return false;
        }

        private string FontName(string font)
        {
            return "Consolas";
            //return (!String.IsNullOrEmpty(font) ? font : "Consolas");
        }

        #endregion


        private void SetHighlightColor()
        {
            try
            {
                Color color = Themes.CurrentPreset.DefaultPreset.Back.ToColor(); // Themes.CurrentPreset.Presets.Where(m => m.Key.ToLowerInvariant().Equals("default")).FirstOrDefault().Value.Back.ToColor();

                //if (color.R < 30 && color.G < 30 && color.B < 30)

                //    Editor.Caret.CurrentLineBackgroundColor = color.Lerp(color.Invert(), .5f);
                //else
                if (color != null)
                {
                    Editor.Caret.CurrentLineBackgroundColor = color.Lerp(color.Invert(), .03f);
                }
            }
            catch { }
        }

        private void FormDocument_Load(object sender, EventArgs e)
        {
            //SetStyle(Schemes.HighlighterByName("csharp"));
            //SetDoubleBuffered(Editor);

            DocumentManager.PluginHost.OnDocumentCreated(Editor);

            Editor.NativeInterface.SendMessageDirect(ScintillaNET.Constants.SCI_BRACEHIGHLIGHTINDICATOR, true, 3);
            Editor.NativeInterface.SendMessageDirect(ScintillaNET.Constants.SCI_BRACEBADLIGHTINDICATOR, true, 4);

            Editor.Indicators[3].Style = ScintillaNET.IndicatorStyle.RoundBox;
            Editor.Indicators[4].Style = ScintillaNET.IndicatorStyle.RoundBox;
            Editor.Indicators[3].Color = Color.Blue;
            Editor.Indicators[4].Color = Color.IndianRed;
            Editor.Indicators[3].DrawMode = ScintillaNET.IndicatorDrawMode.Overlay;
            Editor.Indicators[4].DrawMode = ScintillaNET.IndicatorDrawMode.Overlay;
            Editor.Indicators[3].OutlineAlpha = 255;
            Editor.Indicators[4].OutlineAlpha = 255;

            Editor.Indicators[0].Style = ScintillaNET.IndicatorStyle.Box;
            Editor.Indicators[0].Color = Color.FromArgb(255, 223, 230, 255);
            Editor.Indicators[0].Alpha = 255;
            Editor.Indicators[0].DrawMode = ScintillaNET.IndicatorDrawMode.Overlay;

            //Editor.Indicators[].Style = ScintillaNET.IndicatorStyle.RoundBox;
        }

        private void FormDocument_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.CloseDoc();
        }

        #region Edit Menu Methods

        /// <summary>
        /// Undo the previous action
        /// </summary>
        public void Undo()
        {
            Editor.UndoRedo.Undo();
        }

        /// <summary>
        /// Redo the previously undone action
        /// </summary>
        public void Redo()
        {
            Editor.UndoRedo.Redo();
        }

        /// <summary>
        /// Copy the selected text to the clipboard and delete it
        /// </summary>
        public void Cut()
        {
            Editor.Clipboard.Cut();
        }

        /// <summary>
        /// Copy the selected text to the clipboard
        /// </summary>
        public void Copy()
        {
            Editor.Clipboard.Copy();
        }

        /// <summary>
        /// Paste contents of the clipboard 
        /// </summary>
        public void Paste()
        {
            Editor.Clipboard.Paste();
        }

        /// <summary>
        /// Delete character to the right of the cursor
        /// </summary>
        public void Delete()
        {
            Editor.NativeInterface.Clear();
        }

        /// <summary>
        /// Delete word to the left of the cursor
        /// </summary>
        public void DeleteWordLeft()
        {
            Editor.NativeInterface.DelWordLeft();
        }

        /// <summary>
        /// Delete word to the right of the cursor.
        /// </summary>
        public void DeleteWordRight()
        {
            Editor.NativeInterface.DelWordRight();
        }

        /// <summary>
        /// Select all text in the document
        /// </summary>
        public void SelectAll()
        {
            Editor.Selection.SelectAll();
        }

        #endregion


        #region Find/Replace/Goto

        #region Find

        public void SetSel(ScintillaNET.Range range, bool makeVisible = false)
        {
            range.Select();
            /*Editor.ClearSelections();
            Editor.Selection.Start = range.Start;
            Editor.Selection.End = range.End;
            if (makeVisible)
            {
                Editor.NativeInterface.SetSelection(range.Start, range.End);
            }*/
        }

        public void SetSel(int start, int end, bool makeVisible = false)
        {
            SetSel(new ScintillaNET.Range(start, end, Editor), makeVisible);
            
        }

        /// <summary>
        /// Find next
        /// </summary>
        /// <returns></returns>
        public bool FindNext()
        {

            return Find(_FindText, _MatchWholeWord, _MatchCase, _Wrap, _SearchMode, true);
        }

        public bool FindPrevious()
        {
            return Find(_FindText, _MatchWholeWord, _MatchCase, _Wrap, _SearchMode, false);
        }

        /// <summary>
        /// Performs a find operation and sets the cursor at the found position if found
        /// Returns true if the text is found or false if not.
        /// </summary>
        /// <param name="findText"></param>
        /// <param name="matchWholeWord"></param>
        /// <param name="matchCase"></param>
        /// <param name="wrapAround"></param>
        /// <param name="searchMode"></param>
        /// <param name="direction"></param>
        /// <returns>True/False</returns>
        public bool Find(string findText, bool matchWholeWord, bool matchCase, bool wrapAround, int searchMode, bool moveNext, bool startZero = false)
        {
            try
            {
                // Can't find nothing.
                if (String.IsNullOrEmpty(findText))
                {
                    return false;
                }
                int selStart = Editor.Selection.Start;
                int selEnd = Editor.Selection.End;
                int searchFlags = (int)ScintillaNET.SearchFlags.Empty;
                if (matchWholeWord)
                    searchFlags += (int)ScintillaNET.SearchFlags.WholeWord;
                if (matchCase)
                    searchFlags += (int)ScintillaNET.SearchFlags.MatchCase;
                if (searchMode == 3)
                    searchFlags += (int)ScintillaNET.SearchFlags.RegExp;

                // Handles escaping a search string.
                if (searchMode == 2)
                    findText = findText.Escapes();

                _MatchWholeWord = matchWholeWord;
                _MatchCase = matchCase;

                _FindText = findText;
                // Don't store the wrap mode at this point because we are
                // dealing with a zero start which occurs when it's find in all
                // open documents which forces wrapAround to false so as to not
                // keep finding in the same document.
                if (!startZero)
                    _Wrap = wrapAround;
                _SearchMode = searchMode;

                // Create a base range to search
                ScintillaNET.Range range = new ScintillaNET.Range(Editor.CurrentPos, Editor.TextLength, Editor);
                if (!moveNext)
                {
                    // Direction is up so swap the range which causes the editor to search up
                    range.Start = Editor.Selection.Start;
                    range.End = 0;
                }

                // Here specifically to deal with document searches.
                if (startZero)
                {
                    range.Start = 0;
                    range.End = Editor.TextLength;
                }

                ScintillaNET.Range findRange = Editor.FindReplace.Find(range, findText, (ScintillaNET.SearchFlags)searchFlags);
                if (findRange != null)
                {
                    SetSel(findRange);
                    return true;
                }
                else
                {
                    // Check wrapmode
                    if (wrapAround)
                    {
                        // Wrap mode is true and no find occurred so just adjust the range to search the entire document and
                        // try again
                        if (moveNext)
                        {
                            range.Start = 0;
                            range.End = Editor.TextLength;
                        }
                        else
                        {
                            range.Start = Editor.Text.Length;
                            range.End = 0;
                        }
                        findRange = Editor.FindReplace.Find(range, findText, (ScintillaNET.SearchFlags)searchFlags);
                        if (findRange != null)
                        {
                            SetSel(findRange);
                            return true;
                        }
                    }
                }

                /*Editor.ClearSelections();
                Editor.CurrentPos = selStart;
                Editor.Selection.Start = selStart;
                Editor.Selection.End = selEnd;*/


            }
            catch { }   // Fail silently. Can cause an exception on the SendMessageDirect here.
            return false;
        }



        private void HighlightFoldRegion()
        {

            int curPos = Editor.CurrentPos;
            int curLine = Editor.Lines.Current.Number;

            Editor.NativeInterface.MarkerDefine(10, (int)ScintillaNET.Constants.SC_MARK_BACKGROUND);
            Color color = Themes.CurrentPreset.GetStyle("default").Back.ToColor();
            Editor.Markers[10].ForeColor = color.Lerp(color.Invert(), .05f);
            Editor.Markers[10].BackColor = Editor.Markers[10].ForeColor;
            

            
            int topLine = Editor.NativeInterface.GetFoldParent(curLine);

            if (topLine > 0)
            {
                int botLine = Editor.NativeInterface.GetLastChild(topLine, (int)Editor.NativeInterface.GetFoldLevel(topLine)) + 1;

                if (botLine - topLine <= 1000)
                {

                    if (botLine != _prevBot || topLine != _prevTop)
                    {
                        _prevBot = botLine;
                        _prevTop = topLine;
                        Editor.Markers.DeleteAll(10);


                        for (int i = topLine; i < botLine; i++)
                        {
                            Editor.NativeInterface.MarkerAdd(i, 10);
                        }

                    }
                }

            }


        }


        public List<FindItem> FindAll(string searchText, bool matchWholeWord, bool matchCase, int searchMode)
        {
            List<FindItem> items = new List<FindItem>();

            int searchFlags = (int)ScintillaNET.SearchFlags.Empty;
            if (matchWholeWord)
                searchFlags += (int)ScintillaNET.SearchFlags.WholeWord;
            if (matchCase)
                searchFlags += (int)ScintillaNET.SearchFlags.MatchCase;
            if (searchMode == 3)
                searchFlags += (int)ScintillaNET.SearchFlags.RegExp;


            // Handles escaping a search string.
            if (searchMode == 2)
                searchText = searchText.Escapes();

            int Last = Editor.Text.Length;
            int searchLength = searchText.Length;
            int Pos = 0;



            ScintillaNET.Range range = new ScintillaNET.Range(Pos, Last, Editor);
            while (Pos > -1)
            {
                range.Start = Pos;
                range.End = Last;
                ScintillaNET.Range find = Editor.FindReplace.Find(range, searchText, (ScintillaNET.SearchFlags)searchFlags);
                if (find != null)
                {
                    int line = Editor.NativeInterface.LineFromPosition(find.Start);
                    string text = Editor.Lines[line].Text;
                    items.Add(new FindItem(text, this, this._FileName, find.Start, find.End, Editor.GetColumn(find.Start), Editor.NativeInterface.GetTabWidth()));
                    Pos = find.End;
                    
                }
                else
                {
                    Pos = -1;
                }
            }
            return items;
        }

        #endregion

        private void Editor_CharAdded(object sender, ScintillaNET.CharAddedEventArgs e)
        {
            AutoComplete match = _CurScheme.GetMatches(e.Ch, Editor.NativeInterface.GetStyleAt(Editor.CurrentPos));
            if (match != null)
            {
                DisplayAutoComplete(match);
            }
        }

        private void DisplayAutoComplete(AutoComplete match)
        {
            Editor.AutoComplete.ListSeparator = '\r';
            Editor.AutoComplete.List = GetAutoCompletes(match);
            Editor.AutoComplete.Show();
        }

        private List<string> GetAutoCompletes(AutoComplete auto)
        {
            List<string> result = new List<string>();
            foreach (Match match in auto.MethodRegEx.Matches(Editor.Text))
            {
                var matches = auto.MethodRegExInsert.Matches(match.Value);
                if (matches.Count > 0)
                {
                    result.Add(matches[0].Value.Trim(new char[] { '\n', '\r', '\t', ' ', '\0' }).Replace("\n", "").Replace("\r", ""));
                }

            }
            return result;
        }

        #endregion

        private void Editor_Paint(object sender, PaintEventArgs e)
        {


            //int curPos = Editor.CurrentPos;
            //int curLine = Editor.NativeInterface.LineFromPosition(curPos);

            //int topLine = Editor.NativeInterface.GetFoldParent(curLine);

            //if (topLine > 0)
            //{
            //    int botLine = Editor.NativeInterface.GetLastChild(topLine, (int)Editor.NativeInterface.GetFoldLevel(topLine));



            //    if (botLine > topLine)
            //    {
            //        //e.Graphics.ResetTransform();

            //        int yStart = Editor.NativeInterface.PointYFromPosition(Editor.NativeInterface.PositionFromLine(topLine));
            //        int yEnd = Editor.NativeInterface.PointYFromPosition(Editor.NativeInterface.PositionFromLine(botLine));
            //        Rectangle rectFill = new Rectangle(0, yStart, Editor.Width, yEnd);

                    
                    
            //        using (SolidBrush fillBrush = new SolidBrush(Color.FromArgb(50, 50, 50, 50)))
            //        {
                        
            //            Editor.Invalidate(rectFill);
            //            e.Graphics.FillRectangle(fillBrush, rectFill);
            //            Editor.Update();

            //        }

            //    }

            //}

        }

        public static void SetDoubleBuffered(System.Windows.Forms.Control c)
        {
            //Taxes: Remote Desktop Connection and painting
            //http://blogs.msdn.com/oldnewthing/archive/2006/01/03/508694.aspx
            if (System.Windows.Forms.SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo aProp =
                  typeof(System.Windows.Forms.Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            aProp.SetValue(c, true, null);
        }

        private void FormDocument_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Editor_Validated(object sender, EventArgs e)
        {
            
        }
        public void FocusEditor()
        {
            this.Focus();
            Editor.Focus();
        }
    }
}
