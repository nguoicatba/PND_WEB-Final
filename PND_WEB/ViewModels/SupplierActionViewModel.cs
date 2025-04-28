using PND_WEB.Models;

namespace PND_WEB.ViewModels
{
    public class SupplierActionViewModel
    {
        public TblSupplier? supplier { get; set; }
        public List<TblSupplierAction>? supplierActions { get; set; }
    }
}