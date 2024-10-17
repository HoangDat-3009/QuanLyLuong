using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;


namespace QLLuong.Models
{
    public class UserLogin
    {
        [Key, Column(Order = 1)]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }    

        [Required]
        [StringLength(255)]
        public string UserPassword { get; set; }
    }
}
