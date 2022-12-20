using SoapCore.SoapServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoapCore;
using System.Net.Http;


namespace RecycleCoin.API.Abstract
{
    [ServiceContract]
    public interface ICoinTransferServiceClient
    {
        [OperationContract]
        public string CoinTransfer(string address, int coinAmount);
    }
}
