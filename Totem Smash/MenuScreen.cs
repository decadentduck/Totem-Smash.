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
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void MenuScreen_Load(object sender, EventArgs e)
        {
            instructionLabel.Text = "Press yellow button to jump /nPress green button to Smash";
            DescriptionLabel.Text = "Description: Pound the totem into the ground before your opponent does./nhe higher you jump the more effective your smash."
        }
        //TODO Display instructions
        //TODO Display Description
        //TODO Prompt players to hit key to start game
        //TODO If all player hit key load up GameScreen
    }
}
