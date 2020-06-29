using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern.Interface
{
    public interface IPaymentInitiator
    {
        void setStrategy(IPaymentStrategy strategy);

        string executeStrategy();

    }
}
