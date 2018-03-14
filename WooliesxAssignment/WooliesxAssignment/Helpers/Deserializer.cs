using System.Web.Script.Serialization;

namespace WooliesxAssignment.Helpers
{
    public class Deserializer : IDeserializer
    {
        public T Deserialize<T>(string contents)
        {
            var deserialised = new JavaScriptSerializer();
            return deserialised.Deserialize<T>(contents);
        }
    }
}