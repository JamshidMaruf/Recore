using Recore.Domain.Commons;

namespace Recore.Domain.Entities.Attachments;

public class Attachment : Auditable
{
    public string FilePath { get; set; }
    public string FileName { get; set; }
}
