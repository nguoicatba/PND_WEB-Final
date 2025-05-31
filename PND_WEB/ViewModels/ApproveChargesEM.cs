using System.Text.Json.Serialization;

namespace PND_WEB.ViewModels
{
    public class ApproveChargesEM
    {
        public string hblId { get; set; }
        public List<ChargeGroup> chargegroup { get; set; }
    }

    public class ChargeGroup
    {
        public string chargeid { get; set; }
        public bool isSelected { get; set; }
    }
} 