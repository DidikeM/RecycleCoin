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
    public class UserManager : IUserSevice
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

        public User GetByEmailAndPassword(string email, string password)
        {
            return _UserDal.Get(p=> p.Email == email && p.Password == password);
        }

        public User GetById(int id)
        {
            return _UserDal.Get(p => p.Id == id);
        }
    }
}
