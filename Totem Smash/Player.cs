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
        public int x, y, size, speed, highest, time, points;
        public int lowest = 150;
        public bool jump, fall, smash, canJump, checkCol, keysUp, keysDown;
        public bool canSmash = false;
        public Image[] playerImage = new Image[3];

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
        public void Jump (int totemY)
        {
            if (fall == true)
            {
                canSmash = false;
                y = y + speed;

                if (y + size > totemY)
                {
                    jump = false;
                    fall = false;
                    canJump = true;
                }

            }
            else
            {
                canSmash = true;
                y = y - speed;
            }
            
            if (y < 0)
            {
                fall = true;
                highest = y;
            }
        }
        
        public void Smash (int totemY)
        {
            canSmash = false;
            y = y + speed * 2;
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
