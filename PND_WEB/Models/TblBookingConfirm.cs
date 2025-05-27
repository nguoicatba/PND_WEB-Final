using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models
{
    [Table("tbl_BOOKING_CONFIRM")]
    public partial class TblBookingConfirm
    {
        [Key]
        [Column("Booking_ID")]
        [MaxLength(20)]
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Booking ID")]
        public string BookingId { get; set; } = null!;

        [Column("Customer_ID")]
        [MaxLength(20)]
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Customer ID")]
        public string CustomerId { get; set; } = null!;

        [Column("Booking_Date")]
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Ngày đặt")]
        public DateTime BookingDate { get; set; }

        [Column("Good_Type")]
        [MaxLength(20)]
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Loại hàng")]
        public string GoodType { get; set; } = null!; // FCL, LCL, Air, etc.

        // Sea Transport Fields
        [Column("ETD")]
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Ngày khởi hành dự kiến")]
        public DateTime ETD { get; set; }

        [Column("ETA")]
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Ngày đến dự kiến")]
        public DateTime ETA { get; set; }

        [Column("POL")]
        [MaxLength(100)]
        [Display(Name = "Cảng/Sân bay đi")]
        public string? POL { get; set; }

        [Column("POD")]
        [MaxLength(100)]
        [Display(Name = "Cảng/Sân bay đến")]
        public string? POD { get; set; }

        // Sea specific fields
        [Column("Vessel_Name")]
        [MaxLength(100)]
        [Display(Name = "Tên tàu")]
        public string? VesselName { get; set; }

        [Column("Container_Type")]
        [MaxLength(20)]
        [Display(Name = "Loại container")]
        public string? ContainerType { get; set; }

        [Column("Container_Quantity")]
        [Display(Name = "Số lượng container")]
        public int? ContainerQuantity { get; set; }

        // Air specific fields
        [Column("Flight_Number")]
        [MaxLength(20)]
        [Display(Name = "Số hiệu chuyến bay")]
        public string? FlightNumber { get; set; }

        [Column("Airline")]
        [MaxLength(100)]
        [Display(Name = "Hãng hàng không")]
        public string? Airline { get; set; }

        [Column("Package_Quantity")]
        [Display(Name = "Số lượng kiện")]
        public int? PackageQuantity { get; set; }

        [Column("Gross_Weight")]
        [Display(Name = "Tổng trọng lượng (kg)")]
        public decimal? GrossWeight { get; set; }

        [Column("Chargeable_Weight")]
        [Display(Name = "Trọng lượng tính cước (kg)")]
        public decimal? ChargeableWeight { get; set; }

        [Column("Volume")]
        [Display(Name = "Thể tích (CBM)")]
        public decimal? Volume { get; set; }

        // Common fields
        [Column("Cargo_Description")]
        [MaxLength(500)]
        [Display(Name = "Mô tả hàng hóa")]
        public string? CargoDescription { get; set; }

        [Column("Status")]
        [MaxLength(20)]
        [Display(Name = "Trạng thái")]
        public string? Status { get; set; }

        [Column("Remarks")]
        [MaxLength(1000)]
        [Display(Name = "Ghi chú")]
        public string? Remarks { get; set; }

        [Column("Created_Date")]
        [Display(Name = "Ngày tạo")]
        public DateTime CreatedDate { get; set; }

        [Column("Updated_Date")]
        [Display(Name = "Ngày cập nhật")]
        public DateTime? UpdatedDate { get; set; }

        // Navigation property
        [ForeignKey("CustomerId")]
        public virtual TblCustomer Customer { get; set; } = null!;
    }
} 