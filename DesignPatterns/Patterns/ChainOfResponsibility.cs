using System;
using DesignPatterns.Patterns;

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

        public void SetNextServiceHandler(ServiceHandler handler)
        {
            _nextHandler = handler;
        }
        
        // сущности которые выполняют обслуживание
        
    }
    
    class Detailer : ServiceHandler
    {
        public Detailer() : base(ServiceRequirements.Dirty)
        {
        }
    }
    
    class Mechanic : ServiceHandler
    {
        public Mechanic() : base(ServiceRequirements.EngineTune)
        {
        }
    }
    
    class WheelMaster : ServiceHandler
    {
        public WheelMaster() : base(ServiceRequirements.WheelAlignment)
        {
        }
    }
    
    class QualityController : ServiceHandler
    {
        public QualityController() : base(ServiceRequirements.TestDrive)
        {
        }
    }
}

public class ChainOfResponsobility
{
    static void Main()
    {
        var mechanic = new Mechanic();
        var detailer = new Detailer();
        var wheelMaster = new WheelMaster();
        var qualityController = new QualityController();
        
        qualityController.SetNextServiceHandler(detailer);
        wheelMaster.SetNextServiceHandler(qualityController);
        mechanic.SetNextServiceHandler(wheelMaster);
    }
}