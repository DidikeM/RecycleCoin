using RecycleCoin.Entities.Concrete.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecycleCoin.WebUI.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
        public string Email { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}

