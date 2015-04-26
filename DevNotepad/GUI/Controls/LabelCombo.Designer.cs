namespace DevNotepad.GUI.Controls
{
    partial class LabelCombo
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
            this.LabelText = new System.Windows.Forms.Label();
            this.Combo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // LabelText
            // 
            this.LabelText.Dock = System.Windows.Forms.DockStyle.Top;
            this.LabelText.Location = new System.Drawing.Point(0, 0);
            this.LabelText.Name = "LabelText";
            this.LabelText.Size = new System.Drawing.Size(300, 20);
            this.LabelText.TabIndex = 0;
            this.LabelText.Text = "label1";
            this.LabelText.Click += new System.EventHandler(this.LabelText_Click);
            // 
            // Combo
            // 
            this.Combo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Combo.FormattingEnabled = true;
            this.Combo.Location = new System.Drawing.Point(0, 20);
            this.Combo.Name = "Combo";
            this.Combo.Size = new System.Drawing.Size(300, 21);
            this.Combo.TabIndex = 1;
            // 
            // LabelCombo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Combo);
            this.Controls.Add(this.LabelText);
            this.MinimumSize = new System.Drawing.Size(300, 0);
            this.Name = "LabelCombo";
            this.Size = new System.Drawing.Size(300, 45);
            this.PaddingChanged += new System.EventHandler(this.LabelCombo_PaddingChanged);
            this.Resize += new System.EventHandler(this.LabelCombo_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LabelText;
        private System.Windows.Forms.ComboBox Combo;
    }
}
