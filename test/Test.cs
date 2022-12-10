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
        IUserSevice userService = InstanceFactory.GetInstance<IUserSevice>();
        IRoleService roleService= InstanceFactory.GetInstance<IRoleService>();
        ITopicSevice topicSevice = InstanceFactory.GetInstance<ITopicSevice>();
        IReplyService replyService = InstanceFactory.GetInstance<IReplyService>();


        public Test() 
        {
            Topic topic = topicSevice.GetById(1);
            foreach (var item in topic.Replies)
            {
                Console.WriteLine(item.User.Id);
            }
        }
    }
}
