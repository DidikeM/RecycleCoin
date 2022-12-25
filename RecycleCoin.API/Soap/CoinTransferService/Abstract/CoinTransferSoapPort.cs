using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecycleCoin.API.Soap.CoinTransferService.Concrete;

namespace RecycleCoin.API.Soap.CoinTransferService.Abstract
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.1.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName = "coineservice.CoinTransferSoapPort")]
    internal interface CoinTransferSoapPort
    {

        [System.ServiceModel.OperationContractAttribute(Action = "CoinTransfer", ReplyAction = "*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults = true)]
        System.Threading.Tasks.Task<CoinTransferResponse> CoinTransferAsync(CoinTransferRequest request);
    }
}
