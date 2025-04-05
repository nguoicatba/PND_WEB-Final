using System;
using System.Collections.Generic;

namespace PND_WEB.Models;

public partial class TblCharge
{
    public int Id { get; set; }

    public string? DebitId { get; set; }

    public float? ExchangeRate { get; set; }

    public string? Currency { get; set; }

    public string? SerName { get; set; }

    public float? SerPrice { get; set; }

    public float? SerQuantity { get; set; }

    public string? SerUnit { get; set; }

    public float? SerVat { get; set; }

    public float? MVat { get; set; }

    public bool? Buy { get; set; }

    public bool? Sell { get; set; }

    public bool? Cont { get; set; }

    public bool? Checked { get; set; }

    public virtual TblInvoice? Debit { get; set; }
}
