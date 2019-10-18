﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Abstractions;
using Unosquare.WiringPi;
using System.Timers;
using RaspberryPiStates;
using Sensor;

namespace RaspberryPi
{
    public class Program
    {
        public void Init()
        {
        }
        static void Main(string[] args)
        {
            MagnetSensor Magnet = new MagnetSensor();
            LaserSensorBottom LaserBot = new LaserSensorBottom();
            LaserSensorTop LaserTop = new LaserSensorTop();
            Context context = new Context();
            RaspberryPiStates.RaspberryPiStates emptyState = new EmptyState();
            RaspberryPiStates.RaspberryPiStates fullState = new FullState();
            RaspberryPiStates.RaspberryPiStates notDoneState = new NotDoneState();
            Magnet.Initiate();
            LaserTop.Initiate();
            LaserBot.Initiate();
            context.setState(emptyState);

            while (true)
            {
                while (ReferenceEquals(context.getState(), emptyState))
                {
                    if (context.IsFull() == false)
                    {
                        context.setState(emptyState);
                        Thread.Sleep(5000);
                    }
                    else
                    {
                        context.setState(fullState);
                        Thread.Sleep(5000);
                    }
                }

                while (ReferenceEquals(context.getState(), fullState))
                {
                    if (context.IsFull() == true)
                    {
                        context.setState(fullState);
                        Thread.Sleep(5000);
                    }
                    else
                    {
                        context.setState(notDoneState);
                        Thread.Sleep(5000);
                    }
                }

                while (ReferenceEquals(context.getState(), notDoneState))
                {
                    if (context.IsFull() == false)
                    {
                        context.setState(notDoneState);
                        Thread.Sleep(5000);
                    }

                    else
                    {
                        context.setState(emptyState);
                        Thread.Sleep(5000);
                    }
                }
            }
        }
    }
}
