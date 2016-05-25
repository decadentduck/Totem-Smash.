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

        //TODO smash method

        //TODO collision method

    }
}
