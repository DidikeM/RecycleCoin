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
    public class ReplyManager : IReplyService
    {
        IReplyDal _replyDal;

        public ReplyManager(IReplyDal replyDal)
        {
            _replyDal = replyDal;
        }

        public void AddReply(Reply reply)
        {
            _replyDal.Add(reply);
        }

        public List<Reply> GetAllReply()
        {
            return _replyDal.GetAll();
        }

        public ICollection<Reply> GetByTopicId(int id)
        {
            return _replyDal.GetAll(p => p.Id.Equals(id));
        }

        public int GetReplyCountByTopicId(int id)
        {
            return _replyDal.GetCount(p => p.TopicId == id);
        }

        List<Reply> IReplyService.GetByTopicId(int topicId)
        {
            return _replyDal.GetAll(p => p.TopicId == topicId);
        }
    }
}
