using RecycleCoin.Entities.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.Abstract
{
    public interface IReplyService
    {
        void AddReply(Reply reply);
        List<Reply> GetAllReply();
        List<Reply> GetByTopicId(int topicId);
        int GetReplyCountByTopicId(int id);
    }
}
