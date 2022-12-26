using RecycleCoin.Entities.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.Abstract
{
    public interface IProductService
    {
        void AddProduct(Product product);
        List<Product> GetAll();
        Product GetById(int objectIndex);
    }
}
