using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RecycleCoin.Entities.Abstract;

namespace RecycleCoin.Entities.Concrete.EntityFramework;

[Table("reply")]
public partial class Reply : IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("topic_id")]
    public int TopicId { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("text")]
    public string Text { get; set; } = null!;

    [ForeignKey("TopicId")]
    [InverseProperty("Replies")]
    public virtual Topic Topic { get; set; } = null!;

    [ForeignKey("UserId")]
    [InverseProperty("Replies")]
    public virtual User User { get; set; } = null!;
}
