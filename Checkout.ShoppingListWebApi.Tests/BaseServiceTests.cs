using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Checkout;
using Checkout.ApiServices.Charges.ResponseModels;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BaseServiceTests
    {
        protected APIClient CheckoutClient;

        [TestInitialize]
        public void Init()
        {
            CheckoutClient = new APIClient(); 
        }
    }
}
