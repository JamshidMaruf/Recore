using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Recore.Data.IRepositories;
using Recore.Service.Helpers;
using Recore.Service.Interfaces;

namespace Recore.Service.Services;

public class EmailService : IEmailService
{
    private readonly EmailSettings _settings;
    public EmailService(IOptions<EmailSettings> options)
    {
        _settings = options.Value;
    }
    public async ValueTask SendEmailAsync(MailRequest request)
    {
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(_settings.Email));
        email.To.Add(MailboxAddress.Parse(request.ToEmail));
        email.Subject = request.Subject;
        var builder = new BodyBuilder();
        builder.HtmlBody = request.Body;
        email.Body = builder.ToMessageBody();

        using var smtp = new SmtpClient();
        smtp.Connect(_settings.Host, _settings.Port, SecureSocketOptions.StartTls);
        smtp.Authenticate(_settings.Email, _settings.Password);
        await smtp.SendAsync(email);
        smtp.Disconnect(true);
    }
}
