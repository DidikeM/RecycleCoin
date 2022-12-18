using RecycleCoin.API.Concrete;
using RecycleCoin.Business.Abstract;
using RecycleCoin.Business.DependencyResolvers.Ninject;
using RecycleCoin.Entities.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Test
    {
        IUserService userService = InstanceFactory.GetInstance<IUserService>();
        IRoleService roleService= InstanceFactory.GetInstance<IRoleService>();
        ITopicService topicSevice = InstanceFactory.GetInstance<ITopicService>();
        IReplyService replyService = InstanceFactory.GetInstance<IReplyService>();


        public Test() 
        {
            var a = new CoinTransferServiceClient(new BasicHttpBinding(), new EndpointAddress("http://127.0.0.1:7335"));
            string sonuc = a.CoinTransfer("RVXj2FwF4aqFSGf29QqTEpXacgjM7V891H", 3);
            Console.WriteLine(sonuc);
        }
    }
}
