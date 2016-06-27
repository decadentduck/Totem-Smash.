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
using System.Media;

namespace Totem_Smash
{
    public partial class GameScreen : UserControl
    {
        public GameScreen()
        {
            InitializeComponent();
        }

        #region ints lists arrays

        Player P1, P2;
        List<Player> players = new List<Player>();
        List<Totem> totems = new List<Totem>();

        public static int winScore= 1000000;

        //Image array for each Player
        Image[] player1 = { Properties.Resources.p1down, Properties.Resources.p1up, Properties.Resources.p1Fallingl };
        Image[] player2 = { Properties.Resources.p2Down, Properties.Resources.p2Up, Properties.Resources.p2Falling };

        SoundPlayer jump1Sound = new SoundPlayer(Properties.Resources.Jump1);
        SoundPlayer jump2Sound = new SoundPlayer(Properties.Resources.Jump2);
        public static SoundPlayer fallSound = new SoundPlayer(Properties.Resources.fall);        SoundPlayer smashSound = new SoundPlayer(Properties.Resources.smash);
        #endregion

        /// <summary>
        /// Sets up everything for the new game
        /// </summary>
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

            P1 = new Player(t.x + 10, t.y - 82, 80, 8, player1);
            P2 = new Player(tt.x + 10, tt.y - 82, 80, 8, player2);
            players.Add(P1);
            players.Add(P2);
        }

        /// <summary>
        /// Resets all values for the next round
        /// </summary>
        private void CountDown()
        {
            //reset player values and positions
            foreach(Player p in players)
            {
                p.canJump = true;
                p.canSmash = false;
                p.y = 68;
                p.lowest = 150;
                p.highest = 150;
            }

            //Reset Totem damages set to zero
            foreach (Totem t in totems)
            {
                t.y = 150;
                t.damage = 0;
                t.size = 500;
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
                    players[0].keysUp = true;
                    break;
                case Keys.Space:
                    players[0].keysDown = true;
                    break;
                case Keys.V:
                    players[1].keysUp = true;
                    break;
                case Keys.Z:
                    players[1].keysDown = true;
                    break;
                case Keys.Escape:
                    Escape();
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
                    players[0].keysUp = false;
                    break;
                case Keys.Space:
                    players[0].keysDown = false;
                    break;
                case Keys.V:
                    players[1].keysUp = false;
                    break;
                case Keys.Z:
                    players[1].keysDown = false;
                    break;
                default:
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //counter for totems
            int i = -1;
            foreach (Player p in players)
            {
                i++;
                p.time++;

                #region Player Movement

                //smash
                if (p.keysDown == true && p.canSmash == true)
                {
                    p.smash = true;
                    p.jump = false;
                }
                if (p.smash == true)
                {
                    p.Smash();
                }

                //Jump 
                if (p.keysUp == true && p.canJump == true)
                {
                    p.jump = true;
                    p.canJump = false;
                    if (i == 0) { jump1Sound.Play(); }
                    if( i == 1) { jump2Sound.Play(); }
                }
                if (p.jump == true)
                {
                    p.Jump(totems[i].y);
                }

                //find highest point player jumped to determine damage later
                if (p.y < p.highest) { p.highest = p.y; }
                else if (p.y > p.lowest) { p.lowest = p.y; }

                #endregion

                #region Collision Check
                if (p.checkCol)
                {
                    //Check for collision between player and totem
                    foreach (Player P in players)
                    {
                        if (P.Collision(P, totems[i]) == true)
                        {
                            smashSound.Play();
                            P.smash = false;
                            P.canJump = true;

                            //Determine damage done to totem and send it to totem.damageDone Method
                            int damage = Convert.ToInt16((P.lowest - P.highest - p.size) /2);
                            totems[i].DamageDone(damage);

                            P.y = totems[i].y - P.size;
                            p.lowest = p.y;
                            p.highest = p.y;

                            //Check if there’s totem left
                            if (totems[i].size - totems[i].damage < 1)
                            {
                                p.points++;
                                if (p.points == 3)
                                {
                                    //label to determine winner
                                    winnerLabel.Visible = true;
                                    winScore = p.time;
                                    Thread.Sleep(1000);
                                    EndGame();
                                }
                                else { CountDown(); }
                            }
                        }
                    }
                    p.checkCol = false;
                }

                #endregion
            }

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //Draw players from player list
            Brush drawBrush = new SolidBrush(Color.Black);
            foreach(Player p in players)
            {
                if (p.jump == true)
                {
                    if (p.fall == true) { e.Graphics.DrawImage(p.playerImage[1], p.x, p.y); }
                    else { e.Graphics.DrawImage(p.playerImage[2], p.x, p.y); }
                }
                else if (p.smash == true) { e.Graphics.DrawImage(p.playerImage[1], p.x, p.y); }
                else { e.Graphics.DrawImage(p.playerImage[0], p.x, p.y); }
                
            }

            //Draw totems from totem list
            foreach (Totem t in totems) 
            {
                e.Graphics.FillRectangle(drawBrush, t.x, t.y, 120, t.size);
            }

            //update point labels
            point1Label.Text = "Player 1 points: " + players[0].points;
            point2Label.Text = "Player 2 points: " + players[1].points;
        }

        /// <summary>
        /// call up Main Screen
        /// </summary>
        private void Escape()
        {
            //call up mainscreen
            Form f = this.FindForm();
            f.Controls.Remove(f);
            MenuScreen ms = new MenuScreen();
            f.Controls.Add(ms);
        }

        /// <summary>
        /// call up highscore screen
        /// </summary>
        private void EndGame()
        {
            //the program will close and go back to the main Program
            Form f = this.FindForm();
            f.Controls.Remove(this);
            EndScreen es = new EndScreen();
            f.Controls.Add(es);
        }
        
    }
}
