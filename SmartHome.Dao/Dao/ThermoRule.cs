using System;
using System.Collections.Generic;

namespace SmartHome.Dao.Dao;

public partial class ThermoRule
{
    public int Id { get; set; }

    public decimal Temp { get; set; }

    public string Start { get; set; } = null!;

    public string End { get; set; } = null!;

    public int WeekDay { get; set; }

    public bool IntervalSatus { get; set; }

    public bool Disabled { get; set; }

    public DateTime? LastUpdate { get; set; }

    public virtual ICollection<RoomThermoRule> RoomThermoRules { get; } = new List<RoomThermoRule>();
}
