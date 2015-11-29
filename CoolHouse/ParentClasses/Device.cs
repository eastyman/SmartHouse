using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolHouse
{
    public class Device:iSwitchable
    {
        protected string name;
        public bool State { get; set; }
        public Device(string name)
        {
            this.name = name;
            State = false;
        }
        public virtual void On()
        {
            State = true;
        }
        public virtual void Off()
        {
            State = false;
        }

    }
}
