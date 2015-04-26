using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevNotepad.GUI.Controls
{
    
    public partial class LabelCombo : UserControl
    {

        private LabelLayout _LabelLayout = LabelLayout.TopAlign;
        /// <summary>
        /// Set the Layuout of the label. Also adjusts the height of the
        /// control to properly fit the label/combo depending on the current
        /// layout.
        /// </summary>
        public LabelLayout LabelLayout
        {
            get
            {
                return _LabelLayout;
            }
            set
            {
                _LabelLayout = value;
                if (_LabelLayout == GUI.Controls.LabelLayout.LeftAlign)
                {
                    LabelText.Dock = DockStyle.Left;
                    LabelText.AutoSize = true;
                }
                else
                {
                    LabelText.Dock = DockStyle.Top;
                    LabelText.AutoSize = false;
                }
                // Resize the control.
                
                LabelCombo_Resize(null, null);
            }
        }

        /// <summary>
        /// Label caption.
        /// </summary>
        public string Caption
        {
            get
            {
                return LabelText.Text;
            }
            set
            {
                LabelText.Text = value;
            }
        }



        /// <summary>
        /// Combobox text.
        /// </summary>
        public string Text
        {
            get
            {
                return Combo.Text;
            }
            set
            {
                Combo.Text = value;
            }
        }


        /// <summary>
        /// Access the combo box items directly.
        /// </summary>
        System.Windows.Forms.ComboBox.ObjectCollection Items
        {
            get
            {
                return Combo.Items;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public LabelCombo()
        {
            InitializeComponent();
        }

        private void LabelCombo_Resize(object sender, EventArgs e)
        {
            if (_LabelLayout == GUI.Controls.LabelLayout.LeftAlign)
            {
                Size = new Size(Size.Width, Combo.Height + Padding.Top + Padding.Bottom);
                int calcPadding = ((int)Math.Ceiling((decimal)((Size.Height - LabelText.Height) / 2) / 2));
                LabelText.Padding = new Padding(5, calcPadding, 20, 0);
            }
            else
            {
                
                Size = new Size(Size.Width, Combo.Height + LabelText.Height + Padding.Top + Padding.Bottom);
            }
        }

        private void LabelCombo_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Resize if padding changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelCombo_PaddingChanged(object sender, EventArgs e)
        {
            LabelCombo_Resize(null, null);
        }

        private void LabelText_Click(object sender, EventArgs e)
        {
            Combo.Focus();
        }

        public void SetFocus()
        {
            Combo.Focus();
        }
    }
}
