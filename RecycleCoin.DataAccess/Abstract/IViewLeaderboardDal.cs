using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecycleCoin.Entities.Concrete.EntityFramework;

namespace RecycleCoin.DataAccess.Abstract
{
    public interface IViewLeaderboardDal : IEntityRepository<ViewLeaderboard>
    {
    }
}
