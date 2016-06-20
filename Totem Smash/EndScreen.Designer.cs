namespace Totem_Smash
{
    partial class EndScreen
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
            this.titleLabel = new System.Windows.Forms.Label();
            this.highscoresOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Modern No. 20", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(302, 19);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(184, 38);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Highscores";
            // 
            // highscoresOutput
            // 
            this.highscoresOutput.AutoSize = true;
            this.highscoresOutput.Location = new System.Drawing.Point(309, 113);
            this.highscoresOutput.Name = "highscoresOutput";
            this.highscoresOutput.Size = new System.Drawing.Size(35, 13);
            this.highscoresOutput.TabIndex = 1;
            this.highscoresOutput.Text = "label2";
            // 
            // EndScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OliveDrab;
            this.Controls.Add(this.highscoresOutput);
            this.Controls.Add(this.titleLabel);
            this.Name = "EndScreen";
            this.Size = new System.Drawing.Size(800, 750);
            this.Load += new System.EventHandler(this.EndScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label highscoresOutput;
    }
}
