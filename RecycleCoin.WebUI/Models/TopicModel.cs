using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RecycleCoin.Entities.Concrete.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecycleCoin.WebUI.Models
{
    public class TopicModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;
        public int UserId { get; set; }
        public DateTime? Date { get; set; }
        public List<ReplyModel> Replies { get; set; } = new List<ReplyModel>();
        public int ReplyCount { get; set; }
        public User User { get; set; } = null!;
    }
}
