using System;
using System.Collections.Generic;

namespace QLLuong.Models;

public partial class UserLogin
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Userpassword { get; set; } = null!;
}
