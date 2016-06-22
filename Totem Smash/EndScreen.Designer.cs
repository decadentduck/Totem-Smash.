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
            this.letter2 = new System.Windows.Forms.Label();
            this.letter1 = new System.Windows.Forms.Label();
            this.scoreOutput = new System.Windows.Forms.Label();
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
            this.highscoresOutput.Font = new System.Drawing.Font("Modern No. 20", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highscoresOutput.Location = new System.Drawing.Point(290, 111);
            this.highscoresOutput.Name = "highscoresOutput";
            this.highscoresOutput.Size = new System.Drawing.Size(84, 31);
            this.highscoresOutput.TabIndex = 1;
            this.highscoresOutput.Text = "label2";
            // 
            // letter2
            // 
            this.letter2.AutoSize = true;
            this.letter2.Font = new System.Drawing.Font("Modern No. 20", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letter2.Location = new System.Drawing.Point(397, 181);
            this.letter2.Name = "letter2";
            this.letter2.Size = new System.Drawing.Size(34, 31);
            this.letter2.TabIndex = 2;
            this.letter2.Text = "A";
            this.letter2.Visible = false;
            // 
            // letter1
            // 
            this.letter1.AutoSize = true;
            this.letter1.Font = new System.Drawing.Font("Modern No. 20", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.letter1.Location = new System.Drawing.Point(357, 181);
            this.letter1.Name = "letter1";
            this.letter1.Size = new System.Drawing.Size(34, 31);
            this.letter1.TabIndex = 3;
            this.letter1.Text = "A";
            this.letter1.Visible = false;
            // 
            // scoreOutput
            // 
            this.scoreOutput.Font = new System.Drawing.Font("Modern No. 20", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreOutput.Location = new System.Drawing.Point(309, 212);
            this.scoreOutput.Name = "scoreOutput";
            this.scoreOutput.Size = new System.Drawing.Size(177, 31);
            this.scoreOutput.TabIndex = 4;
            this.scoreOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.scoreOutput.Visible = false;
            // 
            // EndScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OliveDrab;
            this.Controls.Add(this.scoreOutput);
            this.Controls.Add(this.letter1);
            this.Controls.Add(this.letter2);
            this.Controls.Add(this.highscoresOutput);
            this.Controls.Add(this.titleLabel);
            this.Name = "EndScreen";
            this.Size = new System.Drawing.Size(800, 750);
            this.Load += new System.EventHandler(this.EndScreen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EndScreen_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label highscoresOutput;
        private System.Windows.Forms.Label letter2;
        private System.Windows.Forms.Label letter1;
        private System.Windows.Forms.Label scoreOutput;
    }
}
