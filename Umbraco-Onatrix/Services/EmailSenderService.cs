using Azure;
using Azure.Communication.Email;

namespace Umbraco_Onatrix.Services;

public class EmailSenderService
{
	private readonly string connectionString = "endpoint=https://umbraco-email-sender.europe.communication.azure.com/;accesskey=7eKPyB09vcaHQuGMPmWI35oGh2QOnc3fnkMTYFT0jjga3Iw8e2utJQQJ99AJACULyCpBtl7YAAAAAZCSx60V";

	public async Task SendEmailAsync(string toEmail)
	{
		var emailClient = new EmailClient(connectionString);

		// Skapa e-postinnehåll
		var emailContent = new EmailContent("Onatrix Form Confirmation") // Ämnet för e-posten
		{
			PlainText = "Onatrix testing.."
		};

		// Skapa mottagare
		var emailRecipients = new EmailRecipients(new List<EmailAddress>
			{
				new EmailAddress(toEmail) // Här har vi tagit bort DisplayName
            });

		// Skapa EmailMessage
		var emailMessage = new EmailMessage(
			/*senderAddress: "DoNotReply@7e3b8297-96e4-461f-92f7-ad0c6f39d454.azurecomm.net",*/ // Din verifierade avsändaradress
			senderAddress: "DoNotReply@112963db-3f7a-4181-9d67-1ac73b194137.azurecomm.net",
			content: emailContent,
			recipients: emailRecipients
		);

		try
		{
			// Skicka e-post
			var emailSendOperation = await emailClient.SendAsync(WaitUntil.Completed, emailMessage);

			if (emailSendOperation.HasCompleted)
			{
				Console.WriteLine("E-post skickad framgångsrikt!");
			}
		}
		catch (RequestFailedException ex)
		{
			Console.WriteLine($"E-post skickades inte: {ex.Message}");
		}
	}
}
