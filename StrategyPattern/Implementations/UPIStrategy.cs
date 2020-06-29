using StrategyPattern.Interface;
using StrategyPattern.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrategyPattern.Implementations
{
    public class UPIStrategy : IPaymentStrategy
    {
        string userName;

        public UPIStrategy(string _userName)
        {
            userName = _userName;
        }

        public StrategyType strategyType => StrategyType.UPI;

        public string Pay()
        {
            Console.WriteLine("Amount paid using UPI");
            return "Amount paid using UPI";
        }
    }
}