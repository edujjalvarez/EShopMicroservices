namespace Ordering.API.Endpoints.GetOrdersByName;

public record GetOrdersByNameResponse(IEnumerable<OrderDto> Orders);
