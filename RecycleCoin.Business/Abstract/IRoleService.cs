using RecycleCoin.Entities.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.Abstract
{
    public interface IRoleService
    {
        void AddRole(Role role);
        List<Role> GetAll();
        Role GetById(int id);
    }
}
