using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Totem_Smash
{
    public partial class MenuScreen : UserControl
    {
        bool p1Ready, p2Ready;
        //TODO add high scores option label

        public MenuScreen()
        {
            InitializeComponent();
            
        }
        
        private void MenuScreen_Load(object sender, EventArgs e)
        {
            this.Focus();
            instructionLabel.Text = "Controls:\nPress yellow button to jump \nPress green button to smash";
            DescriptionLabel.Text = "Description:\nPound the totem into the ground before your opponent does.\nThe higher you jump the more effective your smash.";
        }
        
        private void MenuScreen_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyCode)
            {
                case Keys.N:
                    p1Ready = true;
                    break;
                case Keys.V:
                    p2Ready = true;
                    break;
                case Keys.Escape:
                    Application.Exit();
                    break;
                case Keys.Space:
                    //TODO add option to go to highscores
                    Form f = this.FindForm();
                    f.Controls.Remove(this);
                    EndScreen es = new EndScreen();
                    f.Controls.Add(es);
                    break;
            }

            //If all player hit key load up GameScreen
            if (p1Ready)
            {
                //TODO make p1Ready Label
                ready1.Visible = true;
            }
            else { ready1.Visible = false; }

            if (p2Ready)
            {
                //TODO make p2Ready label
                ready2.Visible = true;
            }
            else { ready2.Visible = false; }

            if (p1Ready && p2Ready)
            {
                //Start GameScreen
                Form f = this.FindForm();
                f.Controls.Remove(this);
                GameScreen gs = new GameScreen();
                f.Controls.Add(gs);
            }
        }
        
    }
}
