using Microsoft.Extensions.Options;
using MimeKit;
using System.Net;
using System.Net.Mail;

//https://learn.microsoft.com/de-de/dotnet/api/system.net.mail.smtpclient.send?view=netframework-4.7.2#System_Net_Mail_SmtpClient_Send_System_Net_Mail_MailMessage_
namespace AdityaSoftwares.Models
{
    public interface IEmailService
    {
        bool SendEmail(EmailData emailData);
    }
    public class EmailService : IEmailService
    {
        EmailSettings _emailSettings = null;
        public EmailService(IOptions<EmailSettings> options)
        {
            _emailSettings = options.Value;
        }

        public bool SendEmail(EmailData emailData)
        {
            try
            {
                MimeMessage emailMessage = new MimeMessage();
                MailMessage message = new MailMessage(_emailSettings.EmailId, emailData.EmailToId);

                message.Body = @"Using this new feature, you can send an email message from an application very easily.";
                SmtpClient client = new SmtpClient("smtp.ethereal.email"); //host
                // Credentials are necessary if the server requires the client
                // to authenticate before it will send email on the client's behalf.
                try
                {
                    client.Port = 587;
                   
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                 
                client.Credentials = new NetworkCredential("cecil58@ethereal.email", "XkXPezNxWY6h8J9381");
                    //client.Credentials = new NetworkCredential("adityasoftwares256@gmail.com", "manya@8693");
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
               
                
               
                    client.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                        ex.ToString());
                }
                
               

                return true;
            }
            catch (Exception ex)
            {
                //Log Exception Details
                return false;
            }
        }
    }
}
