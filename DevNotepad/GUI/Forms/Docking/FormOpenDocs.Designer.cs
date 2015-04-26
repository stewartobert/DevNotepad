namespace DevNotepad.GUI.Forms.Docking
{
    partial class FormOpenDocs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOpenDocs));
            this.PanelBottom = new System.Windows.Forms.Panel();
            this.ListFiles = new DevNotepad.GUI.Controls.DoubleBufferedListBox();
            this.PanelTop = new System.Windows.Forms.Panel();
            this.PanelBorder = new System.Windows.Forms.Panel();
            this.EditFilter = new DevNotepad.GUI.Controls.PlaceholderTextBox();
            this.PanelBottom.SuspendLayout();
            this.PanelTop.SuspendLayout();
            this.PanelBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelBottom
            // 
            this.PanelBottom.BackColor = System.Drawing.Color.White;
            this.PanelBottom.Controls.Add(this.ListFiles);
            this.PanelBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelBottom.Location = new System.Drawing.Point(0, 47);
            this.PanelBottom.Name = "PanelBottom";
            this.PanelBottom.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.PanelBottom.Size = new System.Drawing.Size(284, 215);
            this.PanelBottom.TabIndex = 1;
            // 
            // ListFiles
            // 
            this.ListFiles.BackColor = System.Drawing.Color.White;
            this.ListFiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ListFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListFiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.ListFiles.ForeColor = System.Drawing.SystemColors.Info;
            this.ListFiles.Location = new System.Drawing.Point(0, 5);
            this.ListFiles.Name = "ListFiles";
            this.ListFiles.Size = new System.Drawing.Size(284, 210);
            this.ListFiles.TabIndex = 2;
            this.ListFiles.Click += new System.EventHandler(this.ListFiles_Click);
            this.ListFiles.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ListFiles_DrawItem);
            this.ListFiles.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.ListFiles_MeasureItem);
            this.ListFiles.SelectedIndexChanged += new System.EventHandler(this.ListFiles_SelectedIndexChanged);
            // 
            // PanelTop
            // 
            this.PanelTop.AutoSize = true;
            this.PanelTop.BackColor = System.Drawing.Color.White;
            this.PanelTop.Controls.Add(this.PanelBorder);
            this.PanelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTop.Location = new System.Drawing.Point(0, 0);
            this.PanelTop.Name = "PanelTop";
            this.PanelTop.Padding = new System.Windows.Forms.Padding(10);
            this.PanelTop.Size = new System.Drawing.Size(284, 47);
            this.PanelTop.TabIndex = 3;
            // 
            // PanelBorder
            // 
            this.PanelBorder.BackColor = System.Drawing.Color.White;
            this.PanelBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelBorder.Controls.Add(this.EditFilter);
            this.PanelBorder.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelBorder.Location = new System.Drawing.Point(10, 10);
            this.PanelBorder.Name = "PanelBorder";
            this.PanelBorder.Padding = new System.Windows.Forms.Padding(7);
            this.PanelBorder.Size = new System.Drawing.Size(264, 27);
            this.PanelBorder.TabIndex = 1;
            // 
            // EditFilter
            // 
            this.EditFilter.BackColor = System.Drawing.Color.White;
            this.EditFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EditFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditFilter.Location = new System.Drawing.Point(7, 7);
            this.EditFilter.Name = "EditFilter";
            this.EditFilter.PlaceholderText = "Filter open documents";
            this.EditFilter.Size = new System.Drawing.Size(248, 13);
            this.EditFilter.TabIndex = 0;
            this.EditFilter.TextChanged += new System.EventHandler(this.EditFilter_TextChanged);
            // 
            // FormOpenDocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(228)))), ((int)(((byte)(232)))));
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.PanelBottom);
            this.Controls.Add(this.PanelTop);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormOpenDocs";
            this.Text = "Open Documents";
            this.PanelBottom.ResumeLayout(false);
            this.PanelTop.ResumeLayout(false);
            this.PanelBorder.ResumeLayout(false);
            this.PanelBorder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelBottom;
        public DevNotepad.GUI.Controls.DoubleBufferedListBox ListFiles;
        private System.Windows.Forms.Panel PanelTop;
        private System.Windows.Forms.Panel PanelBorder;
        private DevNotepad.GUI.Controls.PlaceholderTextBox EditFilter;
    }
}