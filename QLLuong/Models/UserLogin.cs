using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QLLuong.Models;

public partial class UserLogin
{
    [Key]
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Userpassword { get; set; } = null!;
}
