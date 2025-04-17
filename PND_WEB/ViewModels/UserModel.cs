using System.ComponentModel.DataAnnotations;

namespace PND_WEB.ViewModels
{
    public class UserModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        public string? UserName { get; set; }
        [DataType(DataType.Password), Required(ErrorMessage = "Làm ơn nhập password")]
        public string? Password { get; set; }

        public string? Staff_Name { get; set; }

        public DateTime? DOB { get; set; }

        
    }
}
