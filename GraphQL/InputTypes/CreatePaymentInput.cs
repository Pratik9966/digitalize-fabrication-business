using DigitalizeFabricationBussiness.Utilities.Enumes;

namespace DigitalizeFabricationBussiness.GraphQL.InputTypes;

/// <summary>
/// Input type for creating a new payment record in GraphQL
/// AUTHORIZATION: Admin only (payment records are created by admin after receiving payment)
/// </summary>
public class CreatePaymentInput
{
    /// <summary>
    /// ID of the order this payment is for
    /// Required field
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Payment amount
    /// Must be a positive decimal value
    /// Required field
    /// </summary>
    public decimal Amount { get; set; }

    /// <summary>
    /// Method used for payment
    /// Must be a valid PaymentMethodEnum (CASH, CARD, UPI, BANK_TRANSFER)
    /// Required field
    /// </summary>
    public PaymentMethodEnum PaymentMethod { get; set; }

    /// <summary>
    /// Date and time when payment was received
    /// Required field
    /// </summary>
    public DateTime PaymentDate { get; set; }

    /// <summary>
    /// Reference number or transaction ID from payment gateway
    /// Optional but recommended for non-cash payments
    /// </summary>
    public string? TransactionReference { get; set; }
}
