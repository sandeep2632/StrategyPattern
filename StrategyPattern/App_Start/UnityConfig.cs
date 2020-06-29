using StrategyPattern.Implementations;
using StrategyPattern.Interface;
using System;
using System.Collections.Generic;
using System.Web.Http;
using Unity;
using Unity.Injection;
using Unity.WebApi;

namespace StrategyPattern
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();\

            container.RegisterType<IPaymentInitiator, Context>();
            container.RegisterType<IPaymentStrategyResolver, PaymentStrategyResolver>();
            container.RegisterType<IPaymentStrategy, CreditCardPayment>("CreditCardPayment", new InjectionConstructor(new object[] { "XXXX YYYY ZZZZ WWWW" , "Test User", ""}));
            container.RegisterType<IPaymentStrategy, UPIStrategy>("UPIStrategy", new InjectionConstructor(new object[] { "TestUser@upi" }));
            container.RegisterType<IPaymentStrategy, PayPalStrategy>("PayPalStrategy", new InjectionConstructor(new object[] { "Test User", "Test User" }));
           

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}