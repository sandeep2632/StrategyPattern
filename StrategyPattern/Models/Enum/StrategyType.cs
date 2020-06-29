using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StrategyPattern.Models.Enum
{
    [Flags]
    public enum StrategyType
    {
        [Description("Credit Card Payment.")]
        CreditCard=1,
        [Description("Unified Payments Interface.")]
        UPI=2,
        [Description("PayPal Money Tranfer. ")]
        PayPal=3
    }  
}