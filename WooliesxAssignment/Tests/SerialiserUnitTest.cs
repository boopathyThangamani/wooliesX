using System;
using System.Configuration;
using NUnit.Framework;
using NUnit.Framework.Internal;
using WooliesxAssignment.Helpers;
using WooliesxAssignment.Models;

namespace Tests
{
    [TestFixture]
    public class SerialiserUnitTest
    {
        private ISerializer _serializer;

        [SetUp]
        public void SetUp()
        {
            _serializer = new Serializer();
        }
        [Test]
        public void
            SerialiseProduct_SerializeProductToJson_Success
            ()
        {
            var product =_serializer.Serialise(GetProduct());
            Assert.AreEqual("{\"Name\":\"product1\",\"Price\":20,\"Quantity\":10}",product);
        }

        private Product GetProduct()
        {
            return new Product() {Name = "product1", Quantity = 10, Price = 20};
        }

    }
}
