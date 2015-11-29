using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolHouse
{
    public class Satellite:Device, iTVsourced
    {
        public Satellite(string name):base(name)
        {
            this.name = name;
        }
        public void StreamToTV()
        {
            //some code to view video
        }
    }
}
