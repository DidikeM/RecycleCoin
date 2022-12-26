using RecycleCoin.Entities.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.Abstract
{
    public interface IRecycleDetailService
    {
        void AddRecycleDetail(RecycleDetail recycleDetail);
        List<RecycleDetail> GetByRecycleId(int recycleId);
        int SumOfProductQuantityToProductId(int productId);
        int SumOfCarbon();
    }
}
