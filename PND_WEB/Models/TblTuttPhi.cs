using PND_WEB.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public partial class TblTuttPhi
{

    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("SoHoaDon")]
    [MaxLength(20)]
    public string? SoHoaDon { get; set; }

    [Column("TenPhi")]
    [MaxLength(255)]
    public string? TenPhi { get; set; }


    [Column("SoTien")]
    public double? SoTien { get; set; } = 0;

    [Column("GhiChu")]
    [MaxLength(255)]
    public string? GhiChu { get; set; }

    [Column("SoTUTT")]
    [MaxLength(50)]
    public string? SoTutt { get; set; }

    [ForeignKey("SoTutt")]
    public virtual TblTutt? SoTuttNavigation { get; set; }
}
