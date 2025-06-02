using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models
{
    [Table("INVOICE_CHARGE")]
    public class InvoiceCharge
    {
        [Key]
        [Column("ID")]
        public  string Id { get; set; }

        [Column("Invoice_ID")]
        [Required]
        public string InvoiceId { get; set; } = null!;

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
        [Display(Name = "M VAT")]
        public float? MVat { get; set; }

        [Column("Checked")]
        public bool? Checked { get; set; }

        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; } = null!;
    }
} 