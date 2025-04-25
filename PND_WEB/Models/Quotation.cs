using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.Models;

public partial class Quotation
{
    [Key]
    public string QuotationId { get; set; } = null!;

    public string? Qsatus { get; set; }

    public string? StaffName { get; set; }

    public string? Contact { get; set; }


    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? Qdate { get; set; }

    public string? CusTo { get; set; }

    public string? CusContact { get; set; }

    public DateTime? Valid { get; set; }

    public string? Term { get; set; }

    public string? Vol { get; set; }

    public string? Commodity { get; set; }

    public string? Pol { get; set; }

    public string? Adds { get; set; }

    public string? Pod { get; set; }

    public virtual ICollection<QuotationsCharge> QuotationsCharges { get; set; } = new List<QuotationsCharge>();
}
