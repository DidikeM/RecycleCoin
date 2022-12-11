using RecycleCoin.Entities.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.Abstract
{
    public interface IUserSevice
    {
        void AddUser(User user);
        User GetByEmailAndPassword(string email, string password);
        User GetById(int id);
    }
}
