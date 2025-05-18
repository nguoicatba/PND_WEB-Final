using PND_WEB.Models;

namespace PND_WEB.ViewModels
{
    public class ExportPDFDeliveryOrderVM
    {
        public required string  JobId { get; set; }

        public string? POL { get; set; }
        public string ? POD { get; set; }

        public string? CNEE { get; set; }

        public string ? MBL { get; set; }
        public string? HBL { get; set; }

        public string? Vessel { get; set; }

        public string? Voyage { get; set; }

        public string? Podel { get; set; }

        public required DateTime  ArriveOn { get; set; }
        public List<TblConth> conths { get; set; } = new List<TblConth>();





    }
}
