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
        list<Score>

        public EndScreen()
        {
            InitializeComponent();
        }

        private void EndScreen_Load(object sender, EventArgs e)
        {

            // Open the file to be read
            XmlTextReader reader = new XmlTextReader("highscores.xml");

            while (reader.Read())
            {
                // If the currently read item is text then print it to screen,
                // otherwise the loop repeats getting the next piece of information
                if (reader.NodeType == XmlNodeType.Text)
                {

                }

                // When done reading the file close it
                reader.Close();
            }
    }
}
