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
        IRecycleService _recycleService = InstanceFactory.GetInstance<IRecycleService>();
        IRecycleDetailService _recycleDetailService = InstanceFactory.GetInstance<IRecycleDetailService>();
        IProductService _productService = InstanceFactory.GetInstance<IProductService>();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult WithDraw()
        {

            return View(new WithDrawModel { CustomerModel = GetCustomer() });
        }


        public IActionResult RecycleHistory()
        {
            List<Recycle> recycles = _recycleService.GetByCustomerId(_customerService.GetByUserId(Convert.ToInt32(User.Claims.FirstOrDefault(p => p.Type == "id")!.Value)).Id);
            List<RecycleModel> recycleModels = new List<RecycleModel>();

            List<Product> products = _productService.GetAll();

            foreach (var recycle in recycles)
            {
                RecycleModel recycleModel = new RecycleModel
                {
                    Id = recycle.Id,
                    Date = recycle.Date,
                    recycleDetailModels = new List<RecycleDetailModel>(),
                    TotalCarbon = 0
                };

                List<RecycleDetail> recycleDetails = _recycleDetailService.GetByRecycleId(recycle.Id);
                foreach (var recycleDetail in recycleDetails)
                {
                    var product = products.FirstOrDefault(p => p.Id == recycleDetail.ProductId);
                    recycleModel.recycleDetailModels.Add(new RecycleDetailModel
                    {
                        ProductName = product!.Name,
                        ProductPoint = product.Price,
                        ProductQuantity = recycleDetail.ProductQuantity,
                        SubTotalPrice = recycleDetail.SubTotalPrice
                    });
                    recycleModel.TotalCarbon += recycleDetail.SubTotalPrice;
                }
                recycleModels.Add(recycleModel);
            }
            return View(recycleModels);
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
