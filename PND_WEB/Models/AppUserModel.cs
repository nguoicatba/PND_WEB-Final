using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace PND_WEB.Models
{
    public class AppUserModel : IdentityUser
    {
        [DisplayName("Staff Name")]

        public string? Staff_Name { get; set; }

        [DisplayName("Status")]
        public string? Status { get; set; } 

        [DisplayName("Date of birth")]
        public DateTime? DOB { get; set; }

        [DisplayName("Create Date")]
        public DateTime? createDate { get; set; }

        //[DisplayName("Is Active")]
        //public bool IsActive { get; set; }



    }
}
