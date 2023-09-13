using Recore.Service.Helpers;

namespace Recore.Service.Interfaces;

public interface IEmailService
{
    ValueTask SendEmailAsync(MailRequest request);
}
