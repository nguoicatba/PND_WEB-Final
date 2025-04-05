using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class TblJob
{
    [Key]
    public string JobId { get; set; } = null!;

    public string? GoodsType { get; set; }

    public DateTime JobDate { get; set; }

    public string? Mbl { get; set; }

    public DateTime? IssueDateM { get; set; }

    public DateTime? OnBoardDateM { get; set; }

    public string? VesselName { get; set; }

    public string? VoyageName { get; set; }

    public string? Pol { get; set; }

    public string? Pod { get; set; }

    public string? Podel { get; set; }

    public string? Podis { get; set; }

    public string? PlaceofReceipt { get; set; }

    public string? PlaceofDelivery { get; set; }

    public string? PreCariageBy { get; set; }

    public DateTime Etd { get; set; }

    public DateTime Eta { get; set; }

    public string? Mode { get; set; }
    
    public string? Agent { get; set; }

    public string? Carrier { get; set; }

    public string? Ycompany { get; set; }

    public string? Link { get; set; }

    public int? YunLock { get; set; }

    public int? UseTime { get; set; }

    public virtual Agent? AgentNavigation { get; set; }

    public virtual Carrier? CarrierNavigation { get; set; }

    public virtual ICollection<TblHbl> TblHbls { get; set; } = new List<TblHbl>();

    
}
