using System.Text.Json.Serialization;

namespace PND_WEB.ViewModels
{
    public class ApproveChargesEM
    {
        public List<ChargeGroup> chargegroup { get; set; }
        public string hblId { get; set; }
    }

    public class ChargeGroup
    {
        public string chargeid { get; set; }
        public bool isSelected { get; set; }
    }
} 