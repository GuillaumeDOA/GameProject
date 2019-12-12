using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    class ColissionManager
    {
        public bool Update(Player p1, Player p2)
        {
            if (p1.CollisionRectangle.Intersects(p2.CollisionRectangle))
                return true;
            return false;
        }
        public bool Update(Player p1, Block ground)
        {
            if (p1.CollisionRectangle.Intersects(ground.CollisionRectangle))
                return true;
            return false;
        }
    }
}
