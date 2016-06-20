﻿using System;
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
        /// <param name="totemY"></param>totems Y value for this player
        public void Jump (int totemY)
        {
            //find highest point player jumped to determine damage later
            if (y < highest) { highest = y; }

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
                    highest = y;
                }
            }
        }

        /// <summary>
        /// Smash method
        /// </summary>
        public void Smash ()
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
