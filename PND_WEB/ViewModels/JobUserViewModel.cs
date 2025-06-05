using PND_WEB.Models;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.ViewModels
{
    public class JobUserViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Display(Name = "User Name")]
        public string ?UserName { get; set; }

        [Display(Name = "Staff Name")]
        public string ? Staff_Name { get; set; }

        [Display(Name = "Role")]
        public string ?RoleName { get; set; }

        [Display(Name = "Description")]
        public string ?Description { get; set; }

        [Display(Name = "Create Date")]
        public DateTime? CreateDate { get; set; }
    }
}
