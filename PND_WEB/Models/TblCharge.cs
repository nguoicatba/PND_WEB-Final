using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models;


[Table("tbl_CHARGES")]
public partial class TblCharge
{
    [Column("ID")]
    public int Id { get; set; }

    [Column("Debit_ID")]

    public string? DebitId { get; set; }


    [Column("Ser_Name")]
    [MaxLength(255)]
    [Display(Name = "Name Fee")]
    public string? SerName { get; set; }


    [Column("Ser_Unit")]
    [MaxLength(100)]
    [Display(Name = "Unit")]
    public string? SerUnit { get; set; }

    [Column("Ser_Quantity")]
    [Display(Name = "Quantity")]
    public float? SerQuantity { get; set; }


    [Column("Ser_Price")]
    [Display(Name = "Price")]

    public float? SerPrice { get; set; }


    [Column("Currency")]
    [MaxLength(20)]
    [Display(Name = "Currency")]
    public string? Currency { get; set; }



    [Column("Exchange_rate")]
    [Display(Name = "Exchange Rate")]
    public float? ExchangeRate { get; set; }

    [Column("Ser_VAT")]
    [Display(Name = "VAT")]

    public float? SerVat { get; set; }

    [Column("M_VAT")]
    public float? MVat { get; set; }

    
    [Column("Checked")]
    public bool? Checked { get; set; }

    [ForeignKey("DebitId")]
    public virtual TblInvoice? Debit { get; set; }

   
}
