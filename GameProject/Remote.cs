using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _710_InLes
{
    abstract class  Remote
    {
        public bool ToLeft { get; set; }
        public bool ToRight { get; set; }
        public abstract void Update();
        
    }
    class keyboard : Remote
    {
        public override void Update()
        {
            
        }
    }
}
