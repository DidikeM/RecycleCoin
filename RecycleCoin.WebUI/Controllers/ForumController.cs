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
        private ITopicService _topicService = InstanceFactory.GetInstance<ITopicService>();
        private IReplyService _replyService = InstanceFactory.GetInstance<IReplyService>();
        private IUserService _userService = InstanceFactory.GetInstance<IUserService>();

        [AllowAnonymous]
        public IActionResult Index()
        {
            List<Topic> topics = _topicService.GetAllTopic();
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
                    User = _userService.GetById(topic.UserId),
                    ReplyCount = _replyService.GetReplyCountByTopicId(topic.Id)
                });
            }

            ViewBag.TopicModel = topicModels;
            return View();
        }

        [AllowAnonymous]
        public IActionResult Topic(int id)
        {
            ViewBag.TopicModel = GetTopic(id);
            return View();
        }


        [HttpPost]
        public IActionResult Topic(int topicid, string text)
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            if (null != principal)
            {
                _replyService.AddReply(new Reply
                {
                    TopicId = topicid,
                    Text = text,
                    UserId = Convert.ToInt32(principal.Claims.Where(p => p.Type == "id").FirstOrDefault()!.Value)
                });
            }
            ViewBag.TopicModel = GetTopic(topicid);
            return View();
        }


        public IActionResult CreateTopic()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTopic(string title, string text)
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            Topic topic = new Topic
            {
                Title = title,
                Text = text,
                Date = DateTime.Now,
                UserId = Convert.ToInt32(principal.Claims.Where(p => p.Type == "id").FirstOrDefault()!.Value)
            };
            _topicService.AddTopic(topic);
            return RedirectToAction("Topic", "Forum", topic);
        }

        TopicModel GetTopic(int id)
        {
            Topic topic = _topicService.GetById(id);
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
                    User = _userService.GetById(reply.UserId)
                });
            }
            return topicModel;
        }


    }
}
