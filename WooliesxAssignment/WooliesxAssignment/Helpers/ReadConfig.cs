using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WooliesxAssignment.Helpers
{
    public class ReadConfig : IReadConfig
    {
        public string ReadBaseUrl()
        {
            var result = ConfigurationManager.AppSettings[Constants.BaseUrl];
            if(result != null)
                return result;
            throw new ConfigurationErrorsException(ErrorMessageConstants.NullBaseUrl);
        }

        public string ReadProduct()
        {
            var result = ConfigurationManager.AppSettings[Constants.product];
            if (result != null)
                return result;
            throw new ConfigurationErrorsException(ErrorMessageConstants.NullProductUri);
        }

        public string ReadShopperHistory()
        {
            var result = ConfigurationManager.AppSettings[Constants.shopperHisoty];
            if (result != null)
                return result;
            throw new ConfigurationErrorsException(ErrorMessageConstants.NullShopperhisotryUri);
        }

        public string ReadTrollyCaclulator()
        {
            var result = ConfigurationManager.AppSettings[Constants.trollyCalculator];
            if (result != null)
                return result;
            throw new ConfigurationErrorsException(ErrorMessageConstants.NullTrollyCalculatorUri);
        }

        public string UserId()
        {
            var result = ConfigurationManager.AppSettings [Constants.UserId];
            if(result != null)
                return result;
            throw new ConfigurationErrorsException(ErrorMessageConstants.NullUserID);
    }
    }
}