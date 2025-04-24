using PND_WEB.Models;

namespace PND_WEB.ViewModels
{
    public class HblJobEditModel
    {
        public string? Job_ID { get; set; }
        public TblHbl Hbl { get; set; }

        public bool FreightCharge { get; set; }


        public bool Prepaid { get; set; }


        public bool Collect { get; set; }
    }
}
