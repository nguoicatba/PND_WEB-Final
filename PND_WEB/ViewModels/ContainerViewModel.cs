using PND_WEB.Models;

namespace PND_WEB.ViewModels
{
    public class ContainerViewModel
    {
        public string HBL_ID { get; set; }
  
        public List<TblConth>? containers { get; set; }

        public double  totalGrossWeight { get; set; }
        public double totalCbm { get; set; }

    }
}
