﻿using System;
using System.Collections.Generic;

namespace Core_MVC_Example.Models;

public partial class AdminGroup
{
    public long GroupNum { get; set; }

    public string? GroupName { get; set; }

    public string? GroupInfo { get; set; }

    public int? GroupPublish { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? Creator { get; set; }

    public DateTime? EditTime { get; set; }

    public int? Editor { get; set; }

    public string? Ip { get; set; }
}
