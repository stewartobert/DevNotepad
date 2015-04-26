using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevNotepad.Config;
using DevNotepad.Debug;
using DevNotepad.GUI.Forms;
using DevNotepad.Models;

namespace DevNotepad.Tools
{
    public static class DocumentManager
    {


        #region Events

        public static EventArgs e = null;

        /// <summary>
        /// Static PluginHost for global access
        /// </summary>
        public static PluginHost PluginHost = new PluginHost();

        #region Document created event

        public static event DocumentCreated DocCreated;        
        public delegate void DocumentCreated(FormDocument doc, EventArgs e);

        #endregion

        #region Document closed event

        public static event DocumentClosed DocClosed;
        public delegate void DocumentClosed(FormDocument doc, EventArgs e);

        #endregion

        #region Active Document Changed

        public static event DocumentChanged DocChanged;
        public delegate void DocumentChanged(FormDocument doc, EventArgs e);

        #endregion

        #endregion

        private static FormMain _MainForm = null;

        #region Properties

        /// <summary>
        /// Retrieve the currently active document.
        /// </summary>
        public static FormDocument ActiveDoc
        {
            get
            {
                return (FormDocument)_MainForm.ActiveMdiChild;
            }
        }

        #endregion

        /// <summary>
        /// Setup the document manager.
        /// </summary>
        /// <param name="mainForm"></param>
        public static void Initialize(FormMain mainForm)
        {
            _MainForm = mainForm;
        }

        /// <summary>
        /// Document created.
        /// </summary>
        /// <param name="doc"></param>
        private static void OnDocumentCreated(FormDocument doc)
        {
            if (DocCreated != null)
            {
                DocCreated(doc, e);
            }
        }

        /// <summary>
        /// Document changed
        /// </summary>
        /// <param name="doc"></param>
        public static void OnDocumentChanged(FormDocument doc)
        {
            if (DocChanged != null)
            {
                DocChanged(doc, e);
            }
        }

        /// <summary>
        /// Document closed
        /// </summary>
        /// <param name="doc"></param>
        private static void OnDocumentClosed(FormDocument doc)
        {
            if (DocClosed != null)
            {
                DocClosed(doc, e);
            }
        }


        public static List<FormDocument> _Documents = new List<FormDocument>();

        /// <summary>
        /// Create a document
        /// </summary>
        /// <param name="main"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static FormDocument CreateDocument(this FormMain main, string name)
        {
            FormDocument newDoc = new FormDocument();
            string title = name;
            if (File.Exists(title))
                title = Path.GetFileName(title);
            newDoc.Text = title;
            newDoc.TabText = name;
            newDoc.BaseTabText = name;
            _Documents.Add(newDoc);
            newDoc.Show(main.DockingPanel);      
      
            

            return newDoc;
        }

        public static void UpdateStyle()
        {
            foreach (FormDocument document in _Documents)
            {
                try
                {
                    document.SetStyle();
                }
                catch { } // Fail silently and keep moving along
            }
        }

        /// <summary>
        /// Create a new document
        /// </summary>
        /// <param name="main"></param>
        public static void NewDocument(this FormMain main)
        {
            FormDocument doc = main.CreateDocument(String.Format("New {0}", _Documents.Count+1));
            OnDocumentCreated(doc);
        }

        /// <summary>
        /// Open a new file
        /// </summary>
        /// <param name="main"></param>
        public static void OpenFiles(this FormMain main)
        {
            using (OpenFileDialog dialogOpen = new OpenFileDialog())
            {
                dialogOpen.Filter = Schemes.Extensions;
                dialogOpen.Multiselect = true;
                if (dialogOpen.ShowDialog() == DialogResult.OK)
                {
                    if (dialogOpen.FileNames != null && dialogOpen.FileNames.Length > 0)
                    {
                        bool showLoader = false;
                        if (dialogOpen.FileNames.Length > 4)
                        {
                            showLoader = false;
                            _MainForm.StartLoader();
                        }
                        int cnt = 0;
                        string loadMessage = LanguageManager.GetText("LOADINGFILE");
                        foreach (string file in dialogOpen.FileNames)
                        {
                            try
                            {
                                cnt++;
                                long size = (new FileInfo(file)).Length;
                                float mb = (size / 1024f) / 1024f;
                                _MainForm.UpdateLoader(String.Format(loadMessage,cnt, dialogOpen.FileNames.Length, file, Math.Round(mb, 2)), cnt, dialogOpen.FileNames.Length);
                                main.OpenFile(file);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(String.Format(LanguageManager.GetText("ERROROPENINGFILE"), file, ex.ToString()), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Log.Write(ex);
                            }
                        }

                        _MainForm.FinishLoader();
                    }
                }
            }
        }

        /// <summary>
        /// Set the details in status bar.
        /// </summary>
        /// <param name="line"></param>
        /// <param name="column"></param>
        public static void UpdatePosition(int line, int column)
        {
            string labelText = String.Format("Line {0}, Column {1}", line, column);
            _MainForm.SetPosition(labelText);
        }

        public static void OpenFile(this FormMain main, string fileName)
        {
            #region Bring already open file to front.
            foreach (FormDocument document in _Documents)
            {
                if (document.FileName == fileName)
                {
                    document.BringToFront();
                    return;
                }
            }
            #endregion
            FormDocument doc = main.CreateDocument(fileName);
            doc.TabText = Path.GetFileName(fileName);
            doc.Icon = Icon.ExtractAssociatedIcon(fileName);
            doc.OpenFile(fileName);
            OnDocumentCreated(doc);
        }

        public static void CloseDoc(this FormDocument doc)
        {
            try
            {
                OnDocumentClosed(doc);
                _Documents.Remove(doc);
            }
            catch { }
        }

        public static void FindInOpen(string searchText, bool matchWholeWord, bool matchCase, int searchMode)
        {
            FindList findList = new FindList(searchText);

            foreach (FormDocument document in _Documents)
            {
                List<FindItem> items = document.FindAll(searchText, matchWholeWord, matchCase, searchMode);
                if (items != null && items.Count > 0)
                {
                    findList.Items.AddRange(items);
                }
            }

            _MainForm.FindInFiles(findList);
        }

    }
}
