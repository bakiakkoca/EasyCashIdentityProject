namespace EasyCashIdentityProject.PresentationLayer.Models
{
	public class LoginViewModel
	{
		public string? Username { get; set; } //nullable ozelligi icin ? koydum yoksa hata veriyordu
		public string? Password { get; set; }
	}
}
