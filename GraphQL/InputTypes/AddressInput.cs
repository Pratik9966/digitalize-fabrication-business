namespace DigitalizeFabricationBussiness.GraphQL.InputTypes;

/// <summary>
/// Input type for address information in GraphQL
/// Used when creating or updating user addresses
/// </summary>
public class AddressInput
{
    /// <summary>
    /// Town or locality name
    /// </summary>
    public string? Town { get; set; }

    /// <summary>
    /// District name
    /// </summary>
    public string? District { get; set; }

    /// <summary>
    /// County or state name
    /// Required field
    /// </summary>
    public string County { get; set; } = string.Empty;

    /// <summary>
    /// Postal code or PIN code
    /// Required field with maximum 10 characters
    /// </summary>
    public string PinCode { get; set; } = string.Empty;
}
