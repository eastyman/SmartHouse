using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolHouse
{
    public class Fringe : TempereaturedDevice
    {
        Device lamp;
        public Fringe(string name) : base(name)
        {
            this.name = name;
            minTemperature = -20;
            maxTemperature = 5;
            lamp = new Device("Light");
        }

        public override void OpenDoor()
        {
            lamp.On();
        }

        public override void CloseDoor()
        {
            lamp.Off();
        }

        public override string ToString()
        {
            string retStr = "";
            if (State)
            {
                retStr = "включен";
            }
            if (!State)
            {
                retStr = "выключен";
            }
            return "Холодильник " + name + " " + retStr+" температура "+Temperature+" лампочка "+lamp.ToString();
        }
    }
}
