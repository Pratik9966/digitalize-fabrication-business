using DigitalizeFabricationBussiness.Utilities.Enumes;

namespace DigitalizeFabricationBussiness.GraphQL.InputTypes;

/// <summary>
/// Input type for updating an existing quotation in GraphQL
/// AUTHORIZATION: Admin only
/// </summary>
public class UpdateQuotationInput
{
    /// <summary>
    /// ID of the quotation to update
    /// Required field
    /// </summary>
    public string QuotationId { get; set; } = string.Empty;

    /// <summary>
    /// Updated product details
    /// Optional - only update if provided
    /// </summary>
    public string? ProductDetails { get; set; }

    /// <summary>
    /// Updated total amount
    /// Optional - only update if provided
    /// </summary>
    public decimal? TotalAmount { get; set; }

    /// <summary>
    /// Updated validity date
    /// Optional - only update if provided
    /// </summary>
    public DateTime? ValidUntil { get; set; }

    /// <summary>
    /// Updated status of the quotation
    /// Optional - only update if provided
    /// Must be a valid QuotationStatusEnum (PENDING, ACCEPTED, REJECTED, EXPIRED)
    /// </summary>
    public QuotationStatusEnum? Status { get; set; }

    /// <summary>
    /// Updated list of quotation files
    /// Optional - replaces existing files if provided
    /// </summary>
    public List<string>? QuotationFiles { get; set; }
}
