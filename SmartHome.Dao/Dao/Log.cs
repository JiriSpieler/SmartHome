using System;
using System.Collections.Generic;

namespace SmartHome.Dao.Dao;

public partial class Log
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime CreateDate { get; set; }

    public string Section { get; set; } = null!;
}
