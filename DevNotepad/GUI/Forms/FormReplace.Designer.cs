namespace DevNotepad.GUI.Forms
{
    partial class FormReplace
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CheckWrap = new System.Windows.Forms.CheckBox();
            this.CheckMatchWholeWord = new System.Windows.Forms.CheckBox();
            this.RadioDirection = new DevNotepad.UI.Controls.RadioGroup();
            this.RadioSearchMode = new DevNotepad.UI.Controls.RadioGroup();
            this.TableSearchOptions = new System.Windows.Forms.TableLayoutPanel();
            this.CheckClose = new System.Windows.Forms.CheckBox();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonFindAll = new System.Windows.Forms.Button();
            this.ButtonFindInOpenDocuments = new System.Windows.Forms.Button();
            this.EditFind = new DevNotepad.GUI.Controls.LabelCombo();
            this.PanelMatch = new System.Windows.Forms.Panel();
            this.CheckMatchCase = new System.Windows.Forms.CheckBox();
            this.ButtonCount = new System.Windows.Forms.Button();
            this.ButtonFindNext = new System.Windows.Forms.Button();
            this.TableButtons = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.TableSearch = new System.Windows.Forms.TableLayoutPanel();
            this.LabelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.LabelDetails = new System.Windows.Forms.ToolStripStatusLabel();
            this.Status = new System.Windows.Forms.StatusStrip();
            this.TableSearchOptions.SuspendLayout();
            this.PanelMatch.SuspendLayout();
            this.TableButtons.SuspendLayout();
            this.TableLayout.SuspendLayout();
            this.TableSearch.SuspendLayout();
            this.Status.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckWrap
            // 
            this.CheckWrap.AutoSize = true;
            this.CheckWrap.Checked = true;
            this.CheckWrap.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckWrap.Location = new System.Drawing.Point(14, 52);
            this.CheckWrap.Name = "CheckWrap";
            this.CheckWrap.Size = new System.Drawing.Size(114, 17);
            this.CheckWrap.TabIndex = 3;
            this.CheckWrap.Text = "{WRAPAROUND}";
            this.CheckWrap.UseVisualStyleBackColor = true;
            // 
            // CheckMatchWholeWord
            // 
            this.CheckMatchWholeWord.AutoSize = true;
            this.CheckMatchWholeWord.Location = new System.Drawing.Point(14, 10);
            this.CheckMatchWholeWord.Name = "CheckMatchWholeWord";
            this.CheckMatchWholeWord.Size = new System.Drawing.Size(176, 17);
            this.CheckMatchWholeWord.TabIndex = 1;
            this.CheckMatchWholeWord.Text = "{MATCHWHOLEWORDONLY}";
            this.CheckMatchWholeWord.UseVisualStyleBackColor = true;
            // 
            // RadioDirection
            // 
            this.RadioDirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RadioDirection.Items = null;
            this.RadioDirection.Location = new System.Drawing.Point(319, 3);
            this.RadioDirection.Name = "RadioDirection";
            this.RadioDirection.Padding = new System.Windows.Forms.Padding(8);
            this.RadioDirection.SelectedItem = -1;
            this.RadioDirection.Size = new System.Drawing.Size(130, 85);
            this.RadioDirection.TabIndex = 1;
            this.RadioDirection.TabStop = false;
            this.RadioDirection.Text = "&Direction";
            // 
            // RadioSearchMode
            // 
            this.RadioSearchMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RadioSearchMode.Items = null;
            this.RadioSearchMode.Location = new System.Drawing.Point(3, 3);
            this.RadioSearchMode.Name = "RadioSearchMode";
            this.RadioSearchMode.Padding = new System.Windows.Forms.Padding(8);
            this.RadioSearchMode.SelectedItem = -1;
            this.RadioSearchMode.Size = new System.Drawing.Size(310, 85);
            this.RadioSearchMode.TabIndex = 0;
            this.RadioSearchMode.TabStop = false;
            this.RadioSearchMode.Text = "Search &Mode";
            // 
            // TableSearchOptions
            // 
            this.TableSearchOptions.ColumnCount = 2;
            this.TableSearchOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.TableSearchOptions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.TableSearchOptions.Controls.Add(this.RadioDirection, 1, 0);
            this.TableSearchOptions.Controls.Add(this.RadioSearchMode, 0, 0);
            this.TableSearchOptions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TableSearchOptions.Location = new System.Drawing.Point(0, 100);
            this.TableSearchOptions.Name = "TableSearchOptions";
            this.TableSearchOptions.RowCount = 1;
            this.TableSearchOptions.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableSearchOptions.Size = new System.Drawing.Size(452, 91);
            this.TableSearchOptions.TabIndex = 6;
            // 
            // CheckClose
            // 
            this.CheckClose.AutoSize = true;
            this.CheckClose.Location = new System.Drawing.Point(3, 163);
            this.CheckClose.Name = "CheckClose";
            this.CheckClose.Size = new System.Drawing.Size(134, 17);
            this.CheckClose.TabIndex = 8;
            this.CheckClose.TabStop = false;
            this.CheckClose.Text = "{CLOSEWHENDONE}";
            this.CheckClose.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCancel.Location = new System.Drawing.Point(2, 130);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(158, 28);
            this.ButtonCancel.TabIndex = 6;
            this.ButtonCancel.Text = "{CANCEL}";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // ButtonFindAll
            // 
            this.ButtonFindAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonFindAll.Location = new System.Drawing.Point(2, 98);
            this.ButtonFindAll.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonFindAll.Name = "ButtonFindAll";
            this.ButtonFindAll.Size = new System.Drawing.Size(158, 28);
            this.ButtonFindAll.TabIndex = 5;
            this.ButtonFindAll.Text = "{FINDALL}";
            this.ButtonFindAll.UseVisualStyleBackColor = true;
            // 
            // ButtonFindInOpenDocuments
            // 
            this.ButtonFindInOpenDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonFindInOpenDocuments.Location = new System.Drawing.Point(2, 34);
            this.ButtonFindInOpenDocuments.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonFindInOpenDocuments.Name = "ButtonFindInOpenDocuments";
            this.ButtonFindInOpenDocuments.Size = new System.Drawing.Size(158, 28);
            this.ButtonFindInOpenDocuments.TabIndex = 4;
            this.ButtonFindInOpenDocuments.Text = "{FINDINOPENDOCUMENTS}";
            this.ButtonFindInOpenDocuments.UseVisualStyleBackColor = true;
            // 
            // EditFind
            // 
            this.EditFind.Caption = "&Find What:";
            this.EditFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditFind.LabelLayout = DevNotepad.GUI.Controls.LabelLayout.LeftAlign;
            this.EditFind.Location = new System.Drawing.Point(5, 5);
            this.EditFind.Margin = new System.Windows.Forms.Padding(5);
            this.EditFind.MinimumSize = new System.Drawing.Size(300, 0);
            this.EditFind.Name = "EditFind";
            this.EditFind.Padding = new System.Windows.Forms.Padding(3);
            this.EditFind.Size = new System.Drawing.Size(448, 27);
            this.EditFind.TabIndex = 2;
            // 
            // PanelMatch
            // 
            this.PanelMatch.Controls.Add(this.TableSearchOptions);
            this.PanelMatch.Controls.Add(this.CheckWrap);
            this.PanelMatch.Controls.Add(this.CheckMatchCase);
            this.PanelMatch.Controls.Add(this.CheckMatchWholeWord);
            this.PanelMatch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMatch.Location = new System.Drawing.Point(3, 40);
            this.PanelMatch.Name = "PanelMatch";
            this.PanelMatch.Size = new System.Drawing.Size(452, 191);
            this.PanelMatch.TabIndex = 3;
            // 
            // CheckMatchCase
            // 
            this.CheckMatchCase.AutoSize = true;
            this.CheckMatchCase.Location = new System.Drawing.Point(14, 31);
            this.CheckMatchCase.Name = "CheckMatchCase";
            this.CheckMatchCase.Size = new System.Drawing.Size(100, 17);
            this.CheckMatchCase.TabIndex = 2;
            this.CheckMatchCase.Text = "{MATCHCASE}";
            this.CheckMatchCase.UseVisualStyleBackColor = true;
            // 
            // ButtonCount
            // 
            this.ButtonCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCount.Location = new System.Drawing.Point(2, 66);
            this.ButtonCount.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonCount.Name = "ButtonCount";
            this.ButtonCount.Size = new System.Drawing.Size(158, 28);
            this.ButtonCount.TabIndex = 3;
            this.ButtonCount.Text = "{COUNT}";
            this.ButtonCount.UseVisualStyleBackColor = true;
            // 
            // ButtonFindNext
            // 
            this.ButtonFindNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonFindNext.Location = new System.Drawing.Point(2, 2);
            this.ButtonFindNext.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonFindNext.Name = "ButtonFindNext";
            this.ButtonFindNext.Size = new System.Drawing.Size(158, 28);
            this.ButtonFindNext.TabIndex = 2;
            this.ButtonFindNext.Text = "{FINDNEXT}";
            this.ButtonFindNext.UseVisualStyleBackColor = true;
            // 
            // TableButtons
            // 
            this.TableButtons.ColumnCount = 1;
            this.TableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableButtons.Controls.Add(this.CheckClose, 0, 5);
            this.TableButtons.Controls.Add(this.ButtonCancel, 0, 3);
            this.TableButtons.Controls.Add(this.ButtonFindAll, 0, 2);
            this.TableButtons.Controls.Add(this.ButtonFindInOpenDocuments, 0, 1);
            this.TableButtons.Controls.Add(this.ButtonCount, 0, 1);
            this.TableButtons.Controls.Add(this.ButtonFindNext, 0, 0);
            this.TableButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableButtons.Location = new System.Drawing.Point(467, 3);
            this.TableButtons.MaximumSize = new System.Drawing.Size(0, 185);
            this.TableButtons.Name = "TableButtons";
            this.TableButtons.RowCount = 6;
            this.TableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.TableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.TableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.TableButtons.Size = new System.Drawing.Size(162, 185);
            this.TableButtons.TabIndex = 0;
            // 
            // TableLayout
            // 
            this.TableLayout.ColumnCount = 2;
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.TableLayout.Controls.Add(this.TableButtons, 1, 0);
            this.TableLayout.Controls.Add(this.TableSearch, 0, 0);
            this.TableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayout.Location = new System.Drawing.Point(0, 0);
            this.TableLayout.Name = "TableLayout";
            this.TableLayout.RowCount = 1;
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 215F));
            this.TableLayout.Size = new System.Drawing.Size(632, 240);
            this.TableLayout.TabIndex = 3;
            // 
            // TableSearch
            // 
            this.TableSearch.ColumnCount = 1;
            this.TableSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableSearch.Controls.Add(this.EditFind, 0, 0);
            this.TableSearch.Controls.Add(this.PanelMatch, 0, 1);
            this.TableSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableSearch.Location = new System.Drawing.Point(3, 3);
            this.TableSearch.Name = "TableSearch";
            this.TableSearch.RowCount = 2;
            this.TableSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.TableSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableSearch.Size = new System.Drawing.Size(458, 234);
            this.TableSearch.TabIndex = 1;
            // 
            // LabelStatus
            // 
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // LabelDetails
            // 
            this.LabelDetails.Name = "LabelDetails";
            this.LabelDetails.Size = new System.Drawing.Size(0, 17);
            // 
            // Status
            // 
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelDetails,
            this.LabelStatus});
            this.Status.Location = new System.Drawing.Point(0, 240);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(632, 22);
            this.Status.TabIndex = 2;
            this.Status.Text = "Status";
            // 
            // FormReplace
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 262);
            this.Controls.Add(this.TableLayout);
            this.Controls.Add(this.Status);
            this.Name = "FormReplace";
            this.Text = "FormReplace";
            this.TableSearchOptions.ResumeLayout(false);
            this.PanelMatch.ResumeLayout(false);
            this.PanelMatch.PerformLayout();
            this.TableButtons.ResumeLayout(false);
            this.TableButtons.PerformLayout();
            this.TableLayout.ResumeLayout(false);
            this.TableSearch.ResumeLayout(false);
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CheckWrap;
        private System.Windows.Forms.CheckBox CheckMatchWholeWord;
        private UI.Controls.RadioGroup RadioDirection;
        private UI.Controls.RadioGroup RadioSearchMode;
        private System.Windows.Forms.TableLayoutPanel TableSearchOptions;
        private System.Windows.Forms.CheckBox CheckClose;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonFindAll;
        private System.Windows.Forms.Button ButtonFindInOpenDocuments;
        private Controls.LabelCombo EditFind;
        private System.Windows.Forms.Panel PanelMatch;
        private System.Windows.Forms.CheckBox CheckMatchCase;
        private System.Windows.Forms.Button ButtonCount;
        private System.Windows.Forms.Button ButtonFindNext;
        private System.Windows.Forms.TableLayoutPanel TableButtons;
        private System.Windows.Forms.TableLayoutPanel TableLayout;
        private System.Windows.Forms.TableLayoutPanel TableSearch;
        private System.Windows.Forms.ToolStripStatusLabel LabelStatus;
        private System.Windows.Forms.ToolStripStatusLabel LabelDetails;
        private System.Windows.Forms.StatusStrip Status;
    }
}