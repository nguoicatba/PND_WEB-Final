

using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.ViewModels
{
    public class UserRole
    {
        public string Id { get; set; }
        [Display(Name = "Tên đăng nhập")]
        public string? UserName { get; set; }

        [Display(Name = "Quyền hạn")]
        public List<string>? Roles { get; set; }
        
        public List<SelectListItem> AllRoles { get; set; } = new List<SelectListItem>();

     
        public string GetRoleView()
        {
            return string.Join(", ", Roles);
        }


    }
}
