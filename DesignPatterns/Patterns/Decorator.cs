using System;
using System.Collections.Generic;

namespace DesignPatterns.Patterns
{
    interface IMessage
    {
        void PrintMessage();
        
    }
    
    abstract class Message : IMessage
    {
        protected string _text;

        public Message(string text)
        {
            _text = text;
        }
        
        public abstract void PrintMessage();
    }

    class SimpleMessage : Message
    {
        public SimpleMessage(string text) : base(text)
        {
        }

        public override void PrintMessage()
        {
            Console.WriteLine(_text);
        }
    }
    
    class AlertMessage : Message
    {
        public AlertMessage(string text) : base(text)
        {
        }

        public override void PrintMessage()
        {
            Console.WriteLine(_text + "some alert text xD");
        }
    }
    
    // базовый класс декоратор для хранения ссылки на обьект Message
    abstract class MessageDecorator : IMessage
    {
        protected Message _message;

        protected MessageDecorator(Message message)
        {
            _message = message;
        }

        public abstract void PrintMessage();
    }
    
    class NormalDecorator : MessageDecorator
    {
        public NormalDecorator(Message message) : base(message)
        {
        }

        public override void PrintMessage()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            _message.PrintMessage();
            Console.ForegroundColor = ConsoleColor.Green;

        }
    }
    
    class ErrorMessage : MessageDecorator
    {
        public ErrorMessage(Message message) : base(message)
        {
        }

        public override void PrintMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            _message.PrintMessage();
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }
    
    public class DecoratorTest
    {
        /*static void Main(string[] args)
        {
            var messages = new List<IMessage>
            {
                new NormalDecorator(new SimpleMessage("First message")),
                new NormalDecorator(new AlertMessage("Second message with alert")),
                new ErrorMessage(new AlertMessage("Alert error message"))
            };
            
            messages.ForEach(message => message.PrintMessage());
        }*/
    }
}

