using System;
using System.Collections.Generic;

namespace SmartHome.Dao.Dao;

public partial class Statistic
{
    public int Id { get; set; }

    public int IdInput { get; set; }

    public string Type { get; set; } = null!;

    public decimal Temp { get; set; }

    public DateTime CaptureDate { get; set; }

    public virtual Input IdInputNavigation { get; set; } = null!;
}
