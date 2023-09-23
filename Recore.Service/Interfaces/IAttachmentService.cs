using Recore.Service.DTOs.Attachments;
using Recore.Domain.Entities.Attachments;

namespace Recore.Service.Interfaces;

public interface IAttachmentService
{
    ValueTask<Attachment> UploadAsync(AttachmentCreationDto dto);
    ValueTask<bool> RemoveAsync(Attachment attachment);
}
