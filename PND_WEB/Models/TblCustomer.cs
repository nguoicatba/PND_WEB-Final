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
        [Required(ErrorMessage = "Mã số thuế không được để trống")]
        public string CustomerId { get; set; } = null!;

        [Column("Company_Name")] 
        [MaxLength(255)]
        public string? CompanyName { get; set; }

        [Column("Company_Namekd")] 
        [MaxLength(255)]
        public string? CompanyNamekd { get; set; }

        [Column("Com_Address")] 
        [MaxLength(1000)]
        public string? ComAddress { get; set; }

        [Column("Com_Addresskd")] 
        [MaxLength(1000)]
        public string? ComAddresskd { get; set; }

        [Column("Website")] 
        [MaxLength(255)]
        public string? Website { get; set; }

        [Column("Duty_Person")] 
        [MaxLength(255)]
        public string? DutyPerson { get; set; }

        [Column("Contact")] 
        [MaxLength(255)]
        public string? Contact { get; set; }

        [Column("Email")] // Email công ty
        [MaxLength(255)]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string? Email { get; set; }

        // Danh sách các HBL liên quan đến khách hàng này
        public virtual ICollection<TblHbl> TblHbls { get; set; } = new List<TblHbl>();
    }
}
