using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RecycleCoin.Entities.Abstract;

namespace RecycleCoin.Entities.Concrete.EntityFramework;

[Keyless]
public partial class ViewLeaderboard : IEntity
{
    [Column("username")]
    [StringLength(30)]
    public string? Username { get; set; }

    [Column("total")]
    public long? Total { get; set; }
}
