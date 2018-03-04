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

        public string UserId()
        {
            var result = ConfigurationManager.AppSettings [Constants.UserId];
            if(result != null)
                return result;
            throw new ConfigurationErrorsException(ErrorMessageConstants.NullUserID);
    }
    }
}