namespace DigitalizeFabricationBussiness.GraphQL.InputTypes;

/// <summary>
/// Input type for user registration in GraphQL
/// Contains all necessary fields for creating a new user account
/// </summary>
public class RegisterUserInput
{
    /// <summary>
    /// Phone number of the user
    /// Required for registration
    /// </summary>
    public string UserPhone { get; set; } = string.Empty;

    /// <summary>
    /// Email address of the user
    /// Must be unique in the system
    /// Used for authentication and communication
    /// </summary>
    public string UserEmail { get; set; } = string.Empty;

    /// <summary>
    /// Username for authentication
    /// Must be unique in the system
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// Full name of the user
    /// Display name used throughout the application
    /// </summary>
    public string UserFullName { get; set; } = string.Empty;

    /// <summary>
    /// Password for authentication
    /// Will be hashed before storage
    /// SECURITY: Never log or expose this field
    /// </summary>
    public string UserPassword { get; set; } = string.Empty;

    /// <summary>
    /// Optional address information during registration
    /// </summary>
    public AddressInput? Address { get; set; }
}
