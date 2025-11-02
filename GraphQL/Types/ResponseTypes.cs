namespace DigitalizeFabricationBussiness.GraphQL.Types;

/// <summary>
/// Base interface for all GraphQL responses
/// </summary>
public interface IGraphQLResponse
{
    bool Status { get; }
    string Message { get; }
}

/// <summary>
/// Standard success response wrapper for GraphQL queries and mutations
/// Provides consistent response structure across all GraphQL operations
/// </summary>
/// <typeparam name="T">Type of data being returned</typeparam>
public class GraphQLSuccessResponse<T> : IGraphQLResponse
{
    public bool Status { get; set; } = true;
    public string Message { get; set; }
    public T Data { get; set; }

    public GraphQLSuccessResponse(string message, T data)
    {
        Message = message;
        Data = data;
    }
}

/// <summary>
/// Standard error response for GraphQL operations
/// Note: In GraphQL, errors are typically returned in the errors array
/// This type is provided for consistency but errors should use GraphQL's error handling
/// </summary>
public class GraphQLErrorResponse : IGraphQLResponse
{
    public bool Status { get; } = false;
    public string Message { get; set; }

    public GraphQLErrorResponse(string message)
    {
        Message = message;
    }
}
