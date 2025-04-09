namespace PND_WEB.ViewModels
{
    public class ChangePasswordViewModel
    {
        public required string UserId { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmPassword { get; set; }

    }
}
