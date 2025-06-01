using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class Quotation
{
    [Key]
    [Display(Name = "Quotation Id")]
    public string QuotationId { get; set; } = null!;

    [Display(Name = "Status")]
    public string? Qsatus { get; set; }

    [Display(Name = "Staff Name")]
    public string? StaffName { get; set; }

    [Display(Name = "Staff Contact")]
    public string? Contact { get; set; }

    [Display(Name = "Create date")]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? Qdate { get; set; }

    [Display(Name = "Customer")]
    public string? CusTo { get; set; }

    [Display(Name = "Customer Contact")]
    public string? CusContact { get; set; }

    [Display(Name = "Valid")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? Valid { get; set; }

    [Display(Name = "Term")]
    public string? Term { get; set; }

    [Display(Name = "Vol")]
    public string? Vol { get; set; }

    [Display(Name = "Commodity")]
    public string? Commodity { get; set; }

    [Display(Name = "POL")]
    public string? Pol { get; set; }

    [Display(Name = "Address")]
    public string? Adds { get; set; }

    [Display(Name = "POD")]
    public string? Pod { get; set; }

    public virtual ICollection<QuotationsCharge> QuotationsCharges { get; set; } = new List<QuotationsCharge>();
}
