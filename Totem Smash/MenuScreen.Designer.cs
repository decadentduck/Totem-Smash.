namespace Totem_Smash
{
    partial class MenuScreen
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
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.instructionLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ready2 = new System.Windows.Forms.PictureBox();
            this.ready1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ready2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ready1)).BeginInit();
            this.SuspendLayout();
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionLabel.Location = new System.Drawing.Point(84, 47);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(106, 24);
            this.DescriptionLabel.TabIndex = 0;
            this.DescriptionLabel.Text = "Description";
            // 
            // instructionLabel
            // 
            this.instructionLabel.AutoSize = true;
            this.instructionLabel.Font = new System.Drawing.Font("Modern No. 20", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionLabel.Location = new System.Drawing.Point(84, 228);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(367, 24);
            this.instructionLabel.TabIndex = 1;
            this.instructionLabel.Text = "Instructions: Press yellow button to jump  ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Stencil", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(125, 614);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(523, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "Press yellow button to start";
            // 
            // ready2
            // 
            this.ready2.Image = global::Totem_Smash.Properties.Resources.p2Falling;
            this.ready2.Location = new System.Drawing.Point(600, 74);
            this.ready2.Name = "ready2";
            this.ready2.Size = new System.Drawing.Size(100, 116);
            this.ready2.TabIndex = 3;
            this.ready2.TabStop = false;
            this.ready2.Visible = false;
            // 
            // ready1
            // 
            this.ready1.Image = global::Totem_Smash.Properties.Resources.p1up;
            this.ready1.Location = new System.Drawing.Point(433, 74);
            this.ready1.Name = "ready1";
            this.ready1.Size = new System.Drawing.Size(100, 116);
            this.ready1.TabIndex = 4;
            this.ready1.TabStop = false;
            this.ready1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 387);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            // 
            // MenuScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ready1);
            this.Controls.Add(this.ready2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.instructionLabel);
            this.Controls.Add(this.DescriptionLabel);
            this.Name = "MenuScreen";
            this.Size = new System.Drawing.Size(800, 750);
            this.Load += new System.EventHandler(this.MenuScreen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MenuScreen_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ready2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ready1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label instructionLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox ready2;
        private System.Windows.Forms.PictureBox ready1;
        private System.Windows.Forms.Label label2;
    }
}
