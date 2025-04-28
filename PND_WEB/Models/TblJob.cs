using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;

[Table("tbl_JOB")]
public partial class TblJob
{
    [Key]
    [Column("Job_ID")]
    [MaxLength(50)]
    public string JobId { get; set; } = null!;

    [Column("Goods_type")]
    [MaxLength(20)]
    public string? GoodsType { get; set; }

    [Column("Job_date")]
    public DateTime JobDate { get; set; } = DateTime.Now;

    [Column("MBL")]
    [MaxLength(100)]
    public string? Mbl { get; set; }

    [Column("Issue_dateM")]
    public DateTime? IssueDateM { get; set; }

    [Column("OnBoard_dateM")]
    public DateTime? OnBoardDateM { get; set; }

    [Column("Vessel_name")]
    [MaxLength(100)]
    public string? VesselName { get; set; }

    [Column("Voyage_name")]
    [MaxLength(100)]
    public string? VoyageName { get; set; }

    [Column("POL")]
    [MaxLength(255)]
    public string? Pol { get; set; }

    [Column("POD")]
    [MaxLength(255)]
    public string? Pod { get; set; }

    [Column("PODel")]
    [MaxLength(255)]
    public string? Podel { get; set; }

    [Column("PODis")]
    [MaxLength(255)]
    public string? Podis { get; set; }

    [Column("PlaceofReceipt")]
    [MaxLength(255)]
    public string? PlaceofReceipt { get; set; }

    [Column("PlaceofDelivery")]
    [MaxLength(255)]
    public string? PlaceofDelivery { get; set; }

    [Column("Pre_Cariage_by")]
    [MaxLength(100)]
    public string? PreCariageBy { get; set; }

    [Column("ETD")]
    [Display(Name = "ETD")]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Etd { get; set; }

    [Column("ETA")]
    [Display(Name = "ETA")]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime Eta { get; set; }

    [Column("Mode")]
    [MaxLength(100)]
    public string? Mode { get; set; }

    [Column("Agent")]
    [MaxLength(20)]
    public string? Agent { get; set; }

    [Column("Carrier")]
    [MaxLength(20)]
    public string? Carrier { get; set; }

    [Column("Ycompany")]
    [MaxLength(1000)]
    public string? Ycompany { get; set; }

    [Column("Link")]
    [MaxLength(500)]
    public string? Link { get; set; }

    [Column("YunLock")]
    public int? YunLock { get; set; } = 0;

    [Column("Use_time")]
    public int? UseTime { get; set; } = 2025;

    [ForeignKey("Agent")]
    public virtual Agent? AgentNavigation { get; set; }

    [ForeignKey("Carrier")]
    public virtual Carrier? CarrierNavigation { get; set; }

    public virtual ICollection<TblHbl> TblHbls { get; set; } = new List<TblHbl>();
}
