namespace Recore.Domain.Configurations;

public class PaginationMetaData<T>
{
    public T Data { get; set; }
    public int TotalItems { get; set; }
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
}
