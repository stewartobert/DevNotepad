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
using DevNotepad.UI.Controls;

namespace DevNotepad.GUI.Forms
{
    public partial class FormFind : Form
    {
        private FormDocument _Document;
        private int _LastDoc = -1;

        public FormFind(FormDocument document)
        {
            InitializeComponent();

            _Document = document;

            RadioSearchMode.InitializeRadioItems(new List<RadioItem>()
            {
                new RadioItem("{NORMAL}", false),
                new RadioItem("{EXTENDED}", true),
                new RadioItem("{REGULAREXPRESSION}", false)
            });

            RadioDirection.InitializeRadioItems(new List<RadioItem>()
            {
                new RadioItem("{UP}", false),
                new RadioItem("{DOWN}", true)
            });
        }

        private void TableLayout_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormFind_Load(object sender, EventArgs e)
        {
            FormState.ReadFormState(this);
            LanguageManager.InitializeControl(this);
            
        }

        private void TableSearch_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormFind_Activated(object sender, EventArgs e)
        {
            EditFind.SetFocus();
        }

        private void ButtonFindNext_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(EditFind.Text))
            {
                MessageBox.Show(LanguageManager.GetText("SEARCHSTRINGNULL"), "No Search Query", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_Document != null)
            {
                bool result = _Document.Find(EditFind.Text, CheckMatchWholeWord.Checked, CheckMatchCase.Checked, CheckWrap.Checked, RadioSearchMode.SelectedItem, RadioDirection.SelectedItem == 2);
                if (!result)
                {
                    
                        LabelStatus.Text = String.Format(LanguageManager.GetText("SEARCHNOTFOUND"), EditFind.Text);
                        return;
                }
                if (CheckClose.Checked)
                {
                    this.Close();
                }
                // Do the find  operation.
            }
        }

        private void FormFind_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormState.WriteFormState(this);
        }

        private void ButtonFindInOpenDocuments_Click(object sender, EventArgs e)
        {
            DocumentManager.FindInOpen(EditFind.Text, CheckMatchWholeWord.Checked, CheckMatchCase.Checked, RadioSearchMode.SelectedItem);
            if (CheckClose.Checked)
            {
                this.Close();
            }
            //bool result = false;
            //if (_Document != null)
            //{
            //    result = _Document.Find(EditFind.Text, CheckMatchWholeWord.Checked, CheckMatchCase.Checked, false, RadioSearchMode.SelectedItem, true, false);
            //}
            //if (!result)
            //{
            //    if (_LastDoc >= (DocumentManager.Documents.Count - 1))
            //    {
            //        _LastDoc = -1;
            //    }
            //    for(int i = _LastDoc+1; i < DocumentManager.Documents.Count; i++){
            //        FormDocument document = DocumentManager.Documents[i];
            //        result = document.Find(EditFind.Text, CheckMatchWholeWord.Checked, CheckMatchCase.Checked, false, RadioSearchMode.SelectedItem, true, true);
            //        if (result)
            //        {
            //            document.BringToFront();
            //            _LastDoc = i;
            //            break;
            //        }
            //    }
            //}
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
