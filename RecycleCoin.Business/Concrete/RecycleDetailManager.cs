using RecycleCoin.Business.Abstract;
using RecycleCoin.DataAccess.Abstract;
using RecycleCoin.Entities.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.Concrete
{
    public class RecycleDetailManager : IRecycleDetailService
    {
        IRecycleDetailDal _recycleDetailDal;

        public RecycleDetailManager(IRecycleDetailDal recycleDetailDal)
        {
            _recycleDetailDal = recycleDetailDal;
        }

        public void AddRecycleDetail(RecycleDetail recycleDetail)
        {
            _recycleDetailDal.Add(recycleDetail);
        }
    }
}
