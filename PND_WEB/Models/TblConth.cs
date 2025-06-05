using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;


public partial class TblConth
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Container No")]
    public string? ContNo { get; set; }

    [Display(Name = "HBL")]
    public string? Hbl { get; set; }

    [Display(Name = "Container Quantity")]
    public int? ContQuantity { get; set; }

    [Display(Name = "Container Type")]
    public string? ContType { get; set; }

    [Display(Name = "Seal No")]
    public string? SealNo { get; set; }

    [Display(Name = "Gross Weight")]
    public double GrossWeight { get; set; } = 0;

    [Display(Name = "CBM")]
    public double Cmb { get; set; } = 0;

    [Display(Name = "Goods Quantity")]
    public string? GoodsQuantity { get; set; }

    [Display(Name = "Goods Kind")]
    public string? GoodsKind { get; set; }

    [Display(Name = "Goods Description")]
    public string? GoodsDepcription { get; set; }

    public virtual TblHbl? HblNavigation { get; set; }
}
