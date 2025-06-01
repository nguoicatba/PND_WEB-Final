using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models
{
    [Table("tbl_CUSTOMER")] 
    public partial class TblCustomer
    {
        [Key]
        [Column("Customer_ID")] 
        [MaxLength(20)]
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Customer ID")]
        public string CustomerId { get; set; } = null!;

        [Column("Company_Name")] 
        [MaxLength(255)]
        [Display(Name = "Company Name")]
        public string? CompanyName { get; set; }

        [Column("Company_Namekd")] 
        [MaxLength(255)]
        [Display(Name = "Company Name không dấu")]
        public string? CompanyNamekd { get; set; }

        [Column("Com_Address")]
        [Display(Name = "Địa chỉ công ty")]
        [MaxLength(1000)]
        public string? ComAddress { get; set; }

        [Column("Com_Addresskd")]
        [Display(Name = "Địa chỉ công ty không dấu")]
        [MaxLength(1000)]
        public string? ComAddresskd { get; set; }

        [Column("Website")]
        [Display(Name = "Website")]
        [MaxLength(255)]
        public string? Website { get; set; }

        [Column("Duty_Person")]
        [Display(Name = "Người phụ trách")]
        [MaxLength(255)]
        public string? DutyPerson { get; set; }

        [Column("Contact")] 

        [MaxLength(255)]
        public string? Contact { get; set; }

        [Column("Email")] 
        [MaxLength(255)]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string? Email { get; set; }

      
        public virtual ICollection<TblHbl> TblHbls { get; set; } = new List<TblHbl>();
    }
}
