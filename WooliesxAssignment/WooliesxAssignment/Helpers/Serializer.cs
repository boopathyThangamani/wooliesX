using System.Web.Script.Serialization;

namespace WooliesxAssignment.Helpers
{
    public class Serializer : ISerializer
    {
        public string Serialise<T>(T items)
        {
            var serialize = new JavaScriptSerializer();
            return serialize.Serialize(items);
        }
    }
}