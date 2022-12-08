using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RecycleCoin.Entities.Concrete.EntityFramework;

[Table("recycle_detail")]
public partial class RecycleDetail
{
    [Key]
    public int ıd { get; set; }

    [Column("recycle_id")]
    public int RecycleId { get; set; }

    [Column("product_id")]
    public int ProductId { get; set; }

    [Column("product_quantity")]
    public int ProductQuantity { get; set; }

    [Column("sub_total_price")]
    public int SubTotalPrice { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("RecycleDetails")]
    public virtual Product Product { get; set; } = null!;

    [ForeignKey("RecycleId")]
    [InverseProperty("RecycleDetails")]
    public virtual Recycle Recycle { get; set; } = null!;
}
