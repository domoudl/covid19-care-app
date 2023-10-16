using System.ComponentModel;

namespace covid19_care_app.UserControls
{
    partial class UC_SS
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.MaListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // MaListBox
            // 
            this.MaListBox.FormattingEnabled = true;
            this.MaListBox.ItemHeight = 20;
            this.MaListBox.Location = new System.Drawing.Point(-3, 0);
            this.MaListBox.Name = "MaListBox";
            this.MaListBox.Size = new System.Drawing.Size(1101, 464);
            this.MaListBox.TabIndex = 0;
            // 
            // UC_SS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MaListBox);
            this.Name = "UC_SS";
            this.Size = new System.Drawing.Size(1101, 468);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListBox MaListBox;

        #endregion
    }
}