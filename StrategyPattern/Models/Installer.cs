using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using StrategyPattern.Implementations;
using StrategyPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Context = StrategyPattern.Implementations.Context;

namespace StrategyPattern.Models
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //Need to Register controllers explicitly in your container
            //Failing to do so Will receive Exception:

            //> An error occurred when trying to create //a controller of type
            //> 'xxxxController'. Make sure that the controller has a parameterless
            //> public constructor.

            //Reason::Basically, what happened is that you didn't register your controllers explicitly in your container. 
            //Windsor tries to resolve unregistered concrete types for you, but because it can't resolve it (caused by an error in your configuration), it return null.
            //It is forced to return null, because Web API forces it to do so due to the IDependencyResolver contract. 
            //Since Windsor returns null, Web API will try to create the controller itself, but since it doesn't have a default constructor it will throw the "Make sure that the controller has a parameterless public constructor" exception.
            //This exception message is misleading and doesn't explain the real cause.

            container.Register(
            Component.For<IPaymentStrategy, CreditCardPayment>()
                .DynamicParameters((kernel, parameters) =>
                { parameters["_cardNumber"] = "XXXX YYYY ZZZZ WWWW";
                  parameters["_name"] = "Test User";
                  parameters["_expiryDate"] = DateTime.Now.AddYears(10);
                }),
            Component.For<IPaymentStrategy, PayPalStrategy>()
                .DynamicParameters((kernel, parameters) =>
                {
                    parameters["_userName"] = "Test User";
                    parameters["_password"] = "TestUser";
                }),
            Component.For<IPaymentStrategy, UPIStrategy>()
                .DynamicParameters((kernel, parameters) =>
                {
                    parameters["_userName"] = "TestUser@upi";
                })
            );
            container.Register(
            Classes.FromThisAssembly().BasedOn<ApiController>().LifestyleScoped());

            container.Register(
             Classes.FromThisAssembly().IncludeNonPublicTypes().BasedOn<IPaymentStrategy>()
            .WithService.FromInterface(),
            Component.For<IPaymentInitiator>().ImplementedBy<Context>(),
            Component.For<IPaymentStrategyResolver>().ImplementedBy<PaymentStrategyResolver>());

            IEnumerable<IPaymentStrategy> someCollection = new List<IPaymentStrategy>();
            container.Register(Component.For<IEnumerable<IPaymentStrategy>>().Instance(someCollection));

        }
    }
}