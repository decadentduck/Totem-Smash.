using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Totem_Smash
{
    public partial class GameScreen : UserControl
    {
        public GameScreen()
        {
            InitializeComponent();
        }

        #region bools ints lists arrays
        Player P1, P2;
        List<Player> players = new List<Player>();
        List<Totem> totems = new List<Totem>();

        //Image array for each Player
        Image[] player1 = { Properties.Resources.p1down, Properties.Resources.p1up, Properties.Resources.p1Fallingl };
        Image[] player2 = { Properties.Resources.p2Down, Properties.Resources.p2Up, Properties.Resources.p2Falling };

        bool p1Up, p2Up, p1Down, p2Down, escape, canJump1, canJump2;
        int p1Points, p2Points;
        #endregion

        private void SetUp()
        {
            totems.Clear();
            players.Clear();

            //Create a totem for each player
            Totem t = new Totem(100, 150, 500, 0);
            Totem tt = new Totem(500, 150, 500, 0);
            //Add totems to a list
            totems.Add(t);
            totems.Add(tt);

            P1 = new Player(t.x, t.y - 80, 80, 8, player1);
            P2 = new Player(tt.x, tt.y - 82, 80, 8, player2);
            players.Add(P1);
            players.Add(P2);
        }

        private void CountDown()
        {
            //Totem damages set to zero
            foreach(Totem t in totems)
            {
                t.damage = 0;
            }
            //Game countdown timer
            Graphics formGraphics = this.CreateGraphics();
            SolidBrush theBrush = new SolidBrush(Color.Black);
            Font drawfont = new Font("Courier New", 35);
            
            Refresh();

            //countdown to start of game
            for (int i = 3; i > 0; i--)
            {
                formGraphics.DrawString(Convert.ToString(i), drawfont, theBrush, (this.Width / 2) - 16, (this.Height / 2) - 63);
                Thread.Sleep(1000);
                this.Refresh();
            }

            gameTimer.Start();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            SetUp();
            CountDown();
            this.Focus();
        }

        private void GameScreen_KeyDown(object sender, KeyEventArgs e)
        {
            //Set booleans for keydown to true for keys that are down
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
                case Keys.Escape:
                    escape = true;
                    break;
                default:
                    break;
            }
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //Set booleans for keysdown to be false for keys that are up
            switch (e.KeyCode)
            {
                case Keys.N:
                    p1Up = false;
                    canJump1 = true;
                    break;
                case Keys.Space:
                    p1Down = false;
                    break;
                case Keys.V:
                    p2Up = false;
                    canJump2 = true;
                    break;
                case Keys.Z:
                    p2Down = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

            if (escape == true)
            {
                //call up mainscreen
                Form f = this.FindForm();
                MenuScreen ms = new MenuScreen();
                this.Controls.Add(ms);
                //TODO problems?
            }
            
            #region Player Movement
            //smash PLAYER 1
            if (p1Down == true && players[0].fall == false)
            {
                players[0].smash = true;
                players[0].jump = false;
                //totems[0].damage = totems[0].damage + (100 - players[0].y);
            }
            if (players[0].smash == true)
            {
                players[0].Smash(totems[0].y, 70);
            }

            //Jump PLAYER 1
            if (p1Up == true && canJump1 == true)
            {
                players[0].jump = true;
            }
                if (players[0].jump == true)
            {
                players[0].Jump(totems[0].y, 70);
            }

            //smash PLAYER 2
            if(p2Down == true && players[1].fall == false)
            {
                players[1].smash = true;
                players[1].jump = false;
            }
            if (players[1].smash == true)
            {
                players[1].Smash(totems[1].y, 82);

                #region Collision Check
                //Check for collision between player and totem(call Player.collision method)
                foreach (Totem T in totems)
                {
                    if (P2.Collision(P1, T) == true)
                    {
                        //Determine damage done to totem and send it to totem.damageDone Method
                        totems[1].DamageDone(totems[1].y - players[1].highest);
                        //Check if there’s totem left
                        if (totems[1].size - totems[1].damage < 1)
                        {
                            //If a totem is at the ground that player gets a point
                            p2Points++;
                            //Check if that player has three points, If yes EndGame
                            if (p2Points == 3) { EndGame(); }
                            //Else call up CountDown method to restart
                            else { CountDown(); }
                        }
                    }
                }

                #endregion

            }

            //jump PLAYER 2
            if (p2Up == true && canJump2 == true)
            {
                players[1].jump = true;
            }
            if (players[1].jump == true)
            {
                players[1].Jump(totems[1].y, 82);
            }
            #endregion
            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //Draw players from player list
            // Draw totems from totem list
            Brush drawBrush = new SolidBrush(Color.Black);
            foreach(Player p in players)
            {
                e.Graphics.DrawImage(p.playerImage[0], p.x, p.y); 
            }

            foreach(Totem t in totems) // x, y, height, width  //xy is bottom left corner
            {
                e.Graphics.FillRectangle(drawBrush, t.x, t.y + t.damage, 120, t.size - t.damage);
            }
        }

        private void EndGame()
        {
            //TODO the winner will be saved to an xml file
            //TODO the program will close and go back to the main Program
        }
        
    }
}
