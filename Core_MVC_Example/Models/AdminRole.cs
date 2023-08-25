using System;
using System.Collections.Generic;

namespace Core_MVC_Example.Models;

public partial class AdminRole
{
    public long RoleNum { get; set; }

    public int? GroupNum { get; set; }

    public long? MenuSubNum { get; set; }

    public string? Role { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? Creator { get; set; }

    public string? Ip { get; set; }
}
