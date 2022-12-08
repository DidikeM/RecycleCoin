using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecycleCoin.Entities.Concrete.EntityFramework;

[Table("user")]
[Index("Username", "Email", Name = "User_username_email_key", IsUnique = true)]
public partial class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("username")]
    [StringLength(30)]
    public string Username { get; set; } = null!;

    [Column("password")]
    [StringLength(64)]
    public string Password { get; set; } = null!;

    [Column("role_id")]
    public int RoleId { get; set; }

    [Column("email")]
    [StringLength(50)]
    public string Email { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Customer> Customers { get; } = new List<Customer>();

    [InverseProperty("User")]
    public virtual ICollection<Reply> Replies { get; } = new List<Reply>();

    [ForeignKey("RoleId")]
    [InverseProperty("Users")]
    public virtual Role Role { get; set; } = null!;

    [InverseProperty("User")]
    public virtual ICollection<Topic> Topics { get; } = new List<Topic>();
}
