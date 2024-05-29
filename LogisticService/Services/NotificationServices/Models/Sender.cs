using System.Security;

namespace LogisticService.Services.NotificationService.Models
{
	public class Sender
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public SecureString Password { get; set; }
	}
}
