namespace PND_WEB.Models
{
    public class ApplicationClaim
    {

        public required string Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public string Description { get; set; }

    }
}
