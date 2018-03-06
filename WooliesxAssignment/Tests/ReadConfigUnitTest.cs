using System;
using System.Configuration;
using NUnit.Framework;
using NUnit.Framework.Internal;
using WooliesxAssignment.Helpers;

namespace Tests
{
    [TestFixture]
    public class ReadConfigUnitTest
    {
        private IReadConfig _config;

        [SetUp]
        public void SetUp()
        {
            _config = new ReadConfig();
        }
        [Test]
        public void
            ReadShopperHistory_ReadShopperHistoryNotPresent_ThrowConfigurationErrorsException
            ()
        {
           Assert.Throws<ConfigurationErrorsException>(() => _config.ReadShopperHistory());
        }

        [Test]
        public void
            ReadProduct_ReadProductNotPresent_ThrowConfigurationErrorsException
            ()
        {
            Assert.Throws<ConfigurationErrorsException>(() => _config.ReadProduct());
        }

        [Test]
        public void
            ReadBaseUrl_ReadBaseUrleNotPresent_ThrowConfigurationErrorsException
            ()
        {
            Assert.Throws<ConfigurationErrorsException>(() => _config.ReadBaseUrl());
        }

        [Test]
        public void
            UserId_UserIdNotPresent_ThrowConfigurationErrorsException
            ()
        {
            Assert.Throws<ConfigurationErrorsException>(() => _config.UserId());
        }

        [Test]
        public void
            ReadTrollyCaclulator_ReadTrollyCaclulatorNotPresent_ThrowConfigurationErrorsException
            ()
        {
            Assert.Throws<ConfigurationErrorsException>(() => _config.ReadTrollyCaclulator());
        }
    }
}
