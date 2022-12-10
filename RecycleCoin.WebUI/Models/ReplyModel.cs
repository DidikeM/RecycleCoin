using RecycleCoin.Entities.Concrete.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecycleCoin.WebUI.Models
{
    public class ReplyModel
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
