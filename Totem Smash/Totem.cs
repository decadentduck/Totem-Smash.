using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Totem_Smash
{
    class Totem
    {
        public int x, y, damage, size;

        public Totem(int _x, int _y, int _damage, int _size) 
        {
            x = _x;
            y = _y;
            size = _size;
            damage = _damage;
        }

        public void DamageDone(int _damage)
        {
            //TODO make totem size change dependant on damage
            //damage = 
        }
    }
}
