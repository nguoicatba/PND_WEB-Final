using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models
{
    [Table("tbl_DEBIT_CREDIT_NOTE")]
    public class TblDebitCreditNote
    {
        [Key]
        [Column("Note_ID")]
        [MaxLength(20)]
        public string NoteId { get; set; } = null!;

        [Column("Note_Type")]
        [MaxLength(10)]
        [Required]
        [Display(Name = "Loại chứng từ")]
        public string NoteType { get; set; } = null!; // DEBIT/CREDIT

        [Column("Note_No")]
        [MaxLength(50)]
        [Required]
        [Display(Name = "Số chứng từ")]
        public string NoteNo { get; set; } = null!;

        [Column("Note_Date")]
        [Required]
        [Display(Name = "Ngày chứng từ")]
        public DateTime NoteDate { get; set; }

        [Column("HBL_No")]
        [MaxLength(50)]
        [Required]
        [Display(Name = "Số House Bill")]
        public string HblNo { get; set; } = null!;

        [Column("Partner_ID")]
        [MaxLength(20)]
        [Required]
        [Display(Name = "Mã đối tác")]
        public string PartnerId { get; set; } = null!; // Customer ID for Debit, Supplier ID for Credit

        [Column("Total_Amount")]
        [Required]
        [Display(Name = "Tổng tiền")]
        public decimal TotalAmount { get; set; }

        [Column("Currency")]
        [MaxLength(5)]
        [Required]
        [Display(Name = "Loại tiền")]
        public string Currency { get; set; } = "USD";

        [Column("Payment_Status")]
        [MaxLength(20)]
        [Required]
        [Display(Name = "Trạng thái thanh toán")]
        public string PaymentStatus { get; set; } = "PENDING"; // PENDING, PAID, CANCELLED

        [Column("Due_Date")]
        [Required]
        [Display(Name = "Ngày đến hạn")]
        public DateTime DueDate { get; set; }

        [Column("Payment_Date")]
        [Display(Name = "Ngày thanh toán")]
        public DateTime? PaymentDate { get; set; }

        [Column("Payment_Method")]
        [MaxLength(50)]
        [Display(Name = "Phương thức thanh toán")]
        public string? PaymentMethod { get; set; }

        [Column("Notes")]
        [MaxLength(500)]
        [Display(Name = "Ghi chú")]
        public string? Notes { get; set; }

        [Column("Created_Date")]
        public DateTime CreatedDate { get; set; }

        [Column("Updated_Date")]
        public DateTime? UpdatedDate { get; set; }

        // Navigation properties
        [ForeignKey("HblNo")]
        public virtual TblHbl Hbl { get; set; } = null!;
    }
} 