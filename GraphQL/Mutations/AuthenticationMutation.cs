using DigitalizeFabricationBussiness.GraphQL.InputTypes;

namespace DigitalizedFabricationBusiness.GraphQL.Mutations;

[ExtendObjectType("Mutation")]
public class AuthenticationMutation
{

    public string MutationTest()
    {
        return "Test";
    }
//     public async Task<LoginResponse> Login(
//         LoginInput input,
//         [Service] IUserService userService)
//     {
//         // Validate input
//         if (string.IsNullOrWhiteSpace(input.UserName))
//         {
//             throw new ArgumentException("Username is required", nameof(input.UserName));
//         }
//
//         if (string.IsNullOrWhiteSpace(input.Password))
//         {
//             throw new ArgumentException("Password is required", nameof(input.Password));
//         }
//
//         // Map GraphQL input to DTO
//         // Note: LoginInputDTO uses primary constructor with Username (not UserName)
//         var loginInputDto = new LoginInputDTO(input.UserName, input.Password);
//
//         // Authenticate user through service layer
//         // Service will verify password and generate JWT token
//         var loginOutput = await userService.Login(loginInputDto);
//
//         return new LoginResponse
//         {
//             Message = loginOutput.Message,
//             Status = loginOutput.Status,
//             Data = loginOutput.Data
//         };
//     }
}