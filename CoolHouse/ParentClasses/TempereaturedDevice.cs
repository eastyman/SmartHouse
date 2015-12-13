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
        protected  bool door;
        protected  bool tempElement;
        public TempereaturedDevice(string name) : base(name)
        {
            this.name = name;
            door = false;            
        }
        public int Temperature { get; set; }
       
        public void lowTemperature(int offset)
        {
            if (Temperature - offset >= minTemperature)
            {
                Temperature = Temperature - offset;
            }
            else
            {
                Temperature = minTemperature;
            }

            
        }
        public void highTemperature(int offset)
        {
            if (Temperature + offset <= maxTemperature)
            {
                Temperature = Temperature + offset;
            }
            else
            {
                Temperature = maxTemperature;
            }
        }
  
        public virtual void OpenDoor()
        {
            tempElement = false;
            door = true;
        }

        public virtual void CloseDoor()
        {
            if (State) 
            { 
                tempElement = true;
            }
            
            door = false;
        }

        public override void On()
        {
            base.On();
            if (!door) 
            {
                tempElement = true;
            }          
        }
        public override void Off()
        {
            base.Off();
            tempElement = false;
        }

    }
}
