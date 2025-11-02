using DigitalizeFabricationBussiness.Models;
using HotChocolate.Types;

namespace DigitalizeFabricationBussiness.GraphQL.Types;

/// <summary>
/// GraphQL Object Type for Quotation entity
/// Defines the GraphQL schema representation of a Quotation
/// This type is used for querying quotation data through GraphQL
/// </summary>
public class QuotationType : ObjectType<Quotation>
{
    /// <summary>
    /// Configures the Quotation type and its fields for GraphQL schema
    /// </summary>
    /// <param name="descriptor">Type descriptor to configure the Quotation type</param>
    protected override void Configure(IObjectTypeDescriptor<Quotation> descriptor)
    {
        // Set the GraphQL type name
        descriptor.Name("Quotation");

        // Set description for the Quotation type
        descriptor.Description("Represents a price quotation for a customer order");

        // Configure QuotationId field
        descriptor
            .Field(q => q.QuotationId)
            .Description("Unique identifier for the quotation");
        

        // Configure OrderId field
        descriptor
            .Field(q => q.Order)
            .Description("ID of the associated order");

        // Configure Order navigation property
        descriptor
            .Field(q => q.Order)
            .Description("Order associated with this quotation");

        // Configure ProductDetails field
        descriptor
            .Field(q => q.QuotationDetails)
            .Description("Detailed description of products/services in the quotation");

        // Configure TotalAmount field
        descriptor
            .Field(q => q.TotalAmount)
            .Description("Total amount quoted for the order");
        

        // Configure Status field (enum)
        descriptor
            .Field(q => q.Status)
            .Description("Current status of the quotation (PENDING, ACCEPTED, REJECTED, EXPIRED)");

        // Configure QuotationFiles field
        descriptor
            .Field(q => q.QuotationFiles)
            .Description("List of file URLs attached to the quotation");

        // Configure CreatedAt from BaseEntity
        descriptor
            .Field(q => q.CreatedAt)
            .Description("Timestamp when the quotation was created");

        // Configure UpdatedAt from BaseEntity
        descriptor
            .Field(q => q.UpdatedAt)
            .Description("Timestamp when the quotation was last updated");
    }
}
