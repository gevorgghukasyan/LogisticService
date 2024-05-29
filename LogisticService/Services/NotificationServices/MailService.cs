using LogisticService.Services.NotificationService.Models;
using System.Net;
using System.Net.Mail;

namespace LogisticService.Services.NotificationService
{
	public class MailService : INotificationService
	{
		public void SendMessage(MailData data)
		{
			using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
			{
				EnableSsl = true,
				Timeout = 10000,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(data.Sender.Email, data.Sender.Password)
			})
			{

				MailMessage mailMessage = new MailMessage();
				mailMessage.To.Add(data.Receiver.Email);
				mailMessage.From = new MailAddress(data.Sender.Email);
				mailMessage.Subject = data.Subject;
				mailMessage.Body = data.Body;

				client.Send(mailMessage);
			}
		}
	}
}
