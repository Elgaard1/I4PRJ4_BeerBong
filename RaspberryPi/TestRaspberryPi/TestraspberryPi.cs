﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Sensor;
using RaspberryPiStates;
using RaspberryPi.Bluetooth;
using StopWatch;
using NUnit.Framework;
using RaspberryPi;

namespace TestRaspberryPi
{
    public class TestRaspberryPi
    {
        private ISensor _Sensor ;
        private Program _uut;
        private RaspberryPiStates.RaspberryPiStates _States;
        private MyStopWatch _StopWatch;
        private Bluetooth _Bluetooth;
        private Context _Context; 
        //private LaserSensorBottom uutBotSensor;
        //private LaserSensorTop uutTopSensor;
        [SetUp]
        public void setup()
        {
            //Arrange 
            _Sensor = Substitute.For<ISensor>(); 
            _uut = new Program();
            _States = Substitute.For<RaspberryPiStates.RaspberryPiStates>();
            _Context = Substitute.For<Context>();
            _StopWatch = Substitute.For<MyStopWatch>();
            _Bluetooth = Substitute.For<Bluetooth>(); 
            //uutBotSensor = new LaserSensorBottom();
            //uutTopSensor = new LaserSensorTop();
        }

        [Test]
        public void Test_Top_Sensor_ifHigh_or_ifLow()
        {
            _Sensor.Detected().Returns(false);
        }

        [Test]
        public void Test_What_state()
        {

            RaspberryPiStates.RaspberryPiStates result = _Context.getState();
            Assert.That(result,Is.EqualTo(new EmptyState()));
        }
    }
}
