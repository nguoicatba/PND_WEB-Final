namespace PND_WEB.ViewModels
{
    public class ChangePasswordViewModel
    {
        public required string UserName { get; set; }
        public required string OldPassword { get; set; }
        public required string NewPassword { get; set; }
        public required string ConfirmPassword { get; set; }

    }
}
