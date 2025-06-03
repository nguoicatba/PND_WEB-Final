using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.ViewModels
{
    public class SellChargeVM
    {
        public string? HBL_Id { get; set; }
        public string? JOB_Id { get; set; }

        public List<SellChargeEM> ?_charges;
    }
} 