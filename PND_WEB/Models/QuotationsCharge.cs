using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class QuotationsCharge
{
    [Key]
    public int ChargeId { get; set; }

    public string? QuotationId { get; set; }

    [Display(Name = "Fee Name")]
    public string? ChargeName { get; set; }

    [Display(Name = "Quantity")]
    public double? Quantity { get; set; }

    [Display(Name = "Unit")]
    public string? Unit { get; set; }

    [Display(Name = "Rate")]
    public double? Rate { get; set; }

    [Display(Name = "Currency")]
    public string? Currency { get; set; }

    [Display(Name = "Notes")]
    public string? Notes { get; set; }

    public virtual Quotation? Quotation { get; set; }
}
