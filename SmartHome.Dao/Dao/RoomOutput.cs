using System;
using System.Collections.Generic;

namespace SmartHome.Dao.Dao;

public partial class RoomOutput
{
    public int Id { get; set; }

    public int IdOutput { get; set; }

    public int IdRoom { get; set; }

    public string? Description { get; set; }

    public virtual Output IdOutputNavigation { get; set; } = null!;

    public virtual Room IdRoomNavigation { get; set; } = null!;
}
