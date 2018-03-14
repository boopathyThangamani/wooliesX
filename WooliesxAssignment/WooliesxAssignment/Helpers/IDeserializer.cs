using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooliesxAssignment.Helpers
{
    public interface IDeserializer
    {
        T Deserialize<T>(string contents);
    }
}
