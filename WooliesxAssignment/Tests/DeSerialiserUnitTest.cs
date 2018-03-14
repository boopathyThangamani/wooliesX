using System;
using System.Configuration;
using NUnit.Framework;
using NUnit.Framework.Internal;
using WooliesxAssignment.Helpers;
using WooliesxAssignment.Models;

namespace Tests
{
    [TestFixture]
    public class DeserialiserUnitTest
    {
        private IDeserializer _deserializer;

        [SetUp]
        public void SetUp()
        {
            _deserializer = new Deserializer();
        }
        [Test]
        public void
            DeserialiseProduct_DeserializeProductToJson_Success
            ()
        {
            var product = _deserializer.Deserialize<Product>("{\"Name\":\"product1\",\"Price\":20,\"Quantity\":10}");
            Assert.AreEqual("product1",product.Name);
            Assert.AreEqual(10, product.Quantity);
            Assert.AreEqual(20, product.Price);
        }


    }
}
