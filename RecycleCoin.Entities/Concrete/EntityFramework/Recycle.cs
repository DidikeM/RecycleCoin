using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecycleCoin.Entities.Concrete.EntityFramework;

[Table("recycle")]
public partial class Recycle
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("customer_id")]
    public int CustomerId { get; set; }

    [Column("date", TypeName = "timestamp without time zone")]
    public DateTime Date { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Recycles")]
    public virtual Customer Customer { get; set; } = null!;

    [InverseProperty("Recycle")]
    public virtual ICollection<RecycleDetail> RecycleDetails { get; } = new List<RecycleDetail>();
}
