using Microsoft.AspNetCore.Identity;

namespace PND_WEB.Models
{
    public class AppUserModel : IdentityUser
    {
        public string? Staff_Name { get; set; }

        public string? Status { get; set; }
        public DateTime? DOB { get; set; }

        public DateTime? createDate { get; set; }





    }
}
