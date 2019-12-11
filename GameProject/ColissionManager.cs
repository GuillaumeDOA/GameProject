using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
    class ColissionManager
    {
        public bool Update(Player p1, Player p2)
        {
            if (p1.CollisionRectangle.Intersects(p2.CollisionRectangle))
                return true;
            return false;
        }
    }
}
