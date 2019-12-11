using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _GameProject
{
    public abstract class Remote
    {
        public bool left { get; set; }
        public bool right { get; set; }
        public bool up { get; set; }
        public bool down { get; set; }
        public abstract void Update();
    }

    public class JoyStick : Remote
    {
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }

    public class KeyBoard : Remote
    {
        public Keys leftk { get; set; }
        public Keys rightk { get; set; }
        public Keys upk { get; set; }
        public Keys downk { get; set; }
        public override void Update()
        {
            KeyboardState statekey = Keyboard.GetState();
            if (statekey.IsKeyDown(leftk))
                left = true;
            if (statekey.IsKeyUp(leftk))
                left = false;
            if (statekey.IsKeyDown(rightk))
                right = true;
            if (statekey.IsKeyUp(rightk))
                right = false;
        }
    }
}
