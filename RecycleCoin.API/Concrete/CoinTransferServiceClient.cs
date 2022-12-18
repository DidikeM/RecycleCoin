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
    public class CoinTransferServiceClient:ClientBase<ICoinTransferServiceClient>
    {

        public CoinTransferServiceClient(Binding binding, EndpointAddress remoteAddress):base(binding, remoteAddress) { }
        public string CoinTransfer(string address, int coinAmount) => Channel.CoinTransfer(address, coinAmount);
        

    }
}
