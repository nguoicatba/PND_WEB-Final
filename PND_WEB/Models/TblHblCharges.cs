using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models
{
    [Table("tbl_HBL_CHARGES")]
    public class TblHblCharges
    {
        [Key]
        [Column("Charge_ID")]
        public string ChargeId { get; set; } = null!;

        [Column("Supplier_ID")]
        [MaxLength(20)]
        public string ?SupplierId { get; set; }

        [Column("Customer_ID")]
        [MaxLength(20)]
        public string ?CustomerId { get; set; }

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
        
        public float? ExchangeRate { get; set; }

        [Column("Ser_VAT")]
        
        public float? SerVat { get; set; }

        [Column("M_VAT")]
        public float? MVat { get; set; }


        [Column("Checked")]
        public bool? Checked { get; set; }


        [Column("Created_Date")]
        public DateTime CreatedDate { get; set; }

        [Column("Updated_Date")]
        public DateTime? UpdatedDate { get; set; }

        [Column("Invoice No")]
        public string? InvoiceNo { get; set; }


        [Column("Buy")]
        public bool? Buy { get; set; }

        [Column("Sell")]

        public bool? Sell { get; set; }

        [Column("Cont")]

        public bool? Cont { get; set; }

        [Column("Behalf")]

        public bool? Behalf { get; set; }


        [Column("HBL_ID")]
        [Required]
        public string? HblId { get; set; }



    }
} 