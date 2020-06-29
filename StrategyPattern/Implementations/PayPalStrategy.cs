using StrategyPattern.Interface;
using StrategyPattern.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrategyPattern.Implementations
{
    public class PayPalStrategy : IPaymentStrategy
    {
        string userName;
        string password;

        public PayPalStrategy(string _userName, string _password)
        {
            password = _password;
            userName = _userName;
        }
        public StrategyType strategyType => StrategyType.PayPal;
        public string Pay()
        {
            Console.WriteLine("Amount paid using PayPal");
            return "Amount paid using PayPal";
        }
    }
}