namespace Ordering.API.Endpoints.GetOrdersByCustomer;

public record GetOrdersByCustomerResponse(IEnumerable<OrderDto> Orders);
