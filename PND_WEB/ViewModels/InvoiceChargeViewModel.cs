using PND_WEB.Models;

namespace PND_WEB.ViewModels
{
    public class InvoiceChargeViewModel
    {
        public string? HBL_ID { get; set; }
        public TblInvoice? Invoice { get; set; }

        public List<TblCharge> ?_Charges { get; set; }

        public float? TotalAmount { get; set; } = 0;
        public float Amount(TblCharge tblCharge)
        {
            if (tblCharge == null)
                return 0;
            float amount = (tblCharge.SerPrice ?? 0) * (tblCharge.SerQuantity ?? 0) * (tblCharge.ExchangeRate ?? 1) * (1 + (tblCharge.SerVat ?? 0) / 100) + (tblCharge.MVat ?? 0); 

            return amount;

        }

  
        


    }
}
