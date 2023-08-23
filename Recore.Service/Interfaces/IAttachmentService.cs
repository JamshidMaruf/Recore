using Recore.Service.DTOs.Attachments;

namespace Recore.Service.Interfaces;

public interface IAttachmentService
{
    Task<AttachmentResultDto> UploadAsync(AttachmentCreationDto dto);
    Task<bool> RemoveAsync(long id);
}
