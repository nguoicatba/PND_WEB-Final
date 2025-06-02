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
        public string? BookingId { get; set; }

        [Column("Customer_ID")]
        [MaxLength(20)]
        [Required(ErrorMessage = "Không được để trống Customer")]
        [Display(Name = "Customer ID")]
        public string? CustomerId { get; set; }

        [Column("Booking_Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Không được để trống Booking Date")]
        [Display(Name = "Booking Date")]
        public DateTime BookingDate { get; set; }

        [Column("Good_Type")]
        [MaxLength(20)]
        [Required(ErrorMessage = "Không được để trống Good Type")]
        [Display(Name = "Good Type")]
        public string? GoodType { get; set; } // FCL, LCL, Air, etc.

        // Sea Transport Fields
        [Column("ETD")]
        [Required(ErrorMessage = "Không được để trống ETD")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "ETD")]
        public DateTime ETD { get; set; }

        [Column("ETA")]
        [Required(ErrorMessage = "Không được để trống ETA")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "ETA")]
        public DateTime ETA { get; set; }

        [Column("POL")]
        [MaxLength(100)]
        [Display(Name = "POL")]
        public string? POL { get; set; }

        [Column("POD")]
        [MaxLength(100)]
        [Display(Name = "POD")]
        public string? POD { get; set; }

        // Sea specific fields
        [Column("Vessel_Name")]
        [MaxLength(100)]
        [Display(Name = "Vessel Name")]
        public string? VesselName { get; set; }

        [Column("Container_Type")]
        [MaxLength(20)]
        [Display(Name = "Container Type")]
        public string? ContainerType { get; set; }

        [Column("Container_Quantity")]
        [Display(Name = "Container Quantity")]
        public int? ContainerQuantity { get; set; }

        // Air specific fields
        [Column("Flight_Number")]
        [MaxLength(20)]
        [Display(Name = "Flight Number")]
        public string? FlightNumber { get; set; }

        [Column("Airline")]
        [MaxLength(100)]
        [Display(Name = "Airline")]
        public string? Airline { get; set; }

        [Column("Package_Quantity")]
        [Display(Name = "Package Quantity")]
        public int? PackageQuantity { get; set; }

        [Column("Gross_Weight")]
        [Display(Name = "Gross Weight (KG)")]
        public decimal? GrossWeight { get; set; }

        [Column("Chargeable_Weight")]
        [Display(Name = "Chargeable Weight(KG)")]
        public decimal? ChargeableWeight { get; set; }

        [Column("Volume")]
        [Display(Name = "Volume (CBM)")]
        public decimal? Volume { get; set; }

        // Common fields
        [Column("Cargo_Description")]
        [MaxLength(500)]
        [Display(Name = "Cargo Description")]
        public string? CargoDescription { get; set; }

        [Column("Status")]
        [MaxLength(20)]
        [Display(Name = "Status")]
        public string? Status { get; set; }

        [Column("Remarks")]
        [MaxLength(1000)]
        [Display(Name = "Remarks")]
        public string? Remarks { get; set; }

        [Column("Created_Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        [Column("Updated_Date")]
        [Display(Name = "Updated Date")]
        public DateTime? UpdatedDate { get; set; }

        [Column("StaffName")]
        [Display(Name = "Staff Name")]
        public string? StaffName { get; set; }

        [Column("Contact")]
        [Display(Name = "Staff Contact")]
        public string? Contact { get; set; }

        [Column("PIC_company")]
        [Display(Name = "PIC Company")]
        public string? PICcompany { get; set; }

        [Column("Quotation_Id")]
        [Display(Name = "Quotation Id")]
        public string? QuotationId { get; set; }

        [Column("CNEE")]
        [MaxLength(200)]
        [Display(Name = "CNEE")]
        public string? CNEE { get; set; }

        [Column("Shipper")]
        [MaxLength(200)]
        [Display(Name = "Shipper")]
        public string? Shipper { get; set; }

        // Navigation property
        [ForeignKey("CustomerId")]
        public virtual TblCustomer? Customer { get; set; }
    }
} 