using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevNotepad.Config;
using DevNotepad.Debug;
using DevNotepad.Design;
using DevNotepad.GUI.Forms.Docking;
using DevNotepad.Library.Tools;
using DevNotepad.Models.Themes;
using DevNotepad.Tools;
using WeifenLuo.WinFormsUI.Docking;
using DevNotepad.Library.Extensions;
using DevNotepad.Models.Syntax;
using DevNotepad.Models;
using DevNotepad.PluginFramework.Interfaces;
using System.Diagnostics;

namespace DevNotepad.GUI.Forms
{
    public partial class FormMain : Form
    {
        private DeserializeDockContent _DeserializeDockContent;
        private FormFind _Find = null;

        private FormFindInFiles _FindInFiles = null;

        public FormMain()
        {
            InitializeComponent();
            Initialize();
            // Initialize the DocumentManager.
            
                
            DocumentManager.Initialize(this);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LanguageManager.InitializeControl(this);
            
            DockingPanel.Extender.FloatWindowFactory = new CustomFloatWindowFactory();
            SetupDocking();
        }


        #region Initialize Main Form

        private void Initialize()
        {
            Text = "DevNotepad Version: " + AssemblyTools.Version(Assembly.GetExecutingAssembly());
            
            InitThemes();
            InitLangs();
            // Force a resize.6
            FormMain_Resize(null, null);
        }

        #region Initialize Docking

        private void SetupDocking()
        {
            if (!SetupSavedDocking())
            {
                SetupDefaultDocking();
            }
        }

        private bool SetupSavedDocking()
        {
            try
            {
                
                if (File.Exists(Paths.DockingPath))
                {
                    FormProject formProject = new FormProject();
                    FormOpenDocs formOpenDOcs = new FormOpenDocs();
                    FormOutline formOutline = new FormOutline();
                    
                    FormFindInFiles formFindInFiles = new FormFindInFiles();
                    _DeserializeDockContent = new DeserializeDockContent(DockingManager.GetContentFromPersistString);
                    
                    DockingPanel.LoadFromXml(Paths.DockingPath, _DeserializeDockContent);
                    return true;
                }
            }
            catch(Exception ex)
            {
                Log.Write(ex);
            }
            return false;
        }

        private void SetupDefaultDocking()
        {
            try
            {
                
                FormProject formProject = new FormProject();
                formProject.Show(DockingPanel, DockState.DockRight);

                // Create the open files form.
                FormOpenDocs formOpenDocs = new FormOpenDocs();
                formOpenDocs.Show(DockingPanel, DockState.DockRight);

                // Create the database form.
                FormOutline formOutline = new FormOutline();
                formOutline.Show(formProject.Pane, DockAlignment.Bottom, .5);


                FormFindInFiles formFindInFiles = new FormFindInFiles();
                formFindInFiles.Show(DockingPanel, DockState.DockBottom);

            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }

        #endregion

        #region Initialize Language Schemes

        private void InitLangs()
        {
            foreach (Scheme scheme in Schemes.Highlighters)
            {
                AddScheme(scheme);
            }

        }

        /// <summary>
        /// Add a theme to menu item.
        /// </summary>
        /// <param name="preset"></param>
        private void AddScheme(Scheme scheme)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(scheme.Name);
            item.Tag = scheme;
            item.Click += (s, e) =>
            {
                try
                {
                    if (DocumentManager.ActiveDoc != null){
                        DocumentManager.ActiveDoc.SetStyle(scheme);                        
                    }
                }
                catch { }
            };
            MenuSyntax.DropDownItems.Add(item);
        }
        #endregion

        #region Initialize Themes

        /// <summary>
        /// Initialize themes
        /// </summary>
        private void InitThemes()
        {
            foreach (Theme preset in Themes.PresetList)
            {
                AddTheme(preset);
            }

            SetActiveTabStyle();
            //UpdateGUI(Themes.CurrentPreset);
        }

