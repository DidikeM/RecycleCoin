using Ninject.Modules;
using RecycleCoin.Business.Abstract;
using RecycleCoin.Business.Concrete;
using RecycleCoin.DataAccess.Abstract;
using RecycleCoin.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.DependencyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICustomerService>().To<CustomerManager>().InSingletonScope();
            Bind<ICustomerDal>().To<EfCustomerDal>().InSingletonScope();

            Bind<IProductService>().To<ProductManager>().InSingletonScope();
            Bind<IProductDal>().To<EfProductDal>().InSingletonScope();

            Bind<IRecycleService>().To<RecycleManager>().InSingletonScope();
            Bind<IRecycleDal>().To<EfRecycleDal>().InSingletonScope();

            Bind<IRecycleDetailSevice>().To<RecycleDetailManager>().InSingletonScope();
            Bind<IRecycleDetailDal>().To<EfRecycleDetailDal>().InSingletonScope();

            Bind<IReplyService>().To<ReplyManager>().InSingletonScope();
            Bind<IReplyDal>().To<EfReplyDal>().InSingletonScope();

            Bind<IRoleService>().To<RoleManager>().InSingletonScope();
            Bind<IRoleDal>().To<EfRoleDal>().InSingletonScope();

            Bind<ITopicSevice>().To<TopicManager>().InSingletonScope();
            Bind<ITopicDal>().To<EfTopicDal>().InSingletonScope();

            Bind<IUserSevice>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();
        }
    }
}
