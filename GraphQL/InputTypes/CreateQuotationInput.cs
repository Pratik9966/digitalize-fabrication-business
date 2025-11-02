namespace DigitalizeFabricationBussiness.GraphQL.InputTypes;

/// <summary>
/// Input type for creating a new quotation in GraphQL
/// AUTHORIZATION: Typically created by Admin for customer orders
/// </summary>
public class CreateQuotationInput
{
    /// <summary>
    /// Username of the customer requesting the quotation
    /// Used to link quotation to customer
    /// Required field
    /// </summary>
    public string CustomerUserName { get; set; } = string.Empty;

    /// <summary>
    /// ID of the order this quotation is for
    /// Required field
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Detailed description of products/services being quoted
    /// Should include specifications, quantities, materials
    /// Required field
    /// </summary>
    public string ProductDetails { get; set; } = string.Empty;

    /// <summary>
    /// Total amount quoted for the order
    /// Must be a positive decimal value
    /// Required field
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Date until which the quotation is valid
    /// Must be a future date
    /// Required field
    /// </summary>
    public DateTime ValidUntil { get; set; }

    /// <summary>
    /// List of file URLs attached to the quotation
    /// Can include PDFs, images, technical drawings
    /// Optional during creation
    /// </summary>
    public List<string>? QuotationFiles { get; set; }
}
