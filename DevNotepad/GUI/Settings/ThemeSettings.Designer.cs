namespace DevNotepad.GUI.Settings
{
    partial class ThemeSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TabTheme = new System.Windows.Forms.TabControl();
            this.PageSchemeColors = new System.Windows.Forms.TabPage();
            this.TableSchemeLayout = new System.Windows.Forms.TableLayoutPanel();
            this.PanelHold = new System.Windows.Forms.Panel();
            this.PanelSample = new System.Windows.Forms.Panel();
            this.LabelSample = new System.Windows.Forms.Label();
            this.GroupSettings = new System.Windows.Forms.GroupBox();
            this.CheckEOLFilled = new System.Windows.Forms.CheckBox();
            this.CheckUnderline = new System.Windows.Forms.CheckBox();
            this.CheckItalic = new System.Windows.Forms.CheckBox();
            this.CheckBold = new System.Windows.Forms.CheckBox();
            this.LabelBackground = new System.Windows.Forms.Label();
            this.LabelFore = new System.Windows.Forms.Label();
            this.PageUIColors = new System.Windows.Forms.TabPage();
            this.PanelStyles = new System.Windows.Forms.Panel();
            this.ListStyles = new System.Windows.Forms.ListBox();
            this.ColorBack = new ColorComboTestApp.ColorComboBox();
            this.ColorFore = new ColorComboTestApp.ColorComboBox();
            this.TabTheme.SuspendLayout();
            this.PageSchemeColors.SuspendLayout();
            this.TableSchemeLayout.SuspendLayout();
            this.PanelHold.SuspendLayout();
            this.PanelSample.SuspendLayout();
            this.GroupSettings.SuspendLayout();
            this.PanelStyles.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabTheme
            // 
            this.TabTheme.Controls.Add(this.PageSchemeColors);
            this.TabTheme.Controls.Add(this.PageUIColors);
            this.TabTheme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabTheme.Location = new System.Drawing.Point(5, 5);
            this.TabTheme.Name = "TabTheme";
            this.TabTheme.SelectedIndex = 0;
            this.TabTheme.Size = new System.Drawing.Size(598, 351);
            this.TabTheme.TabIndex = 0;
            // 
            // PageSchemeColors
            // 
            this.PageSchemeColors.Controls.Add(this.TableSchemeLayout);
            this.PageSchemeColors.Location = new System.Drawing.Point(4, 22);
            this.PageSchemeColors.Name = "PageSchemeColors";
            this.PageSchemeColors.Padding = new System.Windows.Forms.Padding(3);
            this.PageSchemeColors.Size = new System.Drawing.Size(590, 325);
            this.PageSchemeColors.TabIndex = 0;
            this.PageSchemeColors.Text = "{SCHEMECOLORS}";
            this.PageSchemeColors.UseVisualStyleBackColor = true;
            // 
            // TableSchemeLayout
            // 
            this.TableSchemeLayout.ColumnCount = 2;
            this.TableSchemeLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.56165F));
            this.TableSchemeLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.43835F));
            this.TableSchemeLayout.Controls.Add(this.PanelHold, 1, 0);
            this.TableSchemeLayout.Controls.Add(this.PanelStyles, 0, 0);
            this.TableSchemeLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableSchemeLayout.Location = new System.Drawing.Point(3, 3);
            this.TableSchemeLayout.Name = "TableSchemeLayout";
            this.TableSchemeLayout.RowCount = 1;
            this.TableSchemeLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableSchemeLayout.Size = new System.Drawing.Size(584, 319);
            this.TableSchemeLayout.TabIndex = 0;
            // 
            // PanelHold
            // 
            this.PanelHold.Controls.Add(this.PanelSample);
            this.PanelHold.Controls.Add(this.GroupSettings);
            this.PanelHold.Controls.Add(this.LabelBackground);
            this.PanelHold.Controls.Add(this.LabelFore);
            this.PanelHold.Controls.Add(this.ColorBack);
            this.PanelHold.Controls.Add(this.ColorFore);
            this.PanelHold.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelHold.Location = new System.Drawing.Point(199, 3);
            this.PanelHold.Name = "PanelHold";
            this.PanelHold.Size = new System.Drawing.Size(382, 313);
            this.PanelHold.TabIndex = 1;
            // 
            // PanelSample
            // 
            this.PanelSample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelSample.Controls.Add(this.LabelSample);
            this.PanelSample.Location = new System.Drawing.Point(25, 228);
            this.PanelSample.Name = "PanelSample";
            this.PanelSample.Size = new System.Drawing.Size(243, 45);
            this.PanelSample.TabIndex = 7;
            // 
            // LabelSample
            // 
            this.LabelSample.AutoSize = true;
            this.LabelSample.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelSample.Location = new System.Drawing.Point(114, 13);
            this.LabelSample.Name = "LabelSample";
            this.LabelSample.Padding = new System.Windows.Forms.Padding(3);
            this.LabelSample.Size = new System.Drawing.Size(6, 22);
            this.LabelSample.TabIndex = 0;
            // 
            // GroupSettings
            // 
            this.GroupSettings.Controls.Add(this.CheckEOLFilled);
            this.GroupSettings.Controls.Add(this.CheckUnderline);
            this.GroupSettings.Controls.Add(this.CheckItalic);
            this.GroupSettings.Controls.Add(this.CheckBold);
            this.GroupSettings.Location = new System.Drawing.Point(25, 91);
            this.GroupSettings.Name = "GroupSettings";
            this.GroupSettings.Size = new System.Drawing.Size(243, 125);
            this.GroupSettings.TabIndex = 6;
            this.GroupSettings.TabStop = false;
            this.GroupSettings.Text = "{FONTSETTINGS}";
            // 
            // CheckEOLFilled
            // 
            this.CheckEOLFilled.AutoSize = true;
            this.CheckEOLFilled.Location = new System.Drawing.Point(17, 94);
            this.CheckEOLFilled.Name = "CheckEOLFilled";
            this.CheckEOLFilled.Size = new System.Drawing.Size(91, 17);
            this.CheckEOLFilled.TabIndex = 3;
            this.CheckEOLFilled.Text = "{EOLFILLED}";
            this.CheckEOLFilled.UseVisualStyleBackColor = true;
            // 
            // CheckUnderline
            // 
            this.CheckUnderline.AutoSize = true;
            this.CheckUnderline.Location = new System.Drawing.Point(17, 71);
            this.CheckUnderline.Name = "CheckUnderline";
            this.CheckUnderline.Size = new System.Drawing.Size(97, 17);
            this.CheckUnderline.TabIndex = 2;
            this.CheckUnderline.Text = "{UNDERLINE}";
            this.CheckUnderline.UseVisualStyleBackColor = true;
            this.CheckUnderline.Click += new System.EventHandler(this.CheckBold_Click);
            // 
            // CheckItalic
            // 
            this.CheckItalic.AutoSize = true;
            this.CheckItalic.Location = new System.Drawing.Point(17, 48);
            this.CheckItalic.Name = "CheckItalic";
            this.CheckItalic.Size = new System.Drawing.Size(67, 17);
            this.CheckItalic.TabIndex = 1;
            this.CheckItalic.Text = "{ITALIC}";
            this.CheckItalic.UseVisualStyleBackColor = true;
            this.CheckItalic.Click += new System.EventHandler(this.CheckBold_Click);
            // 
            // CheckBold
            // 
            this.CheckBold.AutoSize = true;
            this.CheckBold.Location = new System.Drawing.Point(17, 25);
            this.CheckBold.Name = "CheckBold";
            this.CheckBold.Size = new System.Drawing.Size(63, 17);
            this.CheckBold.TabIndex = 0;
            this.CheckBold.Text = "{BOLD}";
            this.CheckBold.UseVisualStyleBackColor = true;
            this.CheckBold.Click += new System.EventHandler(this.CheckBold_Click);
            // 
            // LabelBackground
            // 
            this.LabelBackground.AutoSize = true;
            this.LabelBackground.Location = new System.Drawing.Point(167, 25);
            this.LabelBackground.Name = "LabelBackground";
            this.LabelBackground.Size = new System.Drawing.Size(128, 13);
            this.LabelBackground.TabIndex = 5;
            this.LabelBackground.Text = "{BACKGROUNDCOLOR}";
            // 
            // LabelFore
            // 
            this.LabelFore.AutoSize = true;
            this.LabelFore.Location = new System.Drawing.Point(22, 25);
            this.LabelFore.Name = "LabelFore";
            this.LabelFore.Size = new System.Drawing.Size(129, 13);
            this.LabelFore.TabIndex = 4;
            this.LabelFore.Text = "{FOREGROUNDCOLOR}";
            // 
            // PageUIColors
            // 
            this.PageUIColors.Location = new System.Drawing.Point(4, 22);
            this.PageUIColors.Name = "PageUIColors";
            this.PageUIColors.Padding = new System.Windows.Forms.Padding(3);
            this.PageUIColors.Size = new System.Drawing.Size(590, 325);
            this.PageUIColors.TabIndex = 1;
            this.PageUIColors.Text = "{UICOLORS}";
            this.PageUIColors.UseVisualStyleBackColor = true;
            // 
            // PanelStyles
            // 
            this.PanelStyles.Controls.Add(this.ListStyles);
            this.PanelStyles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelStyles.Location = new System.Drawing.Point(3, 3);
            this.PanelStyles.Name = "PanelStyles";
            this.PanelStyles.Size = new System.Drawing.Size(190, 313);
            this.PanelStyles.TabIndex = 2;
            // 
            // ListStyles
            // 
            this.ListStyles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListStyles.FormattingEnabled = true;
            this.ListStyles.IntegralHeight = false;
            this.ListStyles.Location = new System.Drawing.Point(0, 0);
            this.ListStyles.Margin = new System.Windows.Forms.Padding(5);
            this.ListStyles.Name = "ListStyles";
            this.ListStyles.Size = new System.Drawing.Size(190, 313);
            this.ListStyles.TabIndex = 1;
            this.ListStyles.SelectedIndexChanged += new System.EventHandler(this.ListStyles_SelectedIndexChanged);
            // 
            // ColorBack
            // 
            this.ColorBack.Extended = true;
            this.ColorBack.Location = new System.Drawing.Point(170, 46);
            this.ColorBack.Name = "ColorBack";
            this.ColorBack.SelectedColor = System.Drawing.Color.Black;
            this.ColorBack.Size = new System.Drawing.Size(98, 28);
            this.ColorBack.TabIndex = 3;
            this.ColorBack.ColorChanged += new ColorComboTestApp.ColorChangedHandler(this.ColorFore_ColorChanged);
            // 
            // ColorFore
            // 
            this.ColorFore.Extended = true;
            this.ColorFore.Location = new System.Drawing.Point(25, 46);
            this.ColorFore.Name = "ColorFore";
            this.ColorFore.SelectedColor = System.Drawing.Color.Black;
            this.ColorFore.Size = new System.Drawing.Size(98, 28);
            this.ColorFore.TabIndex = 2;
            this.ColorFore.ColorChanged += new ColorComboTestApp.ColorChangedHandler(this.ColorFore_ColorChanged);
            // 
            // ThemeSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TabTheme);
            this.Name = "ThemeSettings";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Size = new System.Drawing.Size(608, 361);
            this.Load += new System.EventHandler(this.ThemeSettings_Load);
            this.TabTheme.ResumeLayout(false);
            this.PageSchemeColors.ResumeLayout(false);
            this.TableSchemeLayout.ResumeLayout(false);
            this.PanelHold.ResumeLayout(false);
            this.PanelHold.PerformLayout();
            this.PanelSample.ResumeLayout(false);
            this.PanelSample.PerformLayout();
            this.GroupSettings.ResumeLayout(false);
            this.GroupSettings.PerformLayout();
            this.PanelStyles.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabTheme;
        private System.Windows.Forms.TabPage PageSchemeColors;
        private System.Windows.Forms.TabPage PageUIColors;
        private System.Windows.Forms.TableLayoutPanel TableSchemeLayout;
        private System.Windows.Forms.Panel PanelHold;
        private ColorComboTestApp.ColorComboBox ColorBack;
        private ColorComboTestApp.ColorComboBox ColorFore;
        private System.Windows.Forms.GroupBox GroupSettings;
        private System.Windows.Forms.CheckBox CheckUnderline;
        private System.Windows.Forms.CheckBox CheckItalic;
        private System.Windows.Forms.CheckBox CheckBold;
        private System.Windows.Forms.Label LabelBackground;
        private System.Windows.Forms.Label LabelFore;
        private System.Windows.Forms.CheckBox CheckEOLFilled;
        private System.Windows.Forms.Panel PanelSample;
        private System.Windows.Forms.Label LabelSample;
        private System.Windows.Forms.Panel PanelStyles;
        private System.Windows.Forms.ListBox ListStyles;
    }
}
