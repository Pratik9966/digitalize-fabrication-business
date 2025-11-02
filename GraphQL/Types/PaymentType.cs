using DigitalizeFabricationBussiness.Models;
using HotChocolate.Types;

namespace DigitalizeFabricationBussiness.GraphQL.Types;

/// <summary>
/// GraphQL Object Type for Payment entity
/// Defines the GraphQL schema representation of a Payment
/// This type is used for querying payment data through GraphQL
/// </summary>
public class PaymentType : ObjectType<Payment>
{
    /// <summary>
    /// Configures the Payment type and its fields for GraphQL schema
    /// </summary>
    /// <param name="descriptor">Type descriptor to configure the Payment type</param>
    protected override void Configure(IObjectTypeDescriptor<Payment> descriptor)
    {
        // Set the GraphQL type name
        descriptor.Name("Payment");

        // Set description for the Payment type
        descriptor.Description("Represents a payment transaction for an order");

        // Configure PaymentId field
        descriptor
            .Field(p => p.PaymentId)
            .Description("Unique identifier for the payment");

        // Configure OrderId field
        descriptor
            .Field(p => p.OrderId)
            .Description("ID of the order this payment is for");

        // Configure Order navigation property
        descriptor
            .Field(p => p.Order)
            .Description("Order associated with this payment");

        // Configure Amount field
        descriptor
            .Field(p => p.Amount)
            .Description("Payment amount in decimal format");

        // Configure PaymentMethod field (enum)
        descriptor
            .Field(p => p.PaymentMethod)
            .Description("Method used for payment (CASH, CARD, UPI, BANK_TRANSFER)");

        // Configure PaymentDate field
        descriptor
            .Field(p => p.PaymentDate)
            .Description("Date and time when the payment was made");

        // Configure PaymentStatus field (enum)
        descriptor
            .Field(p => p.PaymentStatus)
            .Description("Current status of the payment (PENDING, COMPLETED, FAILED, REFUNDED)");

        // Configure TransactionReference field
        descriptor
            .Field(p => p.TransactionReference)
            .Description("Reference number or transaction ID from payment gateway");

        // Configure CreatedAt from BaseEntity
        descriptor
            .Field(p => p.CreatedAt)
            .Description("Timestamp when the payment record was created");

        // Configure UpdatedAt from BaseEntity
        descriptor
            .Field(p => p.UpdatedAt)
            .Description("Timestamp when the payment record was last updated");
    }
}
