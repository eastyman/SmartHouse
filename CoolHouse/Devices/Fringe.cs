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

        public override void On()
        {
            State = true;            
            if (door)
            {
                
                lamp.On();
            }
            tempElement = true;
        }

        public override void Off()
        {
            base.Off();
            lamp.Off();
        }

       

        public override void OpenDoor()
        {
            if (State)
            {
                lamp.On();
            }            
            door = true;
        }

        public override void CloseDoor()
        {
            lamp.Off();
            door = false;
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
            string doorState = "";
            if (door)
            {
                doorState = "открыта";
            }
            if (!door)
            {
                doorState = "закрыта";
            }
            return "Холодильник " + name + " " + retStr + " температура: " + Temperature + " лампочка " + lamp.ToString() + " Дверь " + doorState;
        }
    }
}
