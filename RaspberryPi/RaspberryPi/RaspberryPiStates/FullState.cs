﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Timers;
using RaspberryPi.Bluetooth;
using Sensor;
using StopWatch;

namespace RaspberryPiStates
{
    public class FullState : RaspberryPiStates
    {
        LaserSensorBottom LaserBot = new LaserSensorBottom();
        LaserSensorTop LaserTop = new LaserSensorTop();
        MagnetSensor Magnet = new MagnetSensor();
        Bluetooth bt = new Bluetooth();
        //StopWatch1 Timer = new StopWatch1();

        public override bool IsFull(StopWatch1 Timer)
        {
            bt.Init();
            Console.WriteLine("This is Fullstate");
            if (LaserTop.Detected() == false)
            {
                bt.SendData("Fullstate - Beerbong is ready");
                Console.WriteLine("BeerBong is full and you can start drinking!");
                return true; 
            }

            if (LaserTop.Detected() == true && Magnet.Detected() == true)
            {
                Timer.StartTimer();
                bt.SendData("Fullstate - You have started drinking");
                Console.WriteLine("You have started drinking START TIMER");
                return false;
            }
            else
            {
                Console.WriteLine("This should not happen");
                
                throw new Exception("error in fullstate");
                
            }
        }

    }
}
