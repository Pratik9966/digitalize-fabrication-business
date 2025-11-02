using DigitalizeFabricationBussiness.Utilities.Enumes;

namespace DigitalizeFabricationBussiness.GraphQL.InputTypes;

/// <summary>
/// Input type for creating a new product in GraphQL
/// Contains all necessary fields for product creation
/// AUTHORIZATION: Admin only
/// </summary>
public class CreateProductInput
{
    /// <summary>
    /// Name of the product
    /// Required field
    /// </summary>
    public string ProductName { get; set; } = string.Empty;

    /// <summary>
    /// Detailed description of the product
    /// Supports rich text or markdown
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Price of the product
    /// Must be a positive decimal value
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Category of the product
    /// Must be a valid CategoryEnum value (LaserCutting, SheetMetal, etc.)
    /// </summary>
    public CategoryEnum Category { get; set; }

    /// <summary>
    /// List of image URLs for the product
    /// Images should be uploaded to ImageKit CDN first
    /// Optional during creation
    /// </summary>
    public List<string>? ProductImages { get; set; }
}
