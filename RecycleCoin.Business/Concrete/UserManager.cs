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
    public class UserManager : IUserService
    {
        IUserDal _UserDal;
        public UserManager(IUserDal userDal)
        {
            _UserDal = userDal;
        }

        public void AddUser(User user)
        {
            _UserDal.Add(user);
        }

        public List<User> GetAll()
        {
            return _UserDal.GetAll();
        }

        public User GetByEmailAndPassword(string email, string password)
        {
            return _UserDal.Get(p => p.Email == email && p.Password == password);
        }

        public User GetByEmail(string email)
        {
            return _UserDal.Get(p => p.Email == email);
        }

        public User GetById(int id)
        {
            return _UserDal.Get(p => p.Id == id);
        }

        public void UpdateRole(int userId, int roleID)
        {
            User user = GetById(userId);
            user.RoleId = roleID;
            _UserDal.Update(user);
        }
    }
}
