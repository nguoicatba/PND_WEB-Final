using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;

[Table("tbl_CUSTOMER")]
public partial class TblCustomer
{
    [Key]
    [MaxLength(20)]
    [Required]
    public string CustomerId { get; set; } = null!; // mã số thuế công ty

    [MaxLength(255)]
    public string? CompanyName { get; set; }

    [MaxLength(255)]
    public string? CompanyNamekd { get; set; }

    [MaxLength(1000)]
    public string? ComAddress { get; set; }

    [MaxLength(1000)]
    public string? ComAddresskd { get; set; }

    [MaxLength(255)]
    public string? Website { get; set; }

    [MaxLength(255)]
    public string? DutyPerson { get; set; }

    [MaxLength(255)]
    public string? Contact { get; set; }

    [MaxLength(255)]
    [EmailAddress(ErrorMessage = "Email không hợp lệ")]
    public string? Email { get; set; }

    
    public virtual ICollection<TblHbl> TblHbls { get; set; } = new List<TblHbl>();
}
