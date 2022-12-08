using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RecycleCoin.Entities.Abstract;

namespace RecycleCoin.Entities.Concrete.EntityFramework;

[Table("product")]
public partial class Product : IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(30)]
    public string Name { get; set; } = null!;

    [Column("price")]
    public int Price { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<RecycleDetail> RecycleDetails { get; } = new List<RecycleDetail>();
}
