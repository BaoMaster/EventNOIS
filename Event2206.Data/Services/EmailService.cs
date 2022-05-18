using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Event2206.Data.Services;

public class EmailService
{
    private readonly GlobalAppSetting.MailSettingOption _mailSetting;
    public EmailService(IOptions<GlobalAppSetting> globalAppSetting)
    {
        _mailSetting = globalAppSetting.Value.MailSetting;
    }
    private async Task SendEmailAsync(MimeMessage email)
    {
        using (var client = new SmtpClient())
        {
            client.Connect(_mailSetting.Smtp, _mailSetting.Port, SecureSocketOptions.StartTlsWhenAvailable);
            //client.AuthenticationMechanisms.Remove("XOAUTH2"); // Must be removed for Gmail SMTP
            client.Authenticate(_mailSetting.Username, _mailSetting.Pasword);
            await client.SendAsync(email).ConfigureAwait(false);
            await client.DisconnectAsync(true).ConfigureAwait(false);
        }
    }

    public async Task SendEmailAsync(string email, string subject, string body)
    {
        var mimeMessage = new MimeMessage();
        mimeMessage.From.Add(new MailboxAddress(_mailSetting.Support_DisplayName, _mailSetting.Support_DisplayEmail));
        mimeMessage.To.Add(new MailboxAddress("test",email));
        mimeMessage.Subject = subject;

        var builder = new BodyBuilder { HtmlBody = body };

        mimeMessage.Body = builder.ToMessageBody();

        await SendEmailAsync(mimeMessage);
    }
}
