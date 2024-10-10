using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace QLLuong.Models
{
    public class NhanVien
    {
        public int Id { get; set; }//Mã sinh viên
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Tên phải có ít nhất 4 ký tự")]
        [Required(ErrorMessage = "Phải nhập Họ và tên")]
        [Display(Name = "Họ tên")]

        public string? Name { get; set; } //Họ tên
        [RegularExpression(@"^[^@\s]+@gmail\.com$", ErrorMessage = "Email phải có định dạng @gmail.com")]
        [Required(ErrorMessage = "Phải nhập Email")]
        [Display(Name = "Email")]
        public string? Email { get; set; } //Email
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$",
    ErrorMessage = "Mật khẩu phải từ 8 ký tự trở lên, có ít nhất một ký tự viết hoa, một ký tự viết thường, một chữ số và một ký tự đặc biệt.")]
        [Required(ErrorMessage = "Không được bỏ trống")]
        /*public string? Password { get; set; }//Mật khẩu
        [Required(ErrorMessage = "Không được bỏ trông mục này")]
        [DataType(DataType.Password)]*/

/*        [Display(Name = "Ngành")]
        public Branch? Branch { get; set; }//Ngành học
        [Required(ErrorMessage = "Không được bỏ trông mục này")]*/
        [Display(Name = "Giới tính")]
        public Gender? Gender { get; set; }//Giới tính

       /* [Display(Name = "Hệ")]

        public bool IsRegular { get; set; }//Hệ: true-chính quy, false-phi chính quy
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Không được bỏ trông mục này")]*/

        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }//Địa chỉ
        [Range(typeof(DateTime), "1/1/1963", "31/12/2020")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }//Ngày sinh
       /* [Range(0.0, 10.0)]
        [Required]
        public float? Point { get; set; }//Ngày sinh*/
    }
}
