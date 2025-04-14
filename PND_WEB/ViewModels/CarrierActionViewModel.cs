using PND_WEB.Models;

namespace PND_WEB.ViewModels
{
    public class CarrierActionViewModel
    {
      public Carrier? carrier { get; set; }
      public List<CarrierAction>? carrierActions { get; set; }
    }
}
