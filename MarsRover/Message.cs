using System;
namespace MarsRover
{
    public class Message
    {
        public string Name { get; set; }
        public Command[] Commands { get; set; }

        public Message(string name)
        {
            this.Name = name;
        }

        public Message(string name, Command[] commands)
        {
            this.Name = name;
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("Message name required.");

            this.Commands = commands;
        }
    }
}