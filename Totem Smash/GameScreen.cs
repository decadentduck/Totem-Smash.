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
    public partial class GameScreen : UserControl
    {
        public GameScreen()
        {
            InitializeComponent();
        }

        //TODO Player list
        //TODO Totem list
        //TODO Image array for each Player
        //TODO Keydown booleans for each key 
        //TODO Point ints

        //TODO Setup Method:
        //TODO Create a totem for each player
        //TODO Add totems to a list

        //TODO CountDown method:
        //TODO Totem damages set to zero
        //TODO Game countdown timer

        private void GameScreen_KeyDown(object sender, KeyEventArgs e)
        {
            //TODO Set booleans for keydown to true for keys that are down
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //TODO Set booleans for keysdown to be false for keys that are up
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //TODO GameTimer.Tick method:
            //TODO Check for player movement
            //TODO If smashing already continue smashing
            //TODO Else check if smash = true then call player.smash method
            //TODO Else If already jumping continue jumping
            //TODO Else If jump = true then call player.Jump method
            //TODO Check for collision between player and totem(call Player.collision method)
            //TODO If collision returns true
            //TODO Determine damage done to totem and send it to totem.damageDone Method
            //TODO Damage will be done to totem dependant on how high the characters were when they chose to smash
            //TODO Check if there’s totem left
            //TODO If a totem is at the ground that player gets a point
            //TODO Check if that player has three points
            //TODO If yes then call EndGame method
            //TODO Else call up CountDown method to restart
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //TODO Draw players from player list
            //TODO Draw totems from totem list
        }

        //TODO EndGame Method:
        //TODO the winner will be saved to an xml file
        //TODO the program will close and go back to the main Program

    }
}
