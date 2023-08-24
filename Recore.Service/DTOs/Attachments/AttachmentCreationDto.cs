using Microsoft.AspNetCore.Http;

namespace Recore.Service.DTOs.Attachments;

public class AttachmentCreationDto
{
    public IFormFile FormFile { get; set; }
}