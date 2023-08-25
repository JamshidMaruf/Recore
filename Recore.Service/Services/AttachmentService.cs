using Recore.Service.Helpers;
using Recore.Data.IRepositories;
using Recore.Service.Extensions;
using Recore.Service.Interfaces;
using Recore.Service.DTOs.Attachments;
using Recore.Domain.Entities.Attachments;
using Recore.Service.Exceptions;

namespace Recore.Service.Services;

public class AttachmentService : IAttachmentService
{
    private readonly IRepository<Attachment> repository;
    public AttachmentService(IRepository<Attachment> repository)
    {
        this.repository = repository;
    }

    public async Task<Attachment> UploadAsync(AttachmentCreationDto dto)
    {
        var webrootPath = Path.Combine(PathHelper.WebRootPath, "Files");

        if(!Directory.Exists(webrootPath))
            Directory.CreateDirectory(webrootPath);

        var fileExtension = Path.GetExtension(dto.FormFile.FileName);
        var fileName = $"{Guid.NewGuid().ToString("N")}{fileExtension}";
        var fullPath = Path.Combine(webrootPath, fileName);

        var fileStream = new FileStream(fullPath, FileMode.OpenOrCreate);
        await fileStream.WriteAsync(dto.FormFile.ToByte());

        var createdAttachment = new Attachment
        {
            FileName = fileName,
            FIlePath = fullPath
        };
        await this.repository.CreateAsync(createdAttachment);
        await this.repository.SaveAsync();

        return createdAttachment;
    }

    public async Task<bool> RemoveAsync(Attachment attachment)
    {
        this.repository.Delete(attachment);
        await this.repository.SaveAsync();
        return true;
    }
}
