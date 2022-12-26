using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RecycleCoin.API.Soap.CoinTransferService.Concrete;

namespace RecycleCoin.API.Concrete
{
    public static class CoinTransferService
    {
        public static async Task<string> CoinTransferToAdress(string adress, int carbonBalance)
        {
            var service = new CoinTransferSoapPortClient(CoinTransferSoapPortClient.EndpointConfiguration.CoinTransferServiceSoapPort);
            var response = await service.CoinTransferAsync(adress, carbonBalance.ToString());

            string result;
            if (response.result.Substring(0, 5).Equals("error"))
            {
                result = Regex.Match(response.result, @"\d+").Value;
            }
            else
            {
                result = response.result;
            }
            return result;
        }

    }
}
