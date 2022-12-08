using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using RecycleCoin.Entities.Abstract;

namespace RecycleCoin.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
    }
}
