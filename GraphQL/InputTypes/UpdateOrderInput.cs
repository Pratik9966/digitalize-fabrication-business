namespace DigitalizeFabricationBussiness.GraphQL.InputTypes;

/// <summary>
/// Input type for updating an existing order in GraphQL
/// AUTHORIZATION: Customer can update their own orders, Admin can update any order
/// </summary>
public class UpdateOrderInput
{
    /// <summary>
    /// ID of the order to update
    /// Required field
    /// </summary>
    public string OrderId { get; set; } = string.Empty;

    /// <summary>
    /// Updated description of the order
    /// Optional - only update if provided
    /// </summary>
    public string? OrderDescription { get; set; }

    /// <summary>
    /// Updated list of order images
    /// Optional - replaces existing images if provided
    /// </summary>
    public List<string>? OrderImages { get; set; }

    /// <summary>
    /// Updated internal notes
    /// Optional - replaces existing notes if provided
    /// </summary>
    public List<string>? OrderInternalNotes { get; set; }
}
