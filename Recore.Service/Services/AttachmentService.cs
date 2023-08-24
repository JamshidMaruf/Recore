using AutoMapper;
using Recore.Data.IRepositories;
using Recore.Domain.Entities.Attachments;
using Recore.Service.DTOs.Attachments;
using Recore.Service.Extensions;
using Recore.Service.Helpers;
using Recore.Service.Interfaces;

namespace Recore.Service.Services;

public class AttachmentService : IAttachmentService
{
    private readonly IMapper mapper;
    private readonly IRepository<Attachment> repository;
    public AttachmentService(IRepository<Attachment> repository, IMapper mapper)
    {
        this.repository = repository;
        this.mapper = mapper;
    }

    public async Task<AttachmentResultDto> UploadAsync(AttachmentCreationDto dto)
    {
        var webrootPath = $"{PathHelper.WebRootPath}/Files";

        if(!Directory.Exists(webrootPath))
            Directory.CreateDirectory(webrootPath);

        var fileExtension = Path.GetExtension(dto.FormFile.FileName);
        var fileName = $"{Guid.NewGuid().ToString("N")}{fileExtension}";

        var fileStream = new FileStream(webrootPath, FileMode.Open);
        await fileStream.WriteAsync(dto.FormFile.ToByte());

        var createdAttachment = new Attachment
        {
            FileName = fileName,
            FIlePath = $"{webrootPath}/{fileName}"
        };
        await this.repository.CreateAsync(createdAttachment);

        var mappedAttachemnt = this.mapper.Map<AttachmentResultDto>(createdAttachment);
        return mappedAttachemnt;
    }

    public Task<bool> RemoveAsync(long id)
    {
        throw new NotImplementedException();
    }
}
