using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PND_WEB.ViewModels
{
    public class BuyChargeEM
    {
        [Key]
        [Column("Charge_ID")]
        public string ChargeId { get; set; } = null!;

        [Column("Supplier_ID")]
        [MaxLength(20)]
        [Display(Name = "Supplier ID")]
        public string? SupplierId { get; set; }

        public string? SupplierName { get; set; }

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
        [Display(Name = "Checked")]
        public bool? Checked { get; set; }

        [Display(Name = "Create Date")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Updated Date")]
        public DateTime? UpdatedDate { get; set; }

        [Display(Name = "Invoice No")]
        public string? InvoiceNo { get; set; }

        [Column("Buy")]
        public bool? Buy { get; set; }

        [Column("HBL_ID")]
        [Required]
        public string? HblId { get; set; }
    }
}
