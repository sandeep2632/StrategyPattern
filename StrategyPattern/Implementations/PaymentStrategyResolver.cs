using StrategyPattern.Interface;
using StrategyPattern.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrategyPattern.Implementations
{
    /// <summary>
    /// Resolve the Payment Strategy based on mode of Payment
    /// </summary>
    public class PaymentStrategyResolver : IPaymentStrategyResolver
    {
        private readonly IEnumerable<IPaymentStrategy> _paymentStrategies;

        public PaymentStrategyResolver(IEnumerable<IPaymentStrategy> paymentStrategies)
        {
            _paymentStrategies = paymentStrategies;
        }
        public IPaymentStrategy Resolve(StrategyType type)
        {
            IPaymentStrategy paymentStrategy = _paymentStrategies.FirstOrDefault(item => item.strategyType == type);
            
            return paymentStrategy;
        }
    }
}