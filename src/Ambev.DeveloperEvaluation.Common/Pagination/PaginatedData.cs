namespace Ambev.DeveloperEvaluation.Common.Pagination
{
    /// <summary>
    /// Encapsulates paginated items and pagination metadata.
    /// </summary>
    public class PaginatedData<T>
    {
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
    }
}
