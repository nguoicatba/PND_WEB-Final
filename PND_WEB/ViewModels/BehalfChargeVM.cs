using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PND_WEB.ViewModels
{
    public class BehalfChargeVM
    {
        public string? HBL_Id { get; set; }
        public string? JOB_Id { get; set; }

        public List<BehalfChargeEM> ?_charges;
    }
} 