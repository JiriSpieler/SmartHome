using System;
using System.Collections.Generic;

namespace SmartHome.Dao.Dao;

public partial class RoomInput
{
    public int Id { get; set; }

    public int IdInput { get; set; }

    public int IdRoom { get; set; }

    public decimal IdSecondaryInput { get; set; }

    public string? Description { get; set; }

    public virtual Input IdInputNavigation { get; set; } = null!;

    public virtual Room IdRoomNavigation { get; set; } = null!;
}
