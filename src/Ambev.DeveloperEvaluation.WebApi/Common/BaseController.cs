using Ambev.DeveloperEvaluation.Application.Common.DTOs;
using Ambev.DeveloperEvaluation.Common.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Ambev.DeveloperEvaluation.WebApi.Common;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected int GetCurrentUserId() =>
        int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? throw new NullReferenceException());

    protected string GetCurrentUserEmail() =>
        User.FindFirst(ClaimTypes.Email)?.Value ?? throw new NullReferenceException();

    protected IActionResult Ok<T>(T data) => base.Ok(data);

    protected IActionResult Created<T>(string routeName, object routeValues, T data) =>
        base.CreatedAtRoute(routeName, routeValues, data);

    protected IActionResult BadRequest(string message) =>
        base.BadRequest(new { message });

    protected IActionResult NotFound(string message = "Resource not found") =>
        base.NotFound(new { message });

    /// <summary>
    /// Returns a clean paginated result using legacy PaginatedList
    /// </summary>
    protected IActionResult OkPaginated<T>(PaginatedList<T> pagedList)
    {
        return Ok(new
        {
            sales = pagedList.ToList(),
            pagedList.CurrentPage,
            pagedList.TotalPages,
            pagedList.TotalCount
        });
    }

    /// <summary>
    /// Returns a clean paginated result using Application's PagedResult
    /// </summary>
    protected IActionResult OkPaginated<T>(PagedResult<T> pagedResult)
    {
        return Ok(new
        {
            sales = pagedResult.Items,
            pagedResult.CurrentPage,
            pagedResult.TotalPages,
            pagedResult.TotalCount
        });
    }
}
