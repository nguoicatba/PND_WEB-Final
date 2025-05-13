using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.ViewModels
{
    public class JobUserEditModel
    {

        public int Id { get; set; }
        public string ?Job_ID { get; set; }
        [DisplayName("Nhân viên phụ trách")]
        [Required(ErrorMessage = "Nhân viên phụ trách không được để trống")]
        public string? UserName { get; set; }
        [DisplayName("Tên nhân viên")]
        public string? Staff_Name { get; set; }
        [DisplayName("Mô tả công việc")]
        public string? Description { get; set; }
    }
}
