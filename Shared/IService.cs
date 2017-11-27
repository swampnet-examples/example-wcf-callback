using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    [ServiceContract(CallbackContract = typeof(ICallback))]
    public interface IService
    {
        [OperationContract]
        string Ping();

        [OperationContract]
        void Subscribe();

        [OperationContract]
        void Unsubscribe();
    }
}
