using System;
using System.Collections.Generic;

namespace SmartHome.Dao.Dao;

public partial class RoomThermoRule
{
    public int Id { get; set; }

    public int IdRoom { get; set; }

    public int IdThermoRule { get; set; }

    public virtual Room IdRoomNavigation { get; set; } = null!;

    public virtual ThermoRule IdThermoRuleNavigation { get; set; } = null!;
}
