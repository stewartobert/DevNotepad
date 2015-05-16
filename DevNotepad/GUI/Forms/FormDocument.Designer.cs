namespace DevNotepad.GUI.Forms
{
    partial class FormDocument
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDocument));
            this.Editor = new ScintillaNET.Scintilla();
            ((System.ComponentModel.ISupportInitialize)(this.Editor)).BeginInit();
            this.SuspendLayout();
            // 
            // Editor
            // 
            this.Editor.AutoClose.AutoCloseBraces = true;
            this.Editor.AutoClose.AutoCloseHtmlTags = true;
            this.Editor.AutoClose.AutoCloseQuotes = true;
            this.Editor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Editor.Caret.CurrentLineBackgroundColor = System.Drawing.Color.Cornsilk;
            this.Editor.Caret.HighlightCurrentLine = true;
            this.Editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Editor.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Editor.Indentation.SmartIndentType = ScintillaNET.SmartIndent.XML;
            this.Editor.Indentation.TabWidth = 4;
            this.Editor.IsBraceMatching = true;
            this.Editor.Lexing.Lexer = ScintillaNET.Lexer.Null;
            this.Editor.Lexing.LexerName = "null";
            this.Editor.Lexing.LineCommentPrefix = "";
            this.Editor.Lexing.StreamCommentPrefix = "";
            this.Editor.Lexing.StreamCommentSufix = "";
            this.Editor.Location = new System.Drawing.Point(4, 4);
            this.Editor.Margins.Margin1.Width = 0;
            this.Editor.Margins.Margin2.Width = 12;
            this.Editor.Name = "Editor";
            this.Editor.Scrolling.HorizontalScrollWidth = 40;
            this.Editor.Size = new System.Drawing.Size(633, 254);
            this.Editor.Styles.Bits = 8;
            this.Editor.Styles.BraceBad.FontName = "";
            this.Editor.Styles.BraceBad.Size = 9F;
            this.Editor.Styles.BraceLight.FontName = "";
            this.Editor.Styles.BraceLight.Size = 9F;
            this.Editor.Styles.ControlChar.FontName = "";
            this.Editor.Styles.ControlChar.Size = 9F;
            this.Editor.Styles.Default.BackColor = System.Drawing.SystemColors.Window;
            this.Editor.Styles.Default.Size = 9F;
            this.Editor.Styles.IndentGuide.FontName = "";
            this.Editor.Styles.IndentGuide.Size = 9F;
            this.Editor.Styles.LastPredefined.FontName = "";
            this.Editor.Styles.LastPredefined.Size = 9F;
            this.Editor.Styles.LineNumber.FontName = "";
            this.Editor.Styles.LineNumber.Size = 9F;
            this.Editor.Styles.Max.FontName = "";
            this.Editor.Styles.Max.Size = 9F;
            this.Editor.TabIndex = 0;
            this.Editor.CharAdded += new System.EventHandler<ScintillaNET.CharAddedEventArgs>(this.Editor_CharAdded);
            // 
            // FormDocument
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(641, 262);
            this.Controls.Add(this.Editor);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.Document)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDocument";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Text = "FormDocument";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormDocument_FormClosed);
            this.Load += new System.EventHandler(this.FormDocument_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Editor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ScintillaNET.Scintilla Editor;


    }
}