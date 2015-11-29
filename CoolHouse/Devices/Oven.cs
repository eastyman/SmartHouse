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
        }
    }
}
