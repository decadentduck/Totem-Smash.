using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totem_Smash
{
    class Totem
    {
        public int x, y, size, damage;

        public Totem(int _x, int _y, int _size, int _damage) 
        {
            x = _x;
            y = _y;
            size = _size;
            damage = _damage;
        }

        /// <summary>
        /// changes variables according to how much damage was done
        /// </summary>
        /// <param name="_damage"></param>
        public void DamageDone(int _damage)
        {
            //make totem size change dependant on damage
            damage += _damage;
            y += damage;
            size -= damage;
            damage = 0;
        }
    }
}
