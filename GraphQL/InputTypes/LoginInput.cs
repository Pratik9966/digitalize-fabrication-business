namespace DigitalizeFabricationBussiness.GraphQL.InputTypes;

/// <summary>
/// Input type for user login in GraphQL
/// Contains credentials required for authentication
/// </summary>
public class LoginInput
{
    /// <summary>
    /// Username or email for authentication
    /// </summary>
    public string UserName { get; set; } = string.Empty;

    /// <summary>
    /// Password for authentication
    /// SECURITY: Never log or expose this field
    /// </summary>
    public string Password { get; set; } = string.Empty;
}
