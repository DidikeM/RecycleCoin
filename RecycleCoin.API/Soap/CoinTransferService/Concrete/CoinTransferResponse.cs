using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecycleCoin.API.Soap.CoinTransferService.Abstract;

namespace RecycleCoin.API.Soap.CoinTransferService.Concrete
{
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName = "CoinTransferResponse", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
    internal partial class CoinTransferResponse
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://tempuri.org/", Order = 0)]
        public string result;

        public CoinTransferResponse()
        {
        }

        public CoinTransferResponse(string result)
        {
            this.result = result;
        }
    }
}
