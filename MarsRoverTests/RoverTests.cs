using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {
        [TestMethod]
        public void ConstructorSetsDefaultPoition()
        {
            Rover c3po = new Rover(0);
            Assert.AreEqual(c3po.Position, 0);
        }

        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Rover r2d2 = new Rover(0);
            Assert.AreEqual(r2d2.Mode, "NORMAL");
        }

        [TestMethod]
        public void ConstructorSetsDefaultGeneratorWatts()
        {
            Rover bb8 = new Rover(0);
            Assert.AreEqual(bb8.GeneratorWatts, 110);
        }

        [TestMethod]
        public void RespondsCorrectlyToModeChangeCommand()
        {
            Rover falcon = new Rover("LOW_POWER");
            Assert.AreEqual(falcon.Mode, "LOW_POWER");

        }

        [TestMethod]
        public void DoesNotMoveInLowPower()
        {
            Command[] commands = { new Command("MODE_CHANGE", "LOW_POWER"), new Command("MOVE", 5000) };
            Message newMessage = new Message("Test message with one command", commands);
            Rover xwing = new Rover(0);
            Assert.AreEqual(xwing.Position, 0);
            xwing.ReceiveMessage(newMessage);
        }

        [TestMethod]
        public void PositionChangesFromMoveCommand()
        {
            Rover ywing = new Rover(0);
            Command[] commands = { new Command("MOVE", 5000) };
            Message newMessage = new Message("Test message with one command", commands);
            ywing.ReceiveMessage(newMessage);
            Assert.AreEqual(ywing.Position, 5000);
        }
    }
}
