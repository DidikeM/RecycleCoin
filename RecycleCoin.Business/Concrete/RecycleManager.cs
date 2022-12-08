using RecycleCoin.Business.Abstract;
using RecycleCoin.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.Concrete
{
    public class RecycleManager : IRecycleService
    {
        IRecycleDal recycleDal;

        public RecycleManager(IRecycleDal recycleDal)
        {
            this.recycleDal = recycleDal;
        }
    }
}
