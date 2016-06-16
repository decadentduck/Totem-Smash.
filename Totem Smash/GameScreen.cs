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

        bool p1Up, p2Up, p1Down, p2Down, escape;
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
            players[0].canJump = true;
            players[1].canJump = true;

            //Totem damages set to zero
            foreach (Totem t in totems)
            {
                t.damage = 0;
            }

            #region Game countdown timer
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
            #endregion

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
            if (p1Up == true && players[0].canJump == true)
            {
                players[0].jump = true;
                players[0].canJump = false;
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
            }
            
            //jump PLAYER 2
            if (p2Up == true && players[1].canJump == true)
            {
                players[1].jump = true;
                players[1].canJump = false;
            }
            if (players[1].jump == true)
            {
                players[1].Jump(totems[1].y, 82);

            }
            #endregion

            Refresh();
            for (int i = 0; i < 2; i++)
            {
                if (players[i].checkCol)
                {
                    #region Collision Check

                    //Check for collision between player and totem(call Player.collision method)
                    foreach (Player P in players)
                    {
                        if (P.Collision(P, totems[i]) == true)
                        {
                            P.smash = false;
                            P.canJump = true;

                            //Determine damage done to totem and send it to totem.damageDone Method
                            int damage = Convert.ToInt16((totems[i].y - P.highest) / 100);
                            totems[i].DamageDone(damage);

                            P.y = totems[i].y - 82;

                            //Check if there’s totem left
                            if (totems[i].size - totems[i].damage < 1)
                            {
                                if (i == 0)
                                {
                                    p1Points++;
                                    if (p1Points == 3) { EndGame(); }
                                    else { SetUp(); CountDown(); }
                                }
                                if (i == 1)
                                {
                                    p2Points++;
                                    if (p2Points == 3) { EndGame(); }
                                    else { SetUp(); CountDown(); }
                                }
                            }
                        }
                    }
                    #endregion

                    players[i].checkCol = false;
                }
            }
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //Draw players from player list
            //Draw totems from totem list
            Brush drawBrush = new SolidBrush(Color.Black);
            foreach(Player p in players)
            {
                e.Graphics.DrawImage(p.playerImage[0], p.x, p.y); 
            }

            foreach(Totem t in totems) 
            {
                t.size = t.size - t.damage;
                t.damage = 0;
                e.Graphics.FillRectangle(drawBrush, t.x, t.y, 120, t.size);
            }
        }

        private void EndGame()
        {
            //TODO the winner will be saved to an xml file
            //TODO the program will close and go back to the main Program
        }
        
    }
}
