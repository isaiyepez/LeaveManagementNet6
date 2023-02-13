using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;

namespace LeaveManagement.Web.Services
{
	public class EmailSender : IEmailSender
	{
		private readonly string _smtpServer;
		private readonly int _smtpPort;
		private readonly string _fromEmail;

		public EmailSender(string smtpServer, int smtpPort, string fromEmail)
		{
			_smtpServer = smtpServer;
			_smtpPort = smtpPort;
			_fromEmail = fromEmail;
		}

		public Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
			var message = new MailMessage
			{
				From = new MailAddress(_fromEmail),
				Subject = subject,
				Body = htmlMessage,
				IsBodyHtml = true
			};

			message.To.Add(new MailAddress(email));

			using (var client = new SmtpClient(_smtpServer, _smtpPort))
			{
				client.Send(message);
			}

			return Task.CompletedTask;
		}

	}
}
