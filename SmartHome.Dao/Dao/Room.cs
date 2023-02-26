using System;
using System.Collections.Generic;

namespace SmartHome.Dao.Dao;

public partial class Room
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal DefaultTemp { get; set; }

    public decimal Hystersis { get; set; }

    public virtual ICollection<RoomInput> RoomInputs { get; } = new List<RoomInput>();

    public virtual ICollection<RoomOutput> RoomOutputs { get; } = new List<RoomOutput>();

    public virtual ICollection<RoomThermoRule> RoomThermoRules { get; } = new List<RoomThermoRule>();
}
