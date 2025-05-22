namespace PND_WEB.ViewModels
{
    public class RoleClaimsViewModel
    {
        public required string RoleId { get; set; }

        public required string RoleName { get; set; }


        public List<ClaimViewModel> ?Claims { get; set; }
    }
}
