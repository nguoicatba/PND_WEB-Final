using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models
{
    [Table("tbl_DEBIT_CREDIT_NOTE_DETAIL")]
    public class TblDebitCreditNoteDetail
    {
        [Key]
        [Column("Detail_ID")]
        [MaxLength(20)]
        public string DetailId { get; set; } = null!;

        [Column("Note_ID")]
        [MaxLength(20)]
        [Required]
        public string NoteId { get; set; } = null!;

        [Column("Charge_ID")]
        [MaxLength(20)]
        [Required]
        public string ChargeId { get; set; } = null!;

        [Column("Description")]
        [MaxLength(200)]
        [Required]
        [Display(Name = "Diễn giải")]
        public string Description { get; set; } = null!;

        [Column("Quantity")]
        [Required]
        [Display(Name = "Số lượng")]
        public decimal Quantity { get; set; } = 1;

        [Column("Unit_Price")]
        [Required]
        [Display(Name = "Đơn giá")]
        public decimal UnitPrice { get; set; }

        [Column("Amount")]
        [Required]
        [Display(Name = "Thành tiền")]
        public decimal Amount { get; set; }

        [Column("Currency")]
        [MaxLength(5)]
        [Required]
        [Display(Name = "Loại tiền")]
        public string Currency { get; set; } = "USD";

        [Column("Created_Date")]
        public DateTime CreatedDate { get; set; }

        [Column("Updated_Date")]
        public DateTime? UpdatedDate { get; set; }

        // Navigation properties
        [ForeignKey("NoteId")]
        public virtual TblDebitCreditNote Note { get; set; } = null!;

        [ForeignKey("ChargeId")]
        public virtual TblHblCharges Charge { get; set; } = null!;
    }
} 