using StrategyPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrategyPattern.Implementations
{
    public class Context : IPaymentInitiator
    {
        private IPaymentStrategy _strategy;
  
        public string executeStrategy()
        {
            return _strategy.Pay();
        }

        public void setStrategy(IPaymentStrategy strategy)
        {
            _strategy = strategy;
        }
    }
}