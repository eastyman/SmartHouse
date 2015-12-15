using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolHouse
{
    class Program
    {
        static void Main(string[] args)
        {
     
            IDictionary<string, Device> devDictionary = new Dictionary<string, Device>();
 
            while (true)
            {
                Console.Clear();
                foreach (var dev in devDictionary)
                {
                   Console.WriteLine("Название: " + dev.Value.ToString());
                }
                Console.WriteLine();
                Console.Write("Введите команду: ");

                string[] commands = Console.ReadLine().Split(' ');
                if (commands[0].ToLower() == "exit" & commands.Length == 1)
                {
                    return;
                }

                if (commands[0].ToLower() == "add")
                {
                    if (commands.Length == 3)
                    {
                        if (!devDictionary.ContainsKey(commands[2]))
                        {
                            switch (commands[1].ToLower())
                            {
                                case "fringe":
                                    devDictionary.Add(commands[2], new Fringe(commands[2],-20,5));
                                    Device lamp = new Device("FringeLamp");
                                    ((Fringe)devDictionary[commands[2]]).Lamp = lamp;
                                    break;
                                case "tvset":
                                    devDictionary.Add(commands[2], new TVSet(commands[2]));
                                    break;
                                case "oven":
                                    devDictionary.Add(commands[2], new Oven(commands[2], 100, 300));
                                    break;
                                case "microwave":
                                    devDictionary.Add(commands[2], new MicroWave(commands[2], 50, 250));
                                    break;
                                case "gamebox":
                                    devDictionary.Add(commands[2], new GameBox(commands[2]));
                                    break;
                                case "satellite":
                                    devDictionary.Add(commands[2], new Satellite(commands[2]));
                                    break;
                                case "common":
                                    devDictionary.Add(commands[2], new Device(commands[2]));
                                    break;
                                default:
                                    PossibleDevices();
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Help();
                        continue;
                    }
                    continue;                    
                }
                if (commands[0].ToLower() == "add" && devDictionary.ContainsKey(commands[2]))
                {
                    Console.WriteLine("Устройство с таким именем уже существует");
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadLine();
                    continue;
                }
       
                switch (commands[0].ToLower())
                {
                    case "del":
                        if (commands.Length != 2)
                        {
                            Help();
                            continue;
                        }
                        if (devDictionary.ContainsKey(commands[1]))
                        {
                            devDictionary.Remove(commands[1]);
                        }
                        else
                        {
                            Console.WriteLine("Устройство с таким названием не найдено");
                            Console.ReadLine();
                        }
                        break;
                    case "on":
                        if (commands.Length != 2)
                        {
                            Help();
                            continue;
                        }
                        if (devDictionary.ContainsKey(commands[1]))
                        {
                            devDictionary[commands[1]].On();
                        }
                        else
                        {
                            Console.WriteLine("Устройство с таким названием не найдено");
                            Console.ReadLine();
                        }
                        break;
                    case "off":
                        if (commands.Length != 2)
                        {
                            Help();
                            continue;
                        }
                        if (devDictionary.ContainsKey(commands[1]))
                        {
                            devDictionary[commands[1]].Off();
                        }
                        else
                        {
                            Console.WriteLine("Устройство с таким названием не найдено");
                            Console.ReadLine();
                        }
                        break; 
                    case "nextchannel":
                        if (commands.Length != 2)
                        {
                            Help();
                            continue;
                        }
                        if (devDictionary.ContainsKey(commands[1]))
                        {
                            if (devDictionary[commands[1]] is TVSet)
                            {
                               
                                ((TVSet)devDictionary[commands[1]]).nextChannel();
                                
                            }
                            else
                            {
                                Console.WriteLine("К данному устройству не применима операция переключения каналов");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Устройство с таким названием не найдено");
                            Console.ReadLine();
                        }
                        break;
                    case "prevchannel":
                        if (commands.Length != 2)
                        {
                            Help();
                            continue;
                        }
                        if (devDictionary.ContainsKey(commands[1]))
                        {
                            if (devDictionary[commands[1]] is TVSet)
                            {

                                ((TVSet)devDictionary[commands[1]]).prevChannel();
                                
                            }
                            else
                            {
                                Console.WriteLine("К данному устройству не применима операция переключения каналов");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Устройство с таким названием не найдено");
                            Console.ReadLine();
                        }
                        break;
                    case "connect":
                        if (commands.Length != 3)
                        {
                            Help();
                            continue;
                        }
                        if (devDictionary.ContainsKey(commands[1]) && devDictionary.ContainsKey(commands[2]))
                        {
                            if ((devDictionary[commands[1]] is TVSet) && (devDictionary[commands[2]] is ITVsourced))
                            {

                                ((TVSet)devDictionary[commands[1]]).SignalSource = ((ITVsourced)devDictionary[commands[2]]);
                               
                            }
                            else
                            {
                                Console.WriteLine("Данные устройства не совместимы");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Устройство с таким названием не найдено");
                            Console.ReadLine();
                        }
                        break;

                    case "disconnect":
                        if (commands.Length != 2)
                        {
                            Help();
                            continue;
                        }
                        if (devDictionary.ContainsKey(commands[1]))
                        {
                            if (devDictionary[commands[1]] is TVSet)
                            {

                                ((TVSet)devDictionary[commands[1]]).SignalSource = null;

                            }
                            else
                            {
                                Console.WriteLine("К устройству не применима данная команда");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Устройство с таким названием не найдено");
                            Console.ReadLine();
                        }
                        break;

                    case "open":
                        if (commands.Length != 2)
                        {
                            Help();
                            continue;
                        }
                        if (devDictionary.ContainsKey(commands[1]))
                        {
                            if (devDictionary[commands[1]] is TempereaturedDevice)
                            {

                                ((TempereaturedDevice)devDictionary[commands[1]]).OpenDoor();

                            }
                            else
                            {
                                Console.WriteLine("К устройству не применима данная команда");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Устройство с таким названием не найдено");
                            Console.ReadLine();
                        }
                        break;

                    case "close":
                        if (commands.Length != 2)
                        {
                            Help();
                            continue;
                        }
                        if (devDictionary.ContainsKey(commands[1]))
                        {
                            if (devDictionary[commands[1]] is TempereaturedDevice)
                            {

                                ((TempereaturedDevice)devDictionary[commands[1]]).CloseDoor();

                            }
                            else
                            {
                                Console.WriteLine("К устройству не применима данная команда");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Устройство с таким названием не найдено");
                            Console.ReadLine();
                        }
                        break;

                    case "uptemp":
                        if (commands.Length != 3)
                        {
                            Help();
                            continue;
                        }
                        if (devDictionary.ContainsKey(commands[1]))
                        {
                            if (devDictionary[commands[1]] is TempereaturedDevice)
                            {
                                int offset;
                                if (Int32.TryParse(commands[2], out offset))
                                {
                                    ((TempereaturedDevice)devDictionary[commands[1]]).highTemperature(offset);
                                }

                                else
                                {
                                    Console.WriteLine("Температура введена неправльно");
                                    Console.ReadLine();
                                }                                                
                                

                            }
                            else
                            {
                                Console.WriteLine("К устройству не применима данная команда");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Устройство с таким названием не найдено");
                            Console.ReadLine();
                        }
                        break;

                    case "downtemp":
                        if (commands.Length != 3)
                        {
                            Help();
                            continue;
                        }
                        if (devDictionary.ContainsKey(commands[1]))
                        {
                            if (devDictionary[commands[1]] is TempereaturedDevice)
                            {
                                int offset;
                                if (Int32.TryParse(commands[2], out offset))
                                {
                                    ((TempereaturedDevice)devDictionary[commands[1]]).lowTemperature(offset);
                                }

                                else
                                {
                                    Console.WriteLine("Температура введена неправльно");
                                    Console.ReadLine();
                                }


                            }
                            else
                            {
                                Console.WriteLine("К устройству не применима данная команда");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Устройство с таким названием не найдено");
                            Console.ReadLine();
                        }
                        break;
                   

                    default:
                        Help();
                        break;
                }
            }
        }
        private static void PossibleDevices()
        {
            Console.WriteLine("Список доступных устройств");
            Console.WriteLine("\tFringe - холодильник");
            Console.WriteLine("\tOven - духовка");
            Console.WriteLine("\tMicrowave - микроволновка");
            Console.WriteLine("\tTVSet -телевизор");
            Console.WriteLine("\tSatellite - спутниковый тюнер");
            Console.WriteLine("\tGameBox - игровая приставка");
            Console.WriteLine("\tCommon - любое другое устройство, которое можно просто включить или выключить");
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadLine();

        }
        private static void Help()
        {
            Console.WriteLine("Доступные команды:");
            Console.WriteLine("\t\tОбщие");
            Console.WriteLine("\tadd devType devName");
            Console.WriteLine("\tdel devName");
            Console.WriteLine("\ton devName");
            Console.WriteLine("\toff devName");
            Console.WriteLine("\texit");
            Console.WriteLine("\t\tУправление телевизорами");
            Console.WriteLine("\tnextchannel devName");
            Console.WriteLine("\tprevchannel devName");
            Console.WriteLine("\tConnect TVSetname sourceName");
            Console.WriteLine("\tDisconnect TVSetname");
            Console.WriteLine("\t\tУправление температурными устройствами");
            Console.WriteLine("\topen devName");
            Console.WriteLine("\tclose devName");
            Console.WriteLine("\tuptemp devName degrees ");
            Console.WriteLine("\tdowntemp devName degrees");              
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadLine();
        }
    }
}
