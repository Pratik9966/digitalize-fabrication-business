using DigitalizeFabricationBussiness.Utilities.Enumes;

namespace DigitalizeFabricationBussiness.GraphQL.InputTypes;

/// <summary>
/// Input type for updating order status in GraphQL
/// AUTHORIZATION: Admin only
/// </summary>
public class UpdateOrderStatusInput
{
    /// <summary>
    /// ID of the order to update status
    /// Required field
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// New status for the order
    /// Must be a valid OrderStatusEnum value (PENDING, IN_PROGRESS, COMPLETED, REJECTED)
    /// </summary>
    public OrderStatusEnum OrderStatus { get; set; }
}
