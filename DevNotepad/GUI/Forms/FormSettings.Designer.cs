namespace DevNotepad.GUI.Forms
{
    partial class FormSettings
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
            this.PanelButtons = new System.Windows.Forms.Panel();
            this.SettingsLayout = new System.Windows.Forms.TableLayoutPanel();
            this.TreeSettings = new System.Windows.Forms.TreeView();
            this.PanelSettings = new System.Windows.Forms.Panel();
            this.TableButtons = new System.Windows.Forms.TableLayoutPanel();
            this.ButtonHelp = new System.Windows.Forms.Button();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.PanelButtons.SuspendLayout();
            this.SettingsLayout.SuspendLayout();
            this.TableButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelButtons
            // 
            this.PanelButtons.Controls.Add(this.TableButtons);
            this.PanelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelButtons.Location = new System.Drawing.Point(0, 350);
            this.PanelButtons.Name = "PanelButtons";
            this.PanelButtons.Size = new System.Drawing.Size(634, 45);
            this.PanelButtons.TabIndex = 0;
            // 
            // SettingsLayout
            // 
            this.SettingsLayout.ColumnCount = 2;
            this.SettingsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.65726F));
            this.SettingsLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.34274F));
            this.SettingsLayout.Controls.Add(this.TreeSettings, 0, 0);
            this.SettingsLayout.Controls.Add(this.PanelSettings, 1, 0);
            this.SettingsLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SettingsLayout.Location = new System.Drawing.Point(0, 0);
            this.SettingsLayout.Name = "SettingsLayout";
            this.SettingsLayout.RowCount = 1;
            this.SettingsLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SettingsLayout.Size = new System.Drawing.Size(634, 350);
            this.SettingsLayout.TabIndex = 1;
            this.SettingsLayout.Click += new System.EventHandler(this.SettingsLayout_Click);
            // 
            // TreeSettings
            // 
            this.TreeSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeSettings.FullRowSelect = true;
            this.TreeSettings.HideSelection = false;
            this.TreeSettings.Location = new System.Drawing.Point(6, 6);
            this.TreeSettings.Margin = new System.Windows.Forms.Padding(6);
            this.TreeSettings.Name = "TreeSettings";
            this.TreeSettings.ShowLines = false;
            this.TreeSettings.Size = new System.Drawing.Size(157, 338);
            this.TreeSettings.TabIndex = 0;
            this.TreeSettings.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeSettings_NodeMouseClick);
            // 
            // PanelSettings
            // 
            this.PanelSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSettings.Location = new System.Drawing.Point(172, 3);
            this.PanelSettings.Name = "PanelSettings";
            this.PanelSettings.Size = new System.Drawing.Size(459, 344);
            this.PanelSettings.TabIndex = 1;
            // 
            // TableButtons
            // 
            this.TableButtons.ColumnCount = 4;
            this.TableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.TableButtons.Controls.Add(this.ButtonHelp, 0, 0);
            this.TableButtons.Controls.Add(this.ButtonOK, 2, 0);
            this.TableButtons.Controls.Add(this.ButtonCancel, 3, 0);
            this.TableButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableButtons.Location = new System.Drawing.Point(0, 0);
            this.TableButtons.Name = "TableButtons";
            this.TableButtons.RowCount = 1;
            this.TableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableButtons.Size = new System.Drawing.Size(634, 45);
            this.TableButtons.TabIndex = 0;
            // 
            // ButtonHelp
            // 
            this.ButtonHelp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonHelp.Location = new System.Drawing.Point(7, 7);
            this.ButtonHelp.Margin = new System.Windows.Forms.Padding(7);
            this.ButtonHelp.Name = "ButtonHelp";
            this.ButtonHelp.Size = new System.Drawing.Size(86, 31);
            this.ButtonHelp.TabIndex = 0;
            this.ButtonHelp.Text = "{HELP}";
            this.ButtonHelp.UseVisualStyleBackColor = true;
            // 
            // ButtonOK
            // 
            this.ButtonOK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonOK.Location = new System.Drawing.Point(441, 7);
            this.ButtonOK.Margin = new System.Windows.Forms.Padding(7);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(86, 31);
            this.ButtonOK.TabIndex = 1;
            this.ButtonOK.Text = "{OK}";
            this.ButtonOK.UseVisualStyleBackColor = true;
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonCancel.Location = new System.Drawing.Point(541, 7);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(7);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(86, 31);
            this.ButtonCancel.TabIndex = 2;
            this.ButtonCancel.Text = "{CANCEL}";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            // 
            // FormSettings
            // 
            this.AcceptButton = this.ButtonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(634, 395);
            this.Controls.Add(this.SettingsLayout);
            this.Controls.Add(this.PanelButtons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormSettings";
            this.Text = "Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.PanelButtons.ResumeLayout(false);
            this.SettingsLayout.ResumeLayout(false);
            this.TableButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelButtons;
        private System.Windows.Forms.TableLayoutPanel SettingsLayout;
        private System.Windows.Forms.TreeView TreeSettings;
        private System.Windows.Forms.Panel PanelSettings;
        private System.Windows.Forms.TableLayoutPanel TableButtons;
        private System.Windows.Forms.Button ButtonHelp;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;

    }
}