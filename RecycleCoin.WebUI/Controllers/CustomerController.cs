using Microsoft.AspNetCore.Mvc;
using RecycleCoin.Business.Abstract;
using RecycleCoin.Business.DependencyResolvers.Ninject;
using RecycleCoin.Entities.Concrete.EntityFramework;
using RecycleCoin.WebUI.Models;
using RecycleCoin.API.Concrete;
using System.Security.Claims;

namespace RecycleCoin.WebUI.Controllers
{
    public class CustomerController : Controller
    {
        IUserService _userService = InstanceFactory.GetInstance<IUserService>();
        ICustomerService _customerService = InstanceFactory.GetInstance<ICustomerService>();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WithDraw()
        {

            return View(new WithDrawModel { CustomerModel = GetCustomer() });
        }

        [HttpPost]
        public async Task<IActionResult> WithDraw(int userId, int carbon, string walletAddress)
        {
            Customer customer = _customerService.GetByUserId(userId);

            string result;
            if (customer.CarbonBalance >= carbon)
            {
                result = await CoinTransferService.CoinTransferToAdress(walletAddress, carbon);
                if (result.Equals("5"))
                {
                    result = "Invalid Wallet Address";
                }
                else
                {
                    var temp = result;
                    result = "Transfer Successful. Transfer hash: " + temp;
                    customer.CarbonBalance -= carbon;
                    customer.WalletAddress = walletAddress;
                    _customerService.Update(customer);
                }
            }
            else
            {
                result = "Invalid Carbon Amount";
            }
            return View(new WithDrawModel { CustomerModel = GetCustomer(), Result = result });
        }


        CustomerModel GetCustomer()
        {
            User user = _userService.GetById(Convert.ToInt32(User.Claims.FirstOrDefault(p => p.Type == "id")!.Value));

            Customer customer = _customerService.GetByUserId(user.Id);

            CustomerModel customerModel = new CustomerModel
            {
                Carbon = (int)customer.CarbonBalance!,
                WalletAddress = customer.WalletAddress,
                UserModel = new UserModel
                {
                    Id = user.Id,
                    Email = user.Email
                }
            };
            return customerModel;
        }
    }
}
