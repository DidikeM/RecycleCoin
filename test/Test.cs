using RecycleCoin.Business.Abstract;
using RecycleCoin.Business.DependencyResolvers.Ninject;
using RecycleCoin.Entities.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
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
            
        }
    }
}
