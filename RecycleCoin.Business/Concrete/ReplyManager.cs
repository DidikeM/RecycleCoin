using RecycleCoin.Business.Abstract;
using RecycleCoin.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.Concrete
{
    public class ReplyManager:IReplyService
    {
        IReplyDal _replyDal;

        public ReplyManager(IReplyDal replyDal)
        {
            _replyDal = replyDal;
        }
    }
}
