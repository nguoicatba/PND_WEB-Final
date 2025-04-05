using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class TblHbl
{
    [Key]
    public string Hbl { get; set; } = null!;

    public string? RequestId { get; set; }

    public string? IssuePlaceH { get; set; }

    public DateTime? IssueDateH { get; set; }

    public DateTime? OnBoardDateH { get; set; }

    public string? CustomerId { get; set; }

    public string? Shipper { get; set; }

    public string? Cnee { get; set; }

    public string? NotifyParty { get; set; }

    public string? BlType { get; set; }

    public string NomFree { get; set; } = null!;

    public string? ContSealNo { get; set; }

    public string? Volume { get; set; }

    public string? Quantity { get; set; }

    public string? GoodsDesciption { get; set; }

    public double? GrossWeight { get; set; }

    public double? Tonnage { get; set; }

    public string? CustomsDeclarationNo { get; set; }

    public string? InvoiceNo { get; set; }

    public string? NumberofOrigins { get; set; }

    public string? FreightPayable { get; set; }

    public string? MarkNos { get; set; }

    public bool? FreightCharge { get; set; }

    public bool? Prepaid { get; set; }

    public bool? Collect { get; set; }

    public string? SiNo { get; set; }

    public string? Pic { get; set; }

    public DateTime? DoDate { get; set; }

    public string? PicPhone { get; set; }

    public virtual TblCnee? CneeNavigation { get; set; }

    public virtual TblCustomer? Customer { get; set; }

    public virtual TblJob? Request { get; set; }

    public virtual TblShipper? ShipperNavigation { get; set; }

    public virtual ICollection<TblConth> TblConths { get; set; } = new List<TblConth>();

    public virtual ICollection<TblInvoice> TblInvoices { get; set; } = new List<TblInvoice>();
}
