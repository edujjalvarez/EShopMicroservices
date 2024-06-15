using BuildingBlocks.Pagination;

namespace Ordering.API.Endpoints.GetOrders;

public record GetOrdersResponse(PaginatedResult<OrderDto> Orders);
