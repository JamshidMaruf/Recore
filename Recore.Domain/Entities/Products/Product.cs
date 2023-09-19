using Recore.Domain.Commons;
using Recore.Domain.Entities.Attachments;
using Recore.Domain.Enums;

namespace Recore.Domain.Entities.Products;

public class Product : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }

    public long CategoryId { get; set; }
    public ProductCategory Category { get; set; }

    public long? AttachmentId { get; set; }
    public Attachment Attachment { get; set; }
}
