using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecycleCoin.Entities.Concrete.EntityFramework;

[Table("topic")]
public partial class Topic
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("title")]
    [StringLength(100)]
    public string Title { get; set; } = null!;

    [Column("text")]
    public string Text { get; set; } = null!;

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("date", TypeName = "timestamp without time zone")]
    public DateTime? Date { get; set; }

    [InverseProperty("Topic")]
    public virtual ICollection<Reply> Replies { get; } = new List<Reply>();

    [ForeignKey("UserId")]
    [InverseProperty("Topics")]
    public virtual User User { get; set; } = null!;
}
