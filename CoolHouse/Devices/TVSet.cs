using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoolHouse
{
    public class TVSet:Device
    {
        public iTVsourced SignalSource { get; set; }  //Свойство для инъекции зависимости (подключение к телевизору внешнего устройства)
        public int currChannel;
        public TVSet(string devname, int channel):base(devname)
        {
            name = devname;
            currChannel = channel;
        }
        public void TranslateVideo()
        {
            SignalSource.StreamToTV();
        }
    }
}
