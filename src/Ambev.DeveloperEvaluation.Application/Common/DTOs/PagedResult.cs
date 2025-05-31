namespace Ambev.DeveloperEvaluation.Application.Common.DTOs
{
    /// <summary>
    /// Represents a paginated result used within the Application layer.
    /// This type is infrastructure-agnostic and test-friendly.
    /// </summary>
    /// <typeparam name="T">The type of items in the result.</typeparam>
    public sealed class PagedResult<T>
    {
        /// <summary>
        /// The items in the current page.
        /// </summary>
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();

        /// <summary>
        /// The current page number (1-based).
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// The total number of pages.
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// The total number of items available.
        /// </summary>
        public int TotalCount { get; set; }
    }
}
