using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolHouse
{
    public class TempereaturedDevice:Device, ITemperatured
    {
        protected  int minTemperature;
        protected  int maxTemperature;
        public TempereaturedDevice(string name) : base(name)
        {
            this.name = name;
        }
        public int Temperature { get; set; }
        public void lowTemperature(int offset)
        {
            if (Temperature - offset > minTemperature)
            {
                Temperature -= offset;
            }
            
        }
        public void highTemperature(int offset)
        {
            if (Temperature + offset < maxTemperature)
            {
                Temperature += offset;
            }

        }

        public virtual void OpenDoor()
        {
            State = false;
        }

        public virtual void CloseDoor()
        {
            State = true;
        }

    }
}
