using StrategyPattern.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StrategyPattern.Models
{
    public class PaymentRequest
    {
        public StrategyType PaymentMode { get; set; }
    }
}