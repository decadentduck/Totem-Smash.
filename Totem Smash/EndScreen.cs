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
        List<Score> scores = new List<Score>();
        string name;
        string points;

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
            if (GameScreen.winScore < Convert.ToInt32( scores[num - 1].points))
            {

                //TODO if so ask for name input & add it to list
                //TODO sort list by points
                //TODO remove at space 10
            }
            #endregion

            #region Highscore output
            //TODO print list to label
            for (int p = 0; p < 9; p++)
            {
                highscoresOutput.Text += Convert.ToString(p + 1) + ": " + scores[p].name + "    "
                    + scores[p].points + "\n";
            }
            #endregion
            
        }

        private void EndScreen_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Escape();
                    break;
            }
        }

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
    }
}
