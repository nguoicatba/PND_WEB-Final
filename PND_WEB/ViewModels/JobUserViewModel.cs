using PND_WEB.Models;

namespace PND_WEB.ViewModels
{
    public class JobUserViewModel
    {
        public  int Id { get; set; }
        public string ?UserName { get; set; }
        public string ? Staff_Name { get; set; }
        public string ?RoleName { get; set; }

        public string ?Description { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
