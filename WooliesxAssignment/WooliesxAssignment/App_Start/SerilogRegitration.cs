using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WooliesxAssignment.App_Start
{
    public static class SerilogRegitration
    {
        public static void RegisterSerilog()
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.AppSettings()
    .CreateLogger();
        }
    }
}