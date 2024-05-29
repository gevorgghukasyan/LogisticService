using System.Net.Mail;

namespace LogisticService.Services.NotificationService.Models
{
	public class MailData
	{
		public string Subject { get; set; }
		public string Body { get; set; }
		public Sender Sender { get; set; }
		public Receiver Receiver { get; set; }
	}
}
