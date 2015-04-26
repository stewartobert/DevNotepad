namespace DevNotepad.GUI.Forms.Docking
{
    partial class FormFindInFiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFindInFiles));
            this.TreeFind = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // TreeFind
            // 
            this.TreeFind.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TreeFind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeFind.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.TreeFind.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TreeFind.FullRowSelect = true;
            this.TreeFind.HideSelection = false;
            this.TreeFind.Location = new System.Drawing.Point(0, 0);
            this.TreeFind.Name = "TreeFind";
            this.TreeFind.Size = new System.Drawing.Size(844, 229);
            this.TreeFind.TabIndex = 0;
            this.TreeFind.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.TreeFind_DrawNode);
            this.TreeFind.DoubleClick += new System.EventHandler(this.TreeFind_DoubleClick);
            this.TreeFind.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TreeFind_MouseDown);
            // 
            // FormFindInFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 229);
            this.Controls.Add(this.TreeFind);
            this.DockAreas = ((WeifenLuo.WinFormsUI.Docking.DockAreas)(((((WeifenLuo.WinFormsUI.Docking.DockAreas.Float | WeifenLuo.WinFormsUI.Docking.DockAreas.DockLeft) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockRight) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockTop) 
            | WeifenLuo.WinFormsUI.Docking.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFindInFiles";
            this.Text = "Find in Files";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TreeFind;
    }
}