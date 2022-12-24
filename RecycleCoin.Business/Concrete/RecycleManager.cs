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
    public class RecycleManager : IRecycleService
    {
        IRecycleDal _recycleDal;

        public RecycleManager(IRecycleDal recycleDal)
        {
            _recycleDal = recycleDal;
        }

        public void AddRecycle(Recycle recycle)
        {
            _recycleDal.Add(recycle);
        }
    }
}
