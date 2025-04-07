using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.Models
{
    [Table("tbl_HBL")]  
    public partial class TblHbl
    {
        [Key]
        [Column("HBL")]  
        [MaxLength(50)]  
        public string Hbl { get; set; } = null!;

        [Column("Request_ID")]
        [MaxLength(50)]  
        public string? RequestId { get; set; }

        [Column("Issue_placeH")]
        [MaxLength(255)]  
        public string? IssuePlaceH { get; set; }

        [Column("Issue_dateH")]
        public DateTime? IssueDateH { get; set; }

        [Column("OnBoard_dateH")]
        public DateTime? OnBoardDateH { get; set; }

        [Column("Customer_ID")]
        [MaxLength(20)]  
        public string? CustomerId { get; set; }

        [Column("Shipper")]
        [MaxLength(255)]  
        public string? Shipper { get; set; }

        [Column("CNEE")]
        [MaxLength(255)]  
        public string? Cnee { get; set; }

        [Column("Notify_party")]
        [MaxLength(255)]  
        public string? NotifyParty { get; set; }

        [Column("BL_type")]
        [MaxLength(100)] 
        public string? BlType { get; set; }

        [Column("Nom_Free")]
        [MaxLength(100)] 
        public string NomFree { get; set; } = null!;

        [Column("Cont_Seal_No")]
        [MaxLength(1000)]  
        public string? ContSealNo { get; set; }

        [Column("Volume")]
        [MaxLength(255)]  
        public string? Volume { get; set; }

        [Column("Quantity")]
        [MaxLength(255)]  
        public string? Quantity { get; set; }

        [Column("Goods_desciption")]
        [MaxLength(255)]  
        public string? GoodsDesciption { get; set; }

        [Column("Gross_weight")]
        public double? GrossWeight { get; set; }

        [Column("Tonnage")]
        public double? Tonnage { get; set; }

        [Column("Customs_declaration_No")]
        [MaxLength(100)]  
        public string? CustomsDeclarationNo { get; set; }

        [Column("Invoice_No")]
        [MaxLength(50)]  
        public string? InvoiceNo { get; set; }

        [Column("NumberofOrigins")]
        [MaxLength(100)] 
        public string? NumberofOrigins { get; set; }

        [Column("Freight_Payable")]
        [MaxLength(100)] 
        public string? FreightPayable { get; set; }

        [Column("Mark_Nos")]
        [MaxLength(1000)] 
        public string? MarkNos { get; set; }

        [Column("Freight_charge")]
        public bool? FreightCharge { get; set; }

        [Column("Prepaid")]
        public bool? Prepaid { get; set; }

        [Column("Collect")]
        public bool? Collect { get; set; }

        [Column("SI_No")]
        [MaxLength(20)]  
        public string? SiNo { get; set; }

        [Column("PIC")]
        [MaxLength(255)]  
        public string? Pic { get; set; }

        [Column("DO_date")]
        public DateTime? DoDate { get; set; }

        [Column("PIC_phone")]
        [MaxLength(20)]  
        public string? PicPhone { get; set; }

      
        [ForeignKey("RequestId")]
        public virtual TblJob? Request { get; set; }

        [ForeignKey("CustomerId")]
        public virtual TblCustomer? Customer { get; set; }

        [ForeignKey("Shipper")]
        public virtual TblShipper? ShipperNavigation { get; set; }

        [ForeignKey("Cnee")]
        public virtual TblCnee? CneeNavigation { get; set; }

        public virtual ICollection<TblConth> TblConths { get; set; } = new List<TblConth>();

        public virtual ICollection<TblInvoice> TblInvoices { get; set; } = new List<TblInvoice>();
    }
}
