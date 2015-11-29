using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolHouse
{
    public interface iSwitchable
    {
         bool State { get; set; }
         void On();
         void Off();
    }
}