        private void SetActiveTabStyle()
        {
            // Finally get the current theme default backcolor if possible
            // and set the active document tab color to match and set fore
            // to inverse.
            try
            {
                PresetStyle preStyle = Themes.CurrentPreset.DefaultPreset; // Themes.CurrentPreset.Presets.Where(m => m.Key.Equals("default", StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault().Value;
                if (preStyle != null)
                {
                    if (!String.IsNullOrEmpty(preStyle.Back))
                    {
                        Color clr = preStyle.Back.ToColor();
                        if (clr != null)
                        {
                            DockingPanel.Skin.DockPaneStripSkin.DocumentGradient.ActiveTabGradient.StartColor = clr;
                            DockingPanel.Skin.DockPaneStripSkin.DocumentGradient.ActiveTabGradient.EndColor = clr;
                            DockingPanel.Skin.DockPaneStripSkin.DocumentGradient.ActiveTabGradient.TextColor = clr.Invert();
                            DockingPanel.Refresh();
                        }

                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Add a theme to menu item.
        /// </summary>
        /// <param name="preset"></param>
        private void AddTheme(Theme preset)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(preset.Name);
            item.Tag = preset;
            item.Click += (s, e) =>
            {
                try {
                    Theme pre = (Theme)item.Tag;
                    Themes.CurrentPreset = pre;
                    DocumentManager.UpdateStyle();
                    //UpdateGUI(pre);
                    SetActiveTabStyle();
                } catch {}
            };
            MenuThemes.DropDownItems.Add(item);
        }

        private void UpdateGUI(Theme pre)
        {
            try
            {
                if (!String.IsNullOrEmpty(pre.UITheme.TabBackGradientStart))
                {
                    DockingPanel.Skin.DockPaneStripSkin.DocumentGradient.DockStripGradient.StartColor = pre.UITheme.TabBackGradientStart.ToColor();
                    DockingPanel.Skin.DockPaneStripSkin.ToolWindowGradient.DockStripGradient.EndColor = pre.UITheme.TabBackGradientEnd.ToColor();
                }
                if (!String.IsNullOrEmpty(pre.UITheme.TabBackGradientStart))
                {
                    DockingPanel.Skin.DockPaneStripSkin.DocumentGradient.DockStripGradient.EndColor = pre.UITheme.TabBackGradientEnd.ToColor();
                    DockingPanel.Skin.DockPaneStripSkin.ToolWindowGradient.DockStripGradient.StartColor = pre.UITheme.TabBackGradientEnd.ToColor();
                }

                if (!String.IsNullOrEmpty(pre.UITheme.TabStart))
                {
                    DockingPanel.Skin.DockPaneStripSkin.DocumentGradient.InactiveTabGradient.StartColor = pre.UITheme.TabStart.ToColor();
                    DockingPanel.Skin.DockPaneStripSkin.ToolWindowGradient.InactiveTabGradient.EndColor = pre.UITheme.TabStart.ToColor();
                }

                if (!String.IsNullOrEmpty(pre.UITheme.TabEnd))
                {
                    DockingPanel.Skin.DockPaneStripSkin.DocumentGradient.InactiveTabGradient.EndColor = pre.UITheme.TabEnd.ToColor();
                    DockingPanel.Skin.DockPaneStripSkin.ToolWindowGradient.InactiveTabGradient.StartColor = pre.UITheme.TabEnd.ToColor();
                }

                if (!String.IsNullOrEmpty(pre.UITheme.ActiveTabStart))
                {
                    DockingPanel.Skin.DockPaneStripSkin.DocumentGradient.ActiveTabGradient.StartColor = pre.UITheme.ActiveTabStart.ToColor();


                    DockingPanel.Skin.DockPaneStripSkin.ToolWindowGradient.ActiveTabGradient.EndColor = pre.UITheme.ActiveTabStart.ToColor();
                }

                if (!String.IsNullOrEmpty(pre.UITheme.ActiveTabEnd))
                {
                    DockingPanel.Skin.DockPaneStripSkin.DocumentGradient.ActiveTabGradient.EndColor = pre.UITheme.ActiveTabEnd.ToColor();

                    DockingPanel.Skin.DockPaneStripSkin.ToolWindowGradient.ActiveTabGradient.StartColor = pre.UITheme.ActiveTabEnd.ToColor();
                }

                if (!String.IsNullOrEmpty(pre.UITheme.TabFore))
                {
                    DockingPanel.Skin.DockPaneStripSkin.DocumentGradient.ActiveTabGradient.TextColor = pre.UITheme.TabFore.ToColor();
                    DockingPanel.Skin.DockPaneStripSkin.ToolWindowGradient.ActiveTabGradient.TextColor = pre.UITheme.TabFore.ToColor();
                }

                if (!String.IsNullOrEmpty(pre.UITheme.ActiveTabFore))
                {
                    DockingPanel.Skin.DockPaneStripSkin.DocumentGradient.ActiveTabGradient.TextColor = pre.UITheme.ActiveTabFore.ToColor();
                    DockingPanel.Skin.DockPaneStripSkin.ToolWindowGradient.ActiveTabGradient.TextColor = pre.UITheme.ActiveTabFore.ToColor();
                }

                if (!String.IsNullOrEmpty(pre.UITheme.TitleStart))
                    DockingPanel.Skin.DockPaneStripSkin.ToolWindowGradient.InactiveCaptionGradient.StartColor = pre.UITheme.TitleStart.ToColor();

                if (!String.IsNullOrEmpty(pre.UITheme.TitleEnd))
                    DockingPanel.Skin.DockPaneStripSkin.ToolWindowGradient.InactiveCaptionGradient.EndColor = pre.UITheme.TitleEnd.ToColor();

                if (!String.IsNullOrEmpty(pre.UITheme.MainBG))
                {
                    DockingPanel.DockBackColor = pre.UITheme.MainBG.ToColor();
                    DockingPanel.BackColor = pre.UITheme.MainBG.ToColor();
                }

                DockingPanel.Refresh();
            }

            catch { }
        }

        #endregion

        #endregion

        #region Document

        #endregion

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DockingPanel.SaveAsXml(Paths.DockingPath);
        }

        private void DockingPanel_ActiveContentChanged(object sender, EventArgs e)
        {

        }

        

        private void FormMain_Resize(object sender, EventArgs e)
        {

            #region Center the loading panel.

            PanelLoading.Left = (this.ClientSize.Width - PanelLoading.Width) / 2;
            PanelLoading.Top = (this.ClientSize.Height - PanelLoading.Height) / 2;

            #endregion

        }


        private void FormMain_MdiChildActivate(object sender, EventArgs e)
        {
            DocumentManager.OnDocumentChanged((FormDocument)ActiveMdiChild);
        }

        #region External Access

        public void SetPosition(string text)
        {
            LabelPosition.Text = text;
        }

        #endregion


        #region Handle Loading Display

        /// <summary>
        /// Show the loader
        /// </summary>
        public void StartLoader()
        {
            
            PanelLoading.Visible = true;
        }


        /// <summary>
        /// Hide the loader
        /// </summary>
        public void FinishLoader()
        {
            PanelLoading.Visible = false;
        }

        /// <summary>
        /// Update the status
        /// </summary>
        /// <param name="displayText"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void UpdateLoader(string displayText, int min, int max)
        {
            LabelLoader.Text = displayText;
            ProgressLoader.Maximum = max;
            ProgressLoader.Value = min;
            PanelLoading.Refresh();
        }

        #endregion

        #region Handle Find in Files/Find in Documents

        public void FindInFiles(FindList findList)
        {
            // Make sure there is actually something to display
            if (findList == null || findList.Items == null || findList.Items.Count == 0)
                return;
            if (DockingManager.FindInFiles == null || DockingManager.FindInFiles.IsDisposed)
            {
                DockingManager.FindInFiles = new FormFindInFiles();
                DockingManager.FindInFiles.Show(DockingPanel, DockState.DockBottom);
            }

            if (DockingManager.FindInFiles != null)
            {
                if (DockingManager.FindInFiles.DockState == DockState.DockBottomAutoHide || DockingManager.FindInFiles.DockState == DockState.DockRightAutoHide ||
                    DockingManager.FindInFiles.DockState == DockState.DockLeftAutoHide || DockingManager.FindInFiles.DockState == DockState.DockTopAutoHide)
                {
                    DockingPanel.ActiveAutoHideContent = DockingManager.FindInFiles;
                    DockingManager.FindInFiles.Focus();
                }
                DockingManager.FindInFiles.Render(findList);
            }
        }
        #endregion

        #region Menu Events

        private void MenuNew_Click(object sender, EventArgs e)
        {
            this.NewDocument();
        }

        private void MenuOpen_Click(object sender, EventArgs e)
        {
            this.OpenFiles();
        }

        private void MenuSave_Click(object sender, EventArgs e)
        {
            if (DocumentManager.ActiveDoc != null)
                DocumentManager.ActiveDoc.Save();
        }

        private void MenuSaveAs_Click(object sender, EventArgs e)
        {
            if (DocumentManager.ActiveDoc != null)
                DocumentManager.ActiveDoc.SaveAs();
        }

        

        private void MenuUndo_Click(object sender, EventArgs e)
        {
            if (DocumentManager.ActiveDoc != null)
                DocumentManager.ActiveDoc.Undo();
        }

        private void MenuRedo_Click(object sender, EventArgs e)
        {
            if (DocumentManager.ActiveDoc != null)
                DocumentManager.ActiveDoc.Redo();
        }

        private void MenuCut_Click(object sender, EventArgs e)
        {
            if (DocumentManager.ActiveDoc != null)
                DocumentManager.ActiveDoc.Cut();
        }

        private void MenuCopy_Click(object sender, EventArgs e)
        {
            if (DocumentManager.ActiveDoc != null)
                DocumentManager.ActiveDoc.Copy();
        }

        private void MenuPaste_Click(object sender, EventArgs e)
        {
            if (DocumentManager.ActiveDoc != null)
                DocumentManager.ActiveDoc.Paste();
        }

        private void MenuDelete_Click(object sender, EventArgs e)
        {
            if (DocumentManager.ActiveDoc != null)
                DocumentManager.ActiveDoc.Delete();
        }        

        private void MenuDeleteWordLeft_Click(object sender, EventArgs e)
        {
            if (DocumentManager.ActiveDoc != null)
                DocumentManager.ActiveDoc.DeleteWordLeft();
        }

        private void MenuDeleteWordRight_Click(object sender, EventArgs e)
        {
            if (DocumentManager.ActiveDoc != null)
                DocumentManager.ActiveDoc.DeleteWordRight();
        }


        private void MenuSelectAll_Click(object sender, EventArgs e)
        {
            if (DocumentManager.ActiveDoc != null)
                DocumentManager.ActiveDoc.SelectAll();
        }

       

        private void MenuFind_Click(object sender, EventArgs e)
        {
            if (DocumentManager.ActiveDoc != null)
            {
                if (_Find == null || _Find.IsDisposed)
                {
                    _Find = new FormFind(DocumentManager.ActiveDoc);
                }

                if (_Find != null)
                {
                    if (!_Find.Visible)
                        _Find.Show(this);
                    else
                        _Find.BringToFront();
                }
            }
        }

        

        private void MenuFindNext_Click(object sender, EventArgs e)
        {
            if (DocumentManager.ActiveDoc != null)
                DocumentManager.ActiveDoc.FindNext();
        }

        private void MenuFindPrevious_Click(object sender, EventArgs e)
        {
            if (DocumentManager.ActiveDoc != null)
                DocumentManager.ActiveDoc.FindPrevious();
        }

        
        private void MenuReadme_Click(object sender, EventArgs e)
        {
            if (File.Exists(Paths.ReadmeFile))
                DocumentManager.OpenFile(this, Paths.ReadmeFile);
        }

        #endregion

        private void MenuAppConfig_Click(object sender, EventArgs e)
        {
            FormSettings settings = new FormSettings();
            if(settings.ShowDialog() == System.Windows.Forms.DialogResult.OK){

                Themes.SavePresets();

            }
        }

        private void MenuWebsite_Click(object sender, EventArgs e)
        {
            Process.Start("http://www.devnotepad.com/");
        }


    }
}
