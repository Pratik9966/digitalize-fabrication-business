using DigitalizeFabricationBussiness.Utilities.Enumes;

namespace DigitalizeFabricationBussiness.GraphQL.InputTypes;

/// <summary>
/// Input type for updating an existing product in GraphQL
/// All fields are optional - only provided fields will be updated
/// AUTHORIZATION: Admin only
/// </summary>
public class UpdateProductInput
{
    /// <summary>
    /// ID of the product to update
    /// Required field
    /// </summary>
    public string ProductId { get; set; } = string.Empty;

    /// <summary>
    /// Updated name of the product
    /// Optional - only update if provided
    /// </summary>
    public string? ProductName { get; set; }

    /// <summary>
    /// Updated description of the product
    /// Optional - only update if provided
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Updated price of the product
    /// Optional - only update if provided
    /// </summary>
    public decimal? Price { get; set; }

    /// <summary>
    /// Updated category of the product
    /// Optional - only update if provided
    /// </summary>
    public CategoryEnum? Category { get; set; }

    /// <summary>
    /// Updated list of image URLs
    /// Optional - only update if provided
    /// Replaces existing images completely
    /// </summary>
    public List<string>? ProductImages { get; set; }
}
