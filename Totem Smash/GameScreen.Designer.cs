namespace Totem_Smash
{
    partial class GameScreen
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
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.point1Label = new System.Windows.Forms.Label();
            this.point2Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 60;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // point1Label
            // 
            this.point1Label.AutoSize = true;
            this.point1Label.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.point1Label.Location = new System.Drawing.Point(307, 13);
            this.point1Label.Name = "point1Label";
            this.point1Label.Size = new System.Drawing.Size(183, 32);
            this.point1Label.TabIndex = 0;
            this.point1Label.Text = "Player 1 Points: ";
            // 
            // point2Label
            // 
            this.point2Label.AutoSize = true;
            this.point2Label.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.point2Label.Location = new System.Drawing.Point(307, 45);
            this.point2Label.Name = "point2Label";
            this.point2Label.Size = new System.Drawing.Size(183, 32);
            this.point2Label.TabIndex = 2;
            this.point2Label.Text = "Player 2 Points: ";
            // 
            // GameScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.Controls.Add(this.point2Label);
            this.Controls.Add(this.point1Label);
            this.DoubleBuffered = true;
            this.Name = "GameScreen";
            this.Size = new System.Drawing.Size(800, 750);
            this.Load += new System.EventHandler(this.GameScreen_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameScreen_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.GameScreen_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label point1Label;
        private System.Windows.Forms.Label point2Label;
    }
}
