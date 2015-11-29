using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolHouse
{
    public class MicroWave : TempereaturedDevice
    {
        public MicroWave(string name) : base(name)
        {
            this.name = name;
        }
    }
}
