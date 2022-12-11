using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecycleCoin.Business.Abstract;
using RecycleCoin.Business.DependencyResolvers.Ninject;
using RecycleCoin.Entities.Concrete.EntityFramework;
using RecycleCoin.WebUI.Models;
using System.Security.Claims;

namespace RecycleCoin.WebUI.Controllers
{
    public class ForumController : Controller
    {
        private ITopicSevice _topicSevice = InstanceFactory.GetInstance<ITopicSevice>();
        private IReplyService _replyService = InstanceFactory.GetInstance<IReplyService>();
        private IUserSevice _userSevice = InstanceFactory.GetInstance<IUserSevice>();


        public IActionResult Index()
        {
            List<Topic> topics = _topicSevice.GetAllTopic();
            List<TopicModel> topicModels = new List<TopicModel>();
            foreach (var topic in topics)
            {
                topicModels.Add(new TopicModel
                {
                    Date = topic.Date,
                    Id = topic.Id,
                    Text = topic.Text,
                    Title = topic.Title,
                    UserId = topic.UserId,
                    User = _userSevice.GetById(topic.UserId),
                    ReplyCount = _replyService.GetReplyCountByTopicId(topic.Id)
                }) ;
            }

            ViewBag.TopicModel = topicModels;
            return View();
        }


        public IActionResult Topic(int id)
        {
            ViewBag.TopicModel = GetTopic(id);
            return View();
        }

        [HttpPost]
        public IActionResult Topic(int topicid,int userId, string textt)
        {
            _replyService.AddReply(new Reply
            {
                TopicId = topicid,
                Text = textt,
                 UserId= userId
            });
            ViewBag.TopicModel = GetTopic(topicid);
            return View();
        }

        public IActionResult CreateTopic()
        {
            return View();
        }
        
        TopicModel GetTopic(int id)
        {
            Topic topic = _topicSevice.GetById(id);
            TopicModel topicModel = new TopicModel
            {
                Date = topic.Date,
                Id = topic.Id,
                Text = topic.Text,
                Title = topic.Title,
                UserId = topic.UserId
            };
            List<Reply> replies = _replyService.GetByTopicId(topic.Id);

            foreach (Reply reply in replies)
            {
                topicModel.Replies.Add(new ReplyModel
                {
                    Id = reply.Id,
                    Text = reply.Text,
                    TopicId = topic.Id,
                    UserId = reply.UserId,
                    User = _userSevice.GetById(reply.UserId)
                });
            }
            return topicModel;
        }


    }
}
