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
        public int x, y, size, speed;
        Image[] player = new Image[4];

        public Player(int _x, int _y, int _size, int _speed, Image[] _player)
        {
            x = _x;
            y = _y;
            size = _size;
            speed = _speed;
            player = _player;
        }

        //TODO Jump method
        public void Jump (Player P)
        {

        }

        //TODO smash method
        public void Smash (Player P)
        {

        }

        //TODO collision method
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
