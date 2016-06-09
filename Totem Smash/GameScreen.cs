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
            this.Focus();
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
        int numOfPlayers = 2;
        #endregion

        private void SetUp()
        {
            totems.Clear();
            players.Clear();

            //Create a totem for each player
            Totem t = new Totem(100, 200, 0, 500);
            Totem tt = new Totem(500, 200, 0, 500);
            //Add totems to a list
            totems.Add(t);
            totems.Add(tt);

            P1 = new Player(t.x, t.y - 70, 80, 8, player1);
            P2 = new Player(tt.x, tt.y - 78, 80, 8, player2);
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
                f.Controls.Remove(this);
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
               //totems[1].damage = totems[1].damage + (100 - players[1].y);
            }
            if (players[1].smash == true)
            {
                players[1].Smash(totems[1].y, 78);
            }

            //jump PLAYER 2
            if (p2Up == true && canJump2 == true)
            {
                players[1].jump = true;
            }
            if (players[1].jump == true)
            {
                players[1].Jump(totems[1].y, 78);
            }
            Refresh();
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

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //TODO Draw players from player list
            // Draw totems from totem list
            Brush drawBrush = new SolidBrush(Color.Black);
            foreach(Player p in players)
            {
                e.Graphics.DrawImage(p.playerImage[0], p.x, p.y); 
            }

            foreach(Totem t in totems)
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
