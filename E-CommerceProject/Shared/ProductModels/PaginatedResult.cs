namespace Shared.ProductModels
{
    public record PaginatedResult<TData>(int PageIndex, int PageSize, int TotalCount, IEnumerable<TData> Data);
}
