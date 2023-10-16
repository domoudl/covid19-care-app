using System.ComponentModel;

namespace covid19_care_app.UserControls
{
    partial class UC_Carte
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
            this.panelCarte = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelCarte
            // 
            this.panelCarte.Location = new System.Drawing.Point(0, 0);
            this.panelCarte.Name = "panelCarte";
            this.panelCarte.Size = new System.Drawing.Size(1101, 468);
            this.panelCarte.TabIndex = 0;
            // 
            // UC_Carte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelCarte);
            this.Name = "UC_Carte";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelCarte;

        #endregion
    }
}