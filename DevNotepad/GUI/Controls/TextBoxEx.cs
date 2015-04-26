using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevNotepad.GUI.Controls
{
    public class TextBoxEx : TextBox
    {

        public TextBoxEx()
            : base()
        {
            this.ShortcutsEnabled = true;
            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (this.Focused)
            {

                switch (keyData)
                {
                    case Keys.Control | Keys.A:
                        this.SelectAll();
                        return true;
                    case Keys.Control | Keys.C:
                        this.Copy();
                        return true;
                    case Keys.Control | Keys.V:
                        this.Paste();
                        return true;
                    case Keys.Control | Keys.X:
                        this.Cut();
                        return true;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            

           
            base.OnKeyDown(e);
        }

    }
}
