using System;

namespace DesignPatterns.Patterns
{
    [Flags]
    enum ServiceRequirements
    {
        None = 0,
        WheelAlignment = 1,
        Dirty = 2, 
        EngineTune = 3,
        TestDrive = 4
    }

    class Car
    {
        public ServiceRequirements Requirements { get; set; }

        public bool IsServiceComplete => Requirements == ServiceRequirements.None;
    }

    abstract class ServiceHandler
    {
        protected ServiceHandler _nextHandler;
        protected ServiceRequirements _servicesProvided;

        protected ServiceHandler(ServiceRequirements servicesProvided)
        {
            _servicesProvided = servicesProvided;
        }

        public void Service(Car car)
        {
            if (_servicesProvided == (car.Requirements & _servicesProvided))
            {
                // происходить обслуживание 
                car.Requirements &= _servicesProvided;
            }

            if (car.IsServiceComplete || _nextHandler is null)
            {
                return;
            }
            else
            {
                _nextHandler.Service(car);
            }
        }
    }
}