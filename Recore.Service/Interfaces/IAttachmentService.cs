using Recore.Domain.Entities.Attachments;
using Recore.Service.DTOs.Attachments;

namespace Recore.Service.Interfaces;

public interface IAttachmentService
{
    Task<Attachment> UploadAsync(AttachmentCreationDto dto);
    Task<bool> RemoveAsync(Attachment attachment);
}
