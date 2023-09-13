using Recore.Domain.Entities.Attachments;
using Recore.Service.DTOs.Attachments;

namespace Recore.Service.Interfaces;

public interface IAttachmentService
{
    ValueTask<Attachment> UploadAsync(AttachmentCreationDto dto);
    ValueTask<bool> RemoveAsync(Attachment attachment);
}
