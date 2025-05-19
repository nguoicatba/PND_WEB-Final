using PND_WEB.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PND_WEB.ViewModels
{
    public class ExportHblVM
    {
        public string Hbl { get; set; } = null!;

        public string? RequestId { get; set; } = null!;
        public string? GoodType { get; set; } = null!;

        public TblShipper? Shipper { get; set; } 

        public TblCnee? Cnee { get; set; } 

        public string? NotifyParty { get; set; } 

        public TblCnee? NotifyPartyCnee { get; set; }

        public string? PlaceOfReceipt { get; set; }
        public string? PlaceOfDelivery { get; set; }

        public string? Pod { get; set; }
        public string? Pol { get; set; }

        public string? PreCariageBy { get; set; }

        public string? NumberOfOriginal { get; set; }

        public string? Transport { get; set; }

        public string? FreightPayable { get; set; }

        public string? MarkNo { get; set; }

        public string? Quantity { get; set; }
        public string? DescriptionOfGoods { get; set; }

        public double? GrossWeight { get; set; }

        public double? Tonnage { get; set; }

        
        public bool? FreightCharge { get; set; }

 
        public bool? Prepaid { get; set; }

     
        public bool? Collect { get; set; }

        public string? BILL_TYPE { get; set; }


    }
}
