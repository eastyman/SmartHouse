using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolHouse
{
    public class TempereaturedDevice:Device, iTemperatured
    {
        public TempereaturedDevice(string name) : base(name)
        {
            this.name = name;
        }
        public int Temperature { get; set; }
    }
}
