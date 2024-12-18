﻿using System;
using System.Collections.Generic;

namespace QLLuong.Models;

public partial class Quyen
{
    public int MaQuyen { get; set; }

    public string? TenQuyen { get; set; }

    public virtual ICollection<UserLogin> UserLogins { get; set; } = new List<UserLogin>();
}
