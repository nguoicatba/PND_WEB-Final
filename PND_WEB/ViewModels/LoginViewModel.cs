using System.ComponentModel.DataAnnotations;

namespace PND_WEB.ViewModels
{
    public class LoginViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string? UserName { get; set; }
        [DataType(DataType.Password), Required(ErrorMessage = "Làm ơn nhập password")]
        public string? Password { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
