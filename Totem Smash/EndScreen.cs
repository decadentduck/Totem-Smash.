using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Totem_Smash
{
    public partial class EndScreen : UserControl
    {
        #region lists and variables
        List<Score> scores = new List<Score>();
        string name;
        string points;
        int letter = 0;
        int l1 = 65;
        int l2 = 65;
        #endregion

        public EndScreen()
        {
            InitializeComponent();
        }

        private void EndScreen_Load(object sender, EventArgs e)
        {
            this.Focus();

            highscoresOutput.Text = "";

            #region xml reader
            // Open the file to be read
            XmlTextReader reader = new XmlTextReader("highscores.xml");

            int i = 1;

            while (reader.Read())
            {
                // If the currently read item is text then print it to screen,
                // otherwise the loop repeats getting the next piece of information
                if (reader.NodeType == XmlNodeType.Text)
                {
                    if (i == 1) { name = reader.Value; i++; }
                    else if (i == 2)
                    {
                        points = reader.Value;
                        i--;
                        Score s = new Score(name, points);
                        scores.Add(s);
                    }
                }
            }
            // When done reading the file close it
            reader.Close();
            #endregion

            #region new highscore? 
            //TODO determine if player's score is a highscore
            int num = scores.Count();
            if (GameScreen.winScore < Convert.ToInt32(scores[num - 1].points))
            {
                //TODO if so ask for name input & add it to list
                letter1.Visible = true;
                letter2.Visible = true;
                scoreOutput.Visible = true;
                highscoresOutput.Visible = false;

                scoreOutput.Text = Convert.ToString(GameScreen.winScore);
                letter = 1;

            }
            #endregion
            else { DrawScores(); }
        }

        private void EndScreen_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Escape();
                    break;
                case Keys.N:
                    if (letter == 1)
                    {
                        if (l1 == 90) { l1 = 65; }
                        else { l1++; }
                    }
                    else if (letter == 2)
                    {
                        if (l2 == 90) { l2 = 65; }
                        else { l2++; }
                    }
                    break;
                case Keys.Space:
                    if (letter == 1)
                    {
                        if (l1 == 65) { l1 = 90; }
                        else { l1--; }
                    }
                    if (letter == 2)
                    {
                        if (l2 == 65) { l2 = 90; }
                        else { l2--; }
                    }
                    break;
                case Keys.M:
                    if (letter == 1) { letter = 2; }
                    else
                    {
                        #region enter highscore
                        letter1.Visible = false;
                        letter2.Visible = false;
                        scoreOutput.Visible = false;
                        highscoresOutput.Visible = true;

                        Score s = new Score(letter1.Text + letter2.Text, Convert.ToString(GameScreen.winScore));

                        int a = 10;
                        for (int i = 9; i > -1; i--)
                        {
                            if (Convert.ToInt32(s.points) <= Convert.ToInt32(scores[i].points))
                            {
                                a = i;
                            }
                        }

                        scores.Insert(a, s);
                        scores.RemoveAt(10);
                        #endregion

                        DrawScores();
                    }
                    break;
            }

            Char c1 = (Char)l1;
            letter1.Text = Convert.ToString(c1);
            Char c2 = (Char)l2;
            letter2.Text = Convert.ToString(c2);
        }

        /// <summary>
        /// writes highscores to xml file and returns to menu
        /// </summary>
        private void Escape()
        {

            #region xml writer
            XmlTextWriter writer = new XmlTextWriter("highscores.xml", null);

            writer.WriteStartElement("Scores");
            for (int i = 0; i < scores.Count(); i++)
            {
                writer.WriteStartElement("score");

                writer.WriteElementString("name", scores[i].name);
                writer.WriteElementString("points", Convert.ToString(scores[i].points));

                writer.WriteEndElement();
            }

            writer.WriteEndElement();

            writer.Close();
            #endregion

            //call up mainscreen
            Form f = this.FindForm();
            f.Controls.Remove(this);
            MenuScreen ms = new MenuScreen();
            f.Controls.Add(ms);
        }

        private void DrawScores()
        {
            #region Highscore output
            highscoresOutput.Visible = true;
            //print list to label
            for (int p = 0; p < 9; p++)
            {
                highscoresOutput.Text += Convert.ToString(p + 1) + ": " + scores[p].name + "    "
                    + scores[p].points + "\n";
            }
            #endregion
        }
    }
}
