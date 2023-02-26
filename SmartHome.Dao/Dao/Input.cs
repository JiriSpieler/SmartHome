using System;
using System.Collections.Generic;

namespace SmartHome.Dao.Dao;

public partial class Input
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Circuit { get; set; } = null!;

    public string Dev { get; set; } = null!;

    public decimal? Value { get; set; }

    public DateTime? LastUpdate { get; set; }

    public virtual ICollection<RoomInput> RoomInputs { get; } = new List<RoomInput>();

    public virtual ICollection<Statistic> Statistics { get; } = new List<Statistic>();
}
