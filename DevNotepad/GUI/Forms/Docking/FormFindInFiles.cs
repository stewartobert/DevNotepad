using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevNotepad.Debug;
using DevNotepad.Models;

namespace DevNotepad.GUI.Forms.Docking
{
    public partial class FormFindInFiles : WeifenLuo.WinFormsUI.Docking.DockContent
    {

        /// <summary>
        /// Internal track the text being found.
        /// </summary>
        string _findText = String.Empty;

        /// <summary>
        /// Internal track the length of the text being found
        /// </summary>
        int _findLength = 0;

        public FormFindInFiles()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Render a list of findItems (Works for both Find in Open documents and Find in Files)
        /// </summary>
        /// <param name="findItems"></param>
        public void Render(FindList findItems)
        {
            _findText = findItems.Find;
            _findLength = _findText.Length;
            TreeFind.BeginUpdate();
            TreeFind.Nodes.Clear();
            try
            {
                FindItem lastItem = null;
                TreeNode parentNode = null;
                foreach (FindItem item in findItems.Items)
                {
                    if (lastItem == null || lastItem.FileName != item.FileName || lastItem.Document != item.Document)
                    {
                        parentNode = new TreeNode(item.Name);
                        TreeFind.Nodes.Add(parentNode);
                    }

                    TreeNode node = new TreeNode(item.Text);
                    node.Tag = item;

                    parentNode.Nodes.Add(node);
                    lastItem = item;
                }


                // Expand all results.
                TreeFind.ExpandAll();
            }
            catch { }
            TreeFind.EndUpdate();
        }

        /// <summary>
        /// Manage the node drawing so the node can be pained specially for the specific string being processed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeFind_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {

            Rectangle rect = new Rectangle(e.Bounds.X, e.Bounds.Y, TreeFind.ClientSize.Width, e.Bounds.Height);
            if (e.Node.Nodes != null && e.Node.Nodes.Count > 0)
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 213, 255, 213)))
                {
                    e.Graphics.FillRectangle(brush, rect);
                }
                
            }

            else
            {
                if (e.Node.IsSelected)
                {
                    //LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Navy, Color.Black, 90);
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(255, 51, 153, 255)))
                    {
                        e.Graphics.FillRectangle(brush, rect);
                    }
                }
            }


            Int32 boxSize = 16;
            Int32 offset = e.Node.Parent == null ? 3 : 21;

            Rectangle bounds = new Rectangle(new Point(e.Bounds.X + offset, e.Bounds.Y + 1), new Size(boxSize, boxSize));
            using (Font font = new Font("Courier New", 10, e.Node.Parent == null ? FontStyle.Bold : FontStyle.Regular))
            {

                bounds = new Rectangle(new Point(bounds.X + boxSize + 2, e.Bounds.Y), new Size(e.Bounds.Width - offset - 2, boxSize));
                if (e.Node.Parent == null)
                    e.Graphics.DrawString(e.Node.Text, font, Brushes.DarkGreen, rect);
                else
                    WriteText(e.Graphics, (FindItem)e.Node.Tag, rect, e.Node.IsSelected);
            }
        }

        private int getRealCol(FindItem item)
        {
            int col = 0;
            for (int i = 0; i < item.ColStart; i++)
            {
                if (item.Text[i] == '\t')
                    col += item.TabWidth;
                else
                    col++;
                if (col >= item.ColStart+1)
                    return i;
            }
            return item.ColStart;
        }

        /// <summary>
        /// Draw formatted text to the treeview with the search string highlighted in red.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="item"></param>
        /// <param name="rect"></param>
        /// <param name="selected"></param>
        private void WriteText(Graphics graphics, FindItem item, Rectangle rect, bool selected)
        {
            try
            {
                int colStart = getRealCol(item);
                // Get the string up to the find text
                string startString = item.Text.Substring(0, colStart);

                // Get the string after the find text
                string endString = item.Text.Substring(colStart + _findLength);


                using (Font fontNormal = new Font("Courier New", 10, FontStyle.Regular))
                {
                    using (Font fontResult = new Font("Courier New", 10, FontStyle.Bold))
                    {

                        graphics.DrawString(startString, fontNormal, (selected ? Brushes.White : Brushes.Black), rect);

                        // Modify the rect to place to the new place
                        SizeF dif = graphics.MeasureString(startString, fontNormal);

                        rect.X += (int)Math.Floor(dif.Width);

                        graphics.DrawString(item.Text.Substring(colStart, _findLength), fontResult, Brushes.Red, rect);

                        dif = graphics.MeasureString(_findText, fontNormal);

                        rect.X += (int)Math.Floor(dif.Width);

                        graphics.DrawString(endString, fontNormal, (selected ? Brushes.White : Brushes.Black), rect);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex);
            }
        }

        /// <summary>
        /// Bring the document into focus and set the position of the cursor to match the selected
        /// position of the found text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeFind_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                TreeNode node = TreeFind.SelectedNode;
                if (node != null)
                {
                    FindItem find = (FindItem)node.Tag;
                    if (find != null)
                    {
                        if (find.Document != null)
                        {
                            find.Document.BringToFront();
                            find.Document.SetSel(find.StartPos, find.EndPos, true);
                            find.Document.FocusEditor();
                        }
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// Handle the mousedown event so that the proper node can be selected no matter where
        /// the user clicks.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeFind_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                TreeNode node = TreeFind.GetNodeAt(new Point(10, e.Y));
                if (node != null)
                {
                    TreeFind.SelectedNode = node;
                }
            }
            catch { }
        }
    }
}
