using System.ComponentModel.DataAnnotations;

namespace PND_WEB.ViewModels
{
    public class UserModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [Display(Name = "Tên đăng nhập")]
        [StringLength(50, ErrorMessage = "Tên đăng nhập không được vượt quá 50 ký tự")]
        public string? UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự")]
      
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        public string? ConfirmPassword { get; set; }

     
        [Display(Name = "Tên nhân viên")]
        [StringLength(100, ErrorMessage = "Tên nhân viên không được vượt quá 100 ký tự")]
        public string? Staff_Name { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        [Display(Name = "Trạng thái")]
        public string? Status { get; set; } = "Active";
    }
}
