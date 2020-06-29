using StrategyPattern.Interface;
using StrategyPattern.Models;
using StrategyPattern.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StrategyPattern.Controllers
{
    public class ValuesController : ApiController
    {
        IPaymentStrategyResolver _resolver;
        IPaymentInitiator _initiator;
        private StrategyType value;

        // GET api/values

        public ValuesController(IPaymentStrategyResolver resolver, IPaymentInitiator initiator)
        {
            _resolver = resolver;
            _initiator = initiator;
        }
        public string Get()
        {
            return string.Empty;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        // POST api/values
        /// <summary>
        /// request body example :  {
        ///                            "paymentmode":3
        ///                         }
        ///                         paymentmode => 1: Creditcard 2.UPI 3. PayPal
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string Post([FromBody]PaymentRequest request)
        {
            bool success = Enum.IsDefined(typeof(StrategyType), request.PaymentMode);
            if (success)
                value = (StrategyType)request.PaymentMode;
            else
                return "Please select valid mode of payment";

            // Mode of Payment
            //1. Credit card 2.UPI 3.PayPal
            // An enum named StartegyType is created for mode of Payments
            // Get the mode of Payment from client using the system i.e. in API request body in this endpoint
            var strategy = _resolver.Resolve(value);
     
            _initiator.setStrategy(strategy);

            string result = _initiator.executeStrategy();

            return result;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
