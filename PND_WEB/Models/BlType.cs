using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;

[Table("BL_TYPE")]
public partial class BlType
{
    [Key]
    [MaxLength(20)]
    [Required(ErrorMessage = "Mã loại BL là bắt buộc")]
    [Column("CODE")]
    [DisplayName("Mã loại BL")]
    public string Code { get; set; } = null!;

    [MaxLength(255)]
    [Column("BL_name")]
    [DisplayName("Tên loại BL")]
    public string? BlName { get; set; }

    [MaxLength(255)]
    [Column("Note")]
    [DisplayName("Ghi chú")]
    public string? Note { get; set; }
}
