using System;
using System.Collections.Generic;

namespace Core_MVC_Example.Models;

public partial class Member
{
    public long MemberNum { get; set; }

    public string? MemberAccount { get; set; }

    public string? MemberPassword { get; set; }

    public string? MemberName { get; set; }

    public string? MemberPhone { get; set; }

    public string? MemberEmail { get; set; }

    public int? MemberPublish { get; set; }

    public DateTime? LastLogin { get; set; }

    public DateTime? CreateTime { get; set; }

    public int? Creator { get; set; }

    public DateTime? EditTime { get; set; }

    public int? Editor { get; set; }

    public string? Ip { get; set; }
}
