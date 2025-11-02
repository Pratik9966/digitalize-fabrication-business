using DigitalizeFabricationBussiness.Models;
using HotChocolate.Types;

namespace DigitalizeFabricationBussiness.GraphQL.Types;

/// <summary>
/// GraphQL Object Type for Product entity
/// Defines the GraphQL schema representation of a Product
/// This type is used for querying product data through GraphQL
/// </summary>
public class ProductType : ObjectType<Product>
{
    /// <summary>
    /// Configures the Product type and its fields for GraphQL schema
    /// </summary>
    /// <param name="descriptor">Type descriptor to configure the Product type</param>
    protected override void Configure(IObjectTypeDescriptor<Product> descriptor)
    {
        // Set the GraphQL type name
        descriptor.Name("Product");

        // Set description for the Product type
        descriptor.Description("Represents a product in the fabrication catalog");

        // Configure ProductId field
        descriptor
            .Field(p => p.ProductId)
            .Description("Unique identifier for the product");

        // Configure ProductName field
        descriptor
            .Field(p => p.ProductName)
            .Description("Name of the product");

        // Configure Description field
        descriptor
            .Field(p => p.Description)
            .Description("Detailed description of the product");

        // Configure Price field
        descriptor
            .Field(p => p.Price)
            .Description("Price of the product in decimal format");

        // Configure Category field (enum)
        descriptor
            .Field(p => p.Category)
            .Description("Category of the product (e.g., LaserCutting, SheetMetal, Welding)");

        // Configure ProductImages field
        descriptor
            .Field(p => p.ProductImages)
            .Description("List of image URLs for the product stored in ImageKit CDN");

        // Configure CreatedAt from BaseEntity
        descriptor
            .Field(p => p.CreatedAt)
            .Description("Timestamp when the product was created");

        // Configure UpdatedAt from BaseEntity
        descriptor
            .Field(p => p.UpdatedAt)
            .Description("Timestamp when the product was last updated");
    }
}
