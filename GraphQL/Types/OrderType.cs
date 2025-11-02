using DigitalizeFabricationBussiness.Models;
using HotChocolate.Types;

namespace DigitalizeFabricationBussiness.GraphQL.Types;

/// <summary>
/// GraphQL Object Type for Order entity
/// Defines the GraphQL schema representation of an Order
/// This type is used for querying order data through GraphQL
/// </summary>
public class OrderType : ObjectType<Order>
{
    /// <summary>
    /// Configures the Order type and its fields for GraphQL schema
    /// </summary>
    /// <param name="descriptor">Type descriptor to configure the Order type</param>
    protected override void Configure(IObjectTypeDescriptor<Order> descriptor)
    {
        // Set the GraphQL type name
        descriptor.Name("Order");

        // Set description for the Order type
        descriptor.Description("Represents a customer order in the fabrication business");

        // Configure OrderId field
        descriptor
            .Field(o => o.OrderId)
            .Description("Unique identifier for the order (Format: ORD-{timestamp}-{guid})");

        // Configure OrderDescription field
        descriptor
            .Field(o => o.OrderDescription)
            .Description("Detailed description of the order requirements");

        // Configure OrderImages field
        descriptor
            .Field(o => o.OrderImages)
            .Description("List of image URLs related to the order");

        // Configure OrderInternalNotes field
        descriptor
            .Field(o => o.OrderInternalNotes)
            .Description("Internal notes for staff use (Admin only)");

        // Configure Customer navigation property
        descriptor
            .Field(o => o.User)
            .Description("Customer who placed the order");

        // Configure OrderStatus field (enum)
        descriptor
            .Field(o => o.OrderStatus)
            .Description("Current status of the order (PENDING, IN_PROGRESS, COMPLETED, REJECTED)");

        // Configure CreatedAt from BaseEntity
        descriptor
            .Field(o => o.CreatedAt)
            .Description("Timestamp when the order was created");

        // Configure UpdatedAt from BaseEntity
        descriptor
            .Field(o => o.UpdatedAt)
            .Description("Timestamp when the order was last updated");
    }
}
