using StrategyPattern.Interface;
using StrategyPattern.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrategyPattern.Implementations
{
    public class CreditCardPayment : IPaymentStrategy
    {

        string cardNumber;
        string name;
        string expiryDate;
        public CreditCardPayment(string _cardNumber, string _name, string _expiryDate)
        {
            cardNumber = _cardNumber;
            name = _name;
            expiryDate = _expiryDate;
        }
        public StrategyType strategyType => StrategyType.CreditCard;
        public string Pay()
        {
            Console.WriteLine("Amount paid using credit card");
            return "Amount paid using credit card";
        }
    }
}