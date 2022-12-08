using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RecycleCoin.Entities.Abstract;

namespace RecycleCoin.Entities.Concrete.EntityFramework;

[Table("customer")]
public partial class Customer : IEntity
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    [Column("wallet_address")]
    [StringLength(64)]
    public string? WalletAddress { get; set; }

    [Column("carbon_balance")]
    public int? CarbonBalance { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Recycle> Recycles { get; } = new List<Recycle>();

    [ForeignKey("UserId")]
    [InverseProperty("Customers")]
    public virtual User User { get; set; } = null!;
}
