namespace DigitalizeFabricationBussiness.GraphQL.InputTypes;

/// <summary>
/// Input type for creating a new order in GraphQL
/// Contains all necessary fields for order creation
/// AUTHORIZATION: Customer only (creates order for authenticated user)
/// </summary>
public class CreateOrderInput
{
    /// <summary>
    /// Detailed description of the order requirements
    /// Should include specifications, quantities, materials, etc.
    /// Required field
    /// </summary>
    public string OrderDescription { get; set; } = string.Empty;

    /// <summary>
    /// List of image URLs related to the order
    /// Images can include designs, reference images, technical drawings
    /// Optional during creation
    /// </summary>
    public List<string>? OrderImages { get; set; }

    /// <summary>
    /// Internal notes for staff use
    /// Optional - can be added by customer or admin
    /// </summary>
    public List<string>? OrderInternalNotes { get; set; }
}
