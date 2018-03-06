using Serilog;

namespace WooliesxAssignment
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