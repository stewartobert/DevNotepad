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
using DevNotepad.Tools;
using DevNotepad.Library.Extensions;

namespace DevNotepad.GUI.Forms.Docking
{
    public partial class FormOpenDocs : WeifenLuo.WinFormsUI.Docking.DockContent
    {
        private Color _ForeColor = Color.Black;
        private Color _SelForeColor = Color.Black; //Color.FromArgb(255, 143,221,255);

        private Color _SelBorderTop = Color.FromArgb(193, 199, 207).Lerp(Color.Black, .08f);
        private Color _SelBorderBottom = Color.FromArgb(193, 199, 207).Lerp(Color.White, .7f);

        public FormOpenDocs()
        {
            InitializeComponent();

            #region Handle Document events

            // Subscribe to the DocumentManagers delegates
            DocumentManager.DocCreated += DocumentManager_DocCreated;
            DocumentManager.DocClosed += DocumentManager_DocClosed;
            DocumentManager.DocChanged += DocumentManager_DocChanged;

            #endregion


            #region Handle Theme Events

            Themes.ThemeChanged += Themes_ThemeChanged;

            #endregion
        }

        void Themes_ThemeChanged(Models.Themes.Theme ActiveTheme, EventArgs e)
        {
            if (!String.IsNullOrEmpty(ActiveTheme.UITheme.WindowSelectFore))
                _SelForeColor = ActiveTheme.UITheme.WindowSelectFore.ToColor("#ffffff");

            if (!String.IsNullOrEmpty(ActiveTheme.UITheme.WindowFore))
            {
                _ForeColor = ActiveTheme.UITheme.WindowFore.ToColor("#000000");
                EditFilter.ForeColor = ActiveTheme.UITheme.WindowFore.ToColor("#000000");
            }

            if (!String.IsNullOrEmpty(ActiveTheme.UITheme.WindowBG))
            {
                BackColor = ActiveTheme.UITheme.WindowBG.ToColor("#ffffff");
                PanelBottom.BackColor = ActiveTheme.UITheme.WindowBG.ToColor("#ffffff");
                ListFiles.BackColor = ActiveTheme.UITheme.WindowBG.ToColor("#ffffff");
                PanelTop.BackColor = ActiveTheme.UITheme.WindowBG.ToColor("#ffffff");

                EditFilter.BackColor = ActiveTheme.UITheme.WindowBG.ToColor("#ffffff");
                
            }



        }

        void DocumentManager_DocChanged(FormDocument doc, EventArgs e)
        {
            if (doc != null)
            {
                ListFiles.SelectedItem = doc;
            }
        }

        void DocumentManager_DocClosed(FormDocument doc, EventArgs e)
        {
            ListFiles.Items.Remove(doc);
        }

        void DocumentManager_DocCreated(FormDocument doc, EventArgs e)
        {
            ListFiles.BeginUpdate();
            ListFiles.Items.Add(doc);
            ListFiles.SelectedItem = doc;
            ListFiles.EndUpdate();
        }

        private void ListFiles_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 24;
        }

        private void ListFiles_DrawItem(object sender, DrawItemEventArgs e)
        {
            bool isItemSelected = ((e.State & DrawItemState.Selected) == DrawItemState.Selected);
            
            e.DrawBackground();

            if (isItemSelected)
            {
                using (SolidBrush brushFill = new SolidBrush(Color.FromArgb(193,199,207)))
                {

                    e.Graphics.FillRectangle(brushFill, e.Bounds);
                }
                using (Pen brushLine = new Pen(_SelBorderTop))
                {
                    e.Graphics.DrawLine(brushLine, new Point(e.Bounds.X, e.Bounds.Y), new Point(e.Bounds.Right, e.Bounds.Y));
                }

                using (Pen brushLine = new Pen(_SelBorderBottom))
                {
                    e.Graphics.DrawLine(brushLine, new Point(e.Bounds.X, e.Bounds.Bottom), new Point(e.Bounds.Right, e.Bounds.Bottom));
                }
            }

            //e.DrawFocusRectangle();
            Color PaintColor;
            Font displayFont = null;
            if (isItemSelected)
            {
                PaintColor = _SelForeColor;
                displayFont = new Font(ListFiles.Font, FontStyle.Bold);
            }
            else
            {
                PaintColor = _ForeColor;
                displayFont = new Font(ListFiles.Font, FontStyle.Regular);
            }
            Rectangle rec = new Rectangle(
                e.Bounds.X + 36,
                e.Bounds.Y + 5,
                e.Bounds.Width,
                e.Bounds.Height
            );

            Rectangle iconRec = new Rectangle(
                e.Bounds.X + 9,
                e.Bounds.Y + 2,
                18, 18
            );


            using (Bitmap bitmap = ((FormDocument)ListFiles.Items[e.Index]).Icon.ToBitmap())
            {
                e.Graphics.DrawImage(bitmap, iconRec);
            }

            using (SolidBrush brush = new SolidBrush(PaintColor))
            {
                e.Graphics.DrawString(((FormDocument)ListFiles.Items[e.Index]).TabText, displayFont, brush, rec);
            }

            
            
        }

        private void ListFiles_Click(object sender, EventArgs e)
        {
            try
            {
                FormDocument doc = (FormDocument)ListFiles.SelectedItem;
                doc.BringToFront();
                ListFiles.Focus();
            }
            catch { }
        }

        private void EditFilter_TextAlignChanged(object sender, EventArgs e)
        {
            
        }

        private void EditFilter_TextChanged(object sender, EventArgs e)
        {
            if (EditFilter.Text == EditFilter.PlaceholderText)
                return;
            ListFiles.BeginUpdate();
            ListFiles.Items.Clear();
            if (String.IsNullOrEmpty(EditFilter.Text))
            {
                ListFiles.Items.Clear();
                ListFiles.Items.AddRange(DocumentManager._Documents.ToArray());
            }
            else
            {
                foreach (FormDocument doc in DocumentManager._Documents)
                {
                    if (doc.ToString().ToLowerInvariant().Contains(EditFilter.Text.ToLowerInvariant()))
                    {
                        ListFiles.Items.Add(doc);
                    }
                }
            }
            ListFiles.EndUpdate();
        }

        private void PanelTop_Click(object sender, EventArgs e)
        {
            EditFilter.Focus();
        }

        private void ListFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ListFiles.Invalidate();
        }
    }
}
