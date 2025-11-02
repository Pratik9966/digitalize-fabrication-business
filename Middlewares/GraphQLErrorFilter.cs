using DigitalizeFabricationBussiness.Utilities.Exceptions;
using HotChocolate;

namespace DigitalizeFabricationBussiness.Middleware;

/// <summary>
/// Custom error filter for GraphQL errors
/// Provides user-friendly error messages and removes stack traces from responses
/// Handles authentication, authorization, and custom business logic exceptions
/// </summary>
public class GraphQLErrorFilter : IErrorFilter
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public GraphQLErrorFilter(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public IError OnError(IError error)
    {
        // Handle CustomException from business logic
        if (error.Exception is CustomException customException)
        {
            return ErrorBuilder.New()
                .SetMessage(customException.Message)
                .SetExtension("statusCode", (int)customException.StatusCode)
                .SetExtension("errorCode", customException.Code)
                .Build();
        }

        // Handle authentication errors (no token or invalid token)
        if (error.Code == "AUTH_NOT_AUTHENTICATED")
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var hasToken = httpContext != null &&
                          !string.IsNullOrEmpty(httpContext.Request.Headers["Authorization"]);

            var message = hasToken ? "Invalid token" : "Token not found";

            return ErrorBuilder.New()
                .SetMessage(message)
                .SetExtension("statusCode", 401)
                .SetExtension("errorCode", "UNAUTHORIZED")
                .Build();
        }

        // Handle authorization errors (valid token but insufficient permissions)
        if (error.Code == "AUTH_NOT_AUTHORIZED")
        {
            return ErrorBuilder.New()
                .SetMessage("You do not have permission to access this resource")
                .SetExtension("statusCode", 403)
                .SetExtension("errorCode", "FORBIDDEN")
                .Build();
        }

        // Handle other exceptions - remove stack traces in production
        if (error.Exception != null)
        {
            return ErrorBuilder.New()
                .SetMessage(error.Exception.Message)
                .SetExtension("statusCode", 500)
                .SetExtension("errorCode", "ERROR")
                .Build();
        }

        return error;
    }
}
