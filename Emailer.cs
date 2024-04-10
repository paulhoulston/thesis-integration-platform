using System.Net.Mail;
using System.Net;

namespace thesis_integration_platform;

class Emailer
{
    static readonly NetworkCredential _credentials = new(Configuration.SmtpUser, Configuration.SmtpPassword);

    public class EmailDetails
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Recipient { get; set; }
    }

    public void Send(EmailDetails details)
    {
        using var message = new MailMessage
        {
            From = new MailAddress(Configuration.SmtpUser, Configuration.SmtpUser),
            Subject = details.Subject,
            Body = details.Body,
            IsBodyHtml = false
        };
        message.To.Add(new MailAddress(details.To, details.Recipient));

        using var client = new SmtpClient("smtp.office365.com")
        {
            UseDefaultCredentials = false,
            Port = 587,
            Credentials = _credentials,
            EnableSsl = true,
        };

        try
        {
            client.Send(message);
        }
        catch (Exception)
        {
            // Email not sent....silently continue
        }
    }
}
