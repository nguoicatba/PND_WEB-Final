using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.ViewModels
{
    public class BuyChargeVM
    {
        public string? HBL_Id { get; set; }  

        public List<BuyChargeEM> ?_charges;


    }
}
