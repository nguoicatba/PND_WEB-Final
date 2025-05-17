using PND_WEB.Models;

namespace PND_WEB.ViewModels
{
    public class DebitNoteExport
    {
        public string ?JobId { get; set; }
        public string ?JobType { get; set; }

        public string ?Cnee { get; set; }
        public string ?MBL { get; set; }
        public string? HBL { get; set; }

        public DateTime? Today { get; set; }

        public DateTime? ETA { get; set; }

        public string ? Quantity { get; set; }

        public string ? GrossWeight { get; set; }

        public string ? CBM { get; set; }

        public string? POL { get; set; }
        public string? POD { get; set; }

        public string? PODel { get; set; }


        public float? Total { get; set; }

        public List<TblCharge>? Charges { get; set; }

        public float Amount(TblCharge tblCharge)
        {
            if (tblCharge == null)
                return 0;
            float amount = (tblCharge.SerPrice ?? 0) * (tblCharge.SerQuantity ?? 0) * (tblCharge.ExchangeRate ?? 1) * (1 + (tblCharge.SerVat ?? 0) / 100) + (tblCharge.MVat ?? 0);

            return amount;

        }



    }
}
