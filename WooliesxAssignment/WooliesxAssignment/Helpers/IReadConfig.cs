﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooliesxAssignment.Helpers
{
    public interface IReadConfig
    {
        string ReadBaseUrl();
        string UserId();
        string ReadProduct();
        string ReadShopperHistory();
        string ReadTrollyCaclulator();
    }
}
