namespace Kusko.FiguresGame.WFA
{
    partial class MainGameWindow
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
            this.scoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scoreLabel
            // 
            this.scoreLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Location = new System.Drawing.Point(65, 62);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(59, 13);
            this.scoreLabel.TabIndex = 0;
            this.scoreLabel.Text = "scoreLabel";
            this.scoreLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // MainGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 635);
            this.Controls.Add(this.scoreLabel);
            this.Name = "MainGameWindow";
            this.Text = "MainGameWindow";
            this.Load += new System.EventHandler(this.MainGameWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label scoreLabel;
    }
}