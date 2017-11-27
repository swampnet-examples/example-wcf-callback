using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface ICallback
    {
        [OperationContract]
        void Poke(string s);
    }
}
