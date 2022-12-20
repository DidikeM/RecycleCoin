using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using RecycleCoin.API.Abstract;

namespace RecycleCoin.API.Concrete
{
    [ServiceContract]
    public class CoinTransferServiceClient : ClientBase<ICoinTransferServiceClient>, ICoinTransferServiceClient
    {

        public CoinTransferServiceClient() : base(new BasicHttpBinding(), new EndpointAddress("http://127.0.0.1:7335/wsdl")) { }
        [OperationContract]
        public string CoinTransfer(string address, int coinAmount)
        {
            return Channel.CoinTransfer(address, coinAmount);
        }
    }
}
