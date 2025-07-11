﻿namespace Ambev.DeveloperEvaluation.Common.Pagination
{
    /// <summary>
    /// Represents a standard API paginated response without duplicating data nesting.
    /// </summary>
    public class PaginatedResponse<T>
    {
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new();
    }
}
