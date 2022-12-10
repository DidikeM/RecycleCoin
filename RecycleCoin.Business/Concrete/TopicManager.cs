using RecycleCoin.Business.Abstract;
using RecycleCoin.Business.DependencyResolvers.Ninject;
using RecycleCoin.DataAccess.Abstract;
using RecycleCoin.Entities.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.Concrete
{
    public class TopicManager : ITopicSevice
    {
        IReplyService _replyService = InstanceFactory.GetInstance<IReplyService>();
        ITopicDal _topicDal;
        public TopicManager(ITopicDal topicDal)
        {
            _topicDal = topicDal;
        }

        public void AddTopic(Topic topic)
        {
            _topicDal.Add(topic);
        }

        public List<Topic> GetAllTopic()
        {
            return _topicDal.GetAll();
        }

        public Topic GetById(int id)
        {
            return _topicDal.Get(q => q.Id == id);
        }
    }
}
