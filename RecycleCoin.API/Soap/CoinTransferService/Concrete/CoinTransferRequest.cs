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
    [System.ServiceModel.MessageContractAttribute(WrapperName = "CoinTransferRequest", WrapperNamespace = "http://tempuri.org/", IsWrapped = true)]
    internal partial class CoinTransferRequest
    {

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://tempuri.org/", Order = 0)]
        public string address;

        [System.ServiceModel.MessageBodyMemberAttribute(Namespace = "http://tempuri.org/", Order = 1)]
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string coinAmount;

        public CoinTransferRequest()
        {
        }

        public CoinTransferRequest(string address, string coinAmount)
        {
            this.address = address;
            this.coinAmount = coinAmount;
        }
    }
}
