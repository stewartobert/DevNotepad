using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevNotepad.Library.Controls;

namespace DevNotepad.GUI.Controls
{
    /// <summary>
    /// Just an small extension on the Listbox to double buffer for the custom drawing.
    /// </summary>
    public class DoubleBufferedListBox : ListBox
    {

        public DoubleBufferedListBox()
            : base()
        {
            DoubleBuffered = true;
        }

        #region Method Overrides
        /// <summary>
        /// Override OnTemplateListDrawItem to supply an off-screen buffer to event
        /// handlers.
        /// </summary>
        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;

            Rectangle newBounds = new Rectangle(0, 0, e.Bounds.Width, e.Bounds.Height);
            using (BufferedGraphics bufferedGraphics = currentContext.Allocate(e.Graphics, newBounds))
            {
                DrawItemEventArgs newArgs = new DrawItemEventArgs(
                    bufferedGraphics.Graphics, e.Font, newBounds, e.Index, e.State, e.ForeColor, e.BackColor);

                // Supply the real OnTemplateListDrawItem with the off-screen graphics context
                base.OnDrawItem(newArgs);

                // Wrapper around BitBlt
                GDI.CopyGraphics(e.Graphics, e.Bounds, bufferedGraphics.Graphics, new Point(0, 0));
            }
        }
        #endregion
    }
}
