using RecycleCoin.Entities.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.Abstract
{
    public interface ITopicService
    {
        void AddTopic(Topic topic);
        List<Topic> GetAllTopic();
        Topic GetById(int id);
    }
}
