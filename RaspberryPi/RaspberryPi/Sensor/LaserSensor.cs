﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;

namespace Sensor
{
    class LaserSensor
    {
        
        public void Initiate()
        {
            Pi.Init<BootstrapWiringPi>();
        }
        public bool Detect()
        { 
            var Laser_Top = Pi.Gpio[7];
            //TimeSpan
            Laser_Top.PinMode = GpioPinDriveMode.Input;
            //GPIO_21.ReadValue();
            while (true)
            {
                if (Laser_Top.Read() == false)
                {
                    Console.WriteLine("No laser detected");
                    //System.Threading.Thread.Sleep(1000);
                    return false;
                }
                if (Laser_Top.Read() == true)
                {
                    Console.WriteLine("Laser detected");
                    //System.Threading.Thread.Sleep(1000);
                    return true;
                }
            }
        }

    }
}
