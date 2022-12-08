using RecycleCoin.Business.Abstract;
using RecycleCoin.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.Concrete
{
    public class RoleManager:IRoleService
    {
        IRoleDal _roleDal;

        public RoleManager(IRoleDal roleDal)
        {
            _roleDal = roleDal;
        }
    }
}
