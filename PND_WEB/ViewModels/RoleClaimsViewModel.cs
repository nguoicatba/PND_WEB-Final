namespace PND_WEB.ViewModels
{
    public class RoleClaimsViewModel
    {
        public required string RoleId { get; set; }
        

        public List<ClaimViewModel> ?Claims { get; set; }
    }
}
