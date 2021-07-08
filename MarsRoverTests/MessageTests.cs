using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
    [TestClass]
    public class MessageTests
    {
        Message newMessage;
        string testName = "Guillermo";
        Command[] commands = { new Command("foo", 0), new Command("bar", 20) };

        [TestInitialize]
        public void CreateClassInstances()
        {
            newMessage = new Message("Test message with two commands", commands);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "User must provide name for message")]
        public void ArgumentNullExceptionThrownIfNameNotPassedToConstructor()
        {
            Message message1 = new Message("", commands);
        }

        [TestMethod]
        public void ConstructorSetsName()
        {
            Message message1 = new Message(testName);
            Assert.IsTrue(testName == message1.Name);
            Assert.AreEqual(testName, message1.Name);
        }

        [TestMethod]
        public void ConstructorSetsCommandsField()
        {
            Message message2 = new Message("foo", commands);
            Assert.AreEqual(commands, message2.Commands);
        }
    }
}