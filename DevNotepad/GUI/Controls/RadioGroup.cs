using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DevNotepad.UI.Controls
{
    public partial class RadioGroup : GroupBox
    {
        public int SelectedItem
        {
            get
            {
                foreach (var control in this.Controls)
                {
                    if (control is RadioButton)
                    {
                        if (((RadioButton)control).Checked)
                        {
                            return (int)((RadioButton)control).Tag;
                        }
                    }
                }
                return -1;
            }
            set
            {
                foreach (var control in this.Controls)
                {
                    if (control is RadioButton)
                    {
                        if (((int)((RadioButton)control).Tag) == value)
                        {
                            ((RadioButton)control).Checked = true;
                        }
                        else
                        {
                            ((RadioButton)control).Checked = false;
                        }
                    }
                }
            }
        }
        public List<RadioItem> Items { get; set; }
        
        public RadioGroup()
        {
            InitializeComponent();
            this.Padding = new Padding(8);
        }

        public void InitializeRadioItems(List<RadioItem> items)
        {
            Items = items;
            GenerateRadioItems();
        }

        private void GenerateRadioItems()
        {
            int tag = 0;
            foreach (RadioItem item in Items)
            {
                tag++;
                RadioButton button = new RadioButton();
                button.Parent = this;
                button.Checked = item.Selected;
                button.Margin = new Padding(0);
                button.Padding = new Padding(0);
                button.Text = item.Text;
                button.Dock = DockStyle.Top;
                button.Visible = true;
                button.Size = new Size(100, 18);
                button.Tag = tag;

            }
        }

        private void RadioGroup_Load(object sender, EventArgs e)
        {

        }
    }

    public class RadioItem
    {
        public string Text { get; set; }
        public bool Selected { get; set; }
        public RadioItem(string text, bool selected)
        {
            Text = text;
            Selected = selected;
        }
    }
}
