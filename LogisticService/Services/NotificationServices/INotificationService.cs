using LogisticService.Services.NotificationService.Models;
using System.Net.Mail;

namespace LogisticService.Services.NotificationService
{
	public interface INotificationService
	{
		void SendMessage(MailData data);
	}
}
