using DigitalizeFabricationBussiness.Utilities.Enumes;

namespace DigitalizeFabricationBussiness.GraphQL.InputTypes;

/// <summary>
/// Input type for updating an existing payment record in GraphQL
/// AUTHORIZATION: Admin only
/// </summary>
public class UpdatePaymentInput
{
    /// <summary>
    /// ID of the payment to update
    /// Required field
    /// </summary>
    public string PaymentId { get; set; } = string.Empty;

    /// <summary>
    /// Updated payment amount
    /// Optional - only update if provided
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// Updated payment method
    /// Optional - only update if provided
    /// </summary>
    public PaymentMethodEnum? PaymentMethod { get; set; }

    /// <summary>
    /// Updated payment date
    /// Optional - only update if provided
    /// </summary>
    public DateTime? PaymentDate { get; set; }

    /// <summary>
    /// Updated payment status
    /// Must be a valid PaymentStatusEnum (PENDING, COMPLETED, FAILED, REFUNDED)
    /// Optional - only update if provided
    /// </summary>
    public PaymentStatusEnum? PaymentStatus { get; set; }

    /// <summary>
    /// Updated transaction reference
    /// Optional - only update if provided
    /// </summary>
    public string? TransactionReference { get; set; }
}
