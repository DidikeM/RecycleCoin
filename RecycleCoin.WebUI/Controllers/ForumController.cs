using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RecycleCoin.Business.Abstract;
using RecycleCoin.Business.DependencyResolvers.Ninject;
using RecycleCoin.Entities.Concrete.EntityFramework;
using RecycleCoin.WebUI.Models;
using System.Dynamic;
using System.Security.Claims;
using X.PagedList;
using RecycleCoin.API.Concrete;
using AutoReplyService;

namespace RecycleCoin.WebUI.Controllers
{
    public class ForumController : Controller
    {
        private ITopicService _topicService = InstanceFactory.GetInstance<ITopicService>();
        private IReplyService _replyService = InstanceFactory.GetInstance<IReplyService>();
        private IUserService _userService = InstanceFactory.GetInstance<IUserService>();

        [AllowAnonymous]
        public IActionResult Index(int page = 1)
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

            //ViewBag.TopicModel = topicModels;
            return View(topicModels.ToPagedList(page, 10));

        }

        [AllowAnonymous]
        public IActionResult Topic(int id, int page = 1)
        {
            //ViewBag.TopicModel = GetTopic(topicid);
            dynamic model = new ExpandoObject();
            TopicModel topicModel = GetTopic(id);
            model.topic = topicModel;
            model.replies = topicModel.Replies.ToPagedList(page, 3);
            return View(model);
        }


        [HttpPost]
        public IActionResult Topic(int topicid, string text)
        {
            ClaimsPrincipal principal = HttpContext.User as ClaimsPrincipal;
            if (null != principal)
            {
                _replyService.AddReply(new Entities.Concrete.EntityFramework.Reply
                {
                    TopicId = topicid,
                    Text = text,
                    UserId = Convert.ToInt32(principal.Claims.Where(p => p.Type == "id").FirstOrDefault()!.Value)
                });
            }
            //ViewBag.TopicModel = GetTopic(topicid);
            dynamic model = new ExpandoObject();
            model.topic = GetTopic(topicid);
            model.replies = model.topic.Replies;
            return View(model);
        }


        public IActionResult CreateTopic()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTopic(string title, string text, bool activateBot)
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
            string userApi = "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";
            var response = await AutoReplyServices.ReplyQuestion(text, userApi);

            _replyService.AddReply(new Entities.Concrete.EntityFramework.Reply
            {
                TopicId = topic.Id,
                Text = response,
                UserId = 4337
            });

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
            List<Entities.Concrete.EntityFramework.Reply> replies = _replyService.GetByTopicId(topic.Id);

            foreach (Entities.Concrete.EntityFramework.Reply reply in replies)
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
