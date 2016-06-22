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
        #region variables and arrays
        public int x, y, size, speed, time, points;
        public int highest = 150;
        public int lowest = 150;
        public bool jump, fall, smash, canJump, checkCol, keysUp, keysDown;
        public bool canSmash = false;
        public Image[] playerImage = new Image[3];
        #endregion

        public Player(int _x, int _y, int _size, int _speed, Image[] _player)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            playerImage = _player;
        }

        /// <summary>
        /// Jump Method to make character jump
        /// </summary>
        /// <param name="totemY"></param>totems Y value for this player
        public void Jump(int totemY)
        {

            //falling
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

            //jumping
            else
            {
                canSmash = true;
                y = y - speed;

                //if at top of screen then fall
                if (y < 0)
                {
                    fall = true;
                }
            }
        }

        /// <summary>
        /// Smash method to make player smash
        /// </summary>
        public void Smash()
        {
            canSmash = false;
            y = y + speed * 2;
            checkCol = true;
        }

        /// <summary>
        /// Determines if player has touched totem yet
        /// </summary>
        /// <param name="p"></param> Player
        /// <param name="t"></param> Totem
        /// <returns></returns>
        public bool Collision(Player p, Totem t)
        {
            Rectangle pRec = new Rectangle(p.x, p.y, p.size, p.size);
            Rectangle tRec = new Rectangle(t.x, t.y, t.size, t.size);

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
