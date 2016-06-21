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
        int points;

        public EndScreen()
        {
            InitializeComponent();
        }

        private void EndScreen_Load(object sender, EventArgs e)
        {
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
                        points = Convert.ToInt16(reader.Value);
                        i--;
                        Score s = new Score(name, points);
                        scores.Add(s);
                    }
                }

                // When done reading the file close it
                reader.Close();
            }
            #endregion

            //TODO determine if player's score is a highscore
            if(GameScreen.winScore < scores[11].points)
            {

                //TODO if so ask for name input & add it to list
                //TODO sort list by points
                //TODO remove at space 11
            }

            highscoresOutput.Text = "";
            //TODO print list to label
            for (int p = 0; p<10; p++)
            {
                highscoresOutput.Text += Convert.ToString(p + 1) + ": " + scores[p].name + "    " 
                    + scores[p].points + "\n";
            }
        }

        private void EndScreen_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    #region xml writer
                    //TODO write to xml file

                    XmlTextWriter writer = new XmlTextWriter("highscores.xml", null);

                    //Write the "Class" element
                    writer.WriteStartElement("Scores");
                    for (int i = 0; i < scores.Count(); i++)
                    {

                        writer.WriteStartElement("score");

                        ////Write sub-elements
                        writer.WriteElementString("name", scores[i].name);
                        writer.WriteElementString("points", Convert.ToString(scores[i].points));

                        writer.WriteEndElement();
                    }

                    // end the "Class" element
                    writer.WriteEndElement();

                    //Write the XML to file and close the writer
                    writer.Close();
                    #endregion
                
                    //call up mainscreen
                    Form f = this.FindForm();
                    f.Controls.Remove(f);
                    MenuScreen ms = new MenuScreen();
                    f.Controls.Add(ms);
                    break;
            }
        }
    }
}
