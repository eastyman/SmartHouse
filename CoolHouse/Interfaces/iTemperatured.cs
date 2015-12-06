using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolHouse
{
    public interface ITemperatured
    {
        int Temperature { get; set; }
        void highTemperature(int offset);
        void lowTemperature(int offest);     

    }
}
