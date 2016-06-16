using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Totem_Smash
{
    
    class Player
    {
        public int x, y, size, speed, highest;
        public bool jump, fall, smash, canJump, checkCol;
        public Image[] playerImage = new Image[4];

        public Player(int _x, int _y, int _size, int _speed, Image[] _player)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            playerImage = _player;
        }

        /// <summary>
        /// Jump Method
        /// </summary>
        /// <param name="totemY"></param>
        /// <param name="playerSize"></param>
        public void Jump (int totemY, int playerSize)
        {
            if (fall == true)
            {
                y = y + speed;

                if (y + playerSize > totemY)
                {
                    jump = false;
                    fall = false;
                }
            }
            else { y = y - speed; }
            
            if (y < 0)
            {
                fall = true;
                highest = y;
            }
            
        }
        
        public void Smash (int totemY, int playerSize)
        {
            y = y + speed;
            checkCol = true;
        }
        
        public bool Collision(Player p, Totem t)
        {
            Rectangle pRec = new Rectangle(p.x, p.y, p.size, p.size);
            Rectangle tRec=new Rectangle(t.x, t.y, t.size, t.size);

            if (pRec.IntersectsWith(tRec))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
