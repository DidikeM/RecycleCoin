using RecycleCoin.Entities.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.Abstract
{
    public interface IUserService
    {
        void AddUser(User user);
        List<User> GetAll();
        User GetByEmailAndPassword(string email, string password);
        User GetByEmail(string email);
        User GetById(int id);
        void UpdateRole(int userId, int roleID);
        List<User> GetByRoleId(int roleId);
    }
}
