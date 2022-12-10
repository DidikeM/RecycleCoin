using RecycleCoin.DataAccess.Abstract;
using RecycleCoin.Entities.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.DataAccess.Concrete.EntityFramework
{
    public class EfReplyDal : EfEntityRepositoryBase<Reply, RecycleCoinContext>, IReplyDal
    {

    }
}
