using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolHouse
{
    public class Oven : TempereaturedDevice
    {
        public Oven(string name) : base(name)
        {
            this.name = name;
            minTemperature = 100;
            maxTemperature = 300;
        }

        public override string ToString()
        {
            string retStr="";
            if (State)
            {
                retStr = "включена";
            }
            if (!State)
            {
                retStr = "выключена";
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

            string tempElem = "";
            if (tempElement)
            {
                tempElem = "включено";
            }
            if (!tempElement)
            {
                tempElem = "выключено";
            }
            return "Духовка " + name + " " + retStr +" температура: " + Temperature +  ", дверь " + doorState + ", нагревание " + tempElem;
        }
    }
}
