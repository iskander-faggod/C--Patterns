using System;

namespace DesignPatterns.Patterns
{
    public delegate void QuantityUpdated(int quantity);
    public class Observer
    {
        private ConsoleColor _color;
        public Observer(ConsoleColor color)
        {
            _color = color;
        }

        internal void ObserverQuantity(int quantity)
        {
            Console.ForegroundColor = _color;
            Console.WriteLine($"observer with quantity {quantity}");
        }

        public static void Main()
        {
            var subject = new Subject();
            var greenObs = new Observer(ConsoleColor.Green);
            var redObs = new Observer(ConsoleColor.Red);
            var yellowObs = new Observer(ConsoleColor.Yellow);

            subject.OnQuantityUpdated += greenObs.ObserverQuantity;
            subject.OnQuantityUpdated += redObs.ObserverQuantity;
            subject.OnQuantityUpdated += yellowObs.ObserverQuantity;
            
            subject.UpdateQuantity(10);
            subject.UpdateQuantity(5);
        }
    }

    public class Subject
    {
        public int _quantity = 0;
        public event QuantityUpdated OnQuantityUpdated;

        public void UpdateQuantity(int value)
        {
            _quantity += value;
            OnQuantityUpdated.Invoke(_quantity);
        }
    }
}