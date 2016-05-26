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

        Player P1, P2;
        List<Player> players = new List<Player>();
        List<Totem> totems = new List<Totem>();

        //TODO Image array for each Player
        Image[] player1 = { };
        Image[] player2 = { };

        bool p1Up, p2Up, p1Down, p2Down;
        int p1Points, p2Points;


        private void SetUp()
        {
            //TODO Create a totem for each player
            //TODO Add totems to a list
        }

        private void CountDown()
        {
            //TODO Totem damages set to zero
            //TODO Game countdown timer
        }

        private void GameScreen_KeyDown(object sender, KeyEventArgs e)
        {
            //TODO Set booleans for keydown to true for keys that are down
            switch (e.KeyCode)
            {
                case Keys.N:
                    p1Up = true;
                    break;
                case Keys.Space:
                    p1Down = true;
                    break;
                case Keys.V:
                    p2Up = true;
                    break;
                case Keys.Z:
                    p2Down = true;
                    break;
                    //TODO escape key to exit game
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //TODO Set booleans for keysdown to be false for keys that are up
            switch (e.KeyCode)
            {
                case Keys.N:
                    p1Up = false;
                    break;
                case Keys.Space:
                    p1Down = false;
                    break;
                case Keys.V:
                    p2Up = false;
                    break;
                case Keys.Z:
                    p2Down = false;
                    break;
                //TODO escape key to exit game
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            #region Player Movement
            //TODO Check for player movement
            //TODO If smashing already continue smashing
            //TODO Else check if smash = true then call player.smash method
            //TODO Else If already jumping continue jumping
            //TODO Else If jump = true then call player.Jump method
            #endregion

            #region Collision Check
            //TODO Check for collision between player and totem(call Player.collision method)
            foreach (Totem T in totems)
            {   
                if (P1.Collision(P1, T) == true)
                {       
                    //TODO Determine damage done to totem and send it to totem.damageDone Method
                    //TODO Damage will be done to totem dependant on how high the characters were when they chose to smash
                    //TODO Check if there’s totem left
                    //TODO If a totem is at the ground that player gets a point
                    //TODO Check if that player has three points
                    //TODO If yes then call EndGame method
                    //TODO Else call up CountDown method to restart
                }
            }

            #endregion
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //TODO Draw players from player list
            //TODO Draw totems from totem list
        }

        private void EndGame()
        {
            //TODO the winner will be saved to an xml file
            //TODO the program will close and go back to the main Program
        }
        
    }
}
