// using System.IdentityModel.Tokens.Jwt;
// using System.Net;
// using System.Text;
// using AutoMapper;
// using DigitalizeFabricationBussiness.ApplicationDBContext;
// using DigitalizeFabricationBussiness.DTO_s;
// using DigitalizeFabricationBussiness.Models;
// using DigitalizeFabricationBussiness.Repositories.Interface;
// using DigitalizeFabricationBussiness.Services.Interface;
// using DigitalizeFabricationBussiness.Utilities.Enumes;
// using DigitalizeFabricationBussiness.Utilities.Exceptions;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.IdentityModel.Tokens;
// using System.Security.Claims;
//
// namespace DigitalizeFabricationBussiness.Services;
//
// public class UserService(
//         IUserRepository _useRepository,
//         IMapper _mapper,
//         DigitalizeFabricationBusinessDBContext _context,
//         IConfiguration _config
//     ): IUserService
// {
//     public async Task<UserDTO> CreateUser(UserDTO user)
//     {
//         UserDTO existingUserByUsername = await GetUserByUserName(user.UserName);
//
//         if (existingUserByUsername != null)
//             throw new CustomException(HttpStatusCode.BadRequest,
//                 "User already exists with given username",
//                 code: ErrorCode.USER_ALREADY_EXISTS);
//
//         UserDTO existingUserByEmail = await GetUserByEmail(user.UserEmail);
//
//         if (existingUserByEmail != null)
//             throw new CustomException(HttpStatusCode.BadRequest,
//                 "User already exists with given email",
//                 code: ErrorCode.USER_ALREADY_EXISTS);
//
//         User userTobeSaved = _mapper.Map<User>(user);
//
//         Role? customerRole = await _context.Roles.FirstOrDefaultAsync(role => role.RoleName == nameof(RolesEnum.CUSTOMER));
//
//         if (customerRole == null)
//             throw new CustomException(HttpStatusCode.BadRequest,
//                 $"{nameof(RolesEnum.CUSTOMER)} role not found",
//                 ErrorCode.GENERAL_ERROR);
//
//         userTobeSaved.Roles = new List<Role>([customerRole]);
//
//         userTobeSaved.UserPassword = new PasswordHasher<object>()
//             .HashPassword(user, userTobeSaved.UserPassword);
//
//         User savedUser = await _useRepository.CreateUser(userTobeSaved);
//         
//         return _mapper.Map<UserDTO>(savedUser);
//         
//     }
//
//     public async Task<UserDTO> GetUserByUserName(string username)
//     {
//         return _mapper.Map<UserDTO>(
//             await _useRepository.GetUserByUsername(username)
//             );
//     }
//     
//     public async Task<UserDTO> GetUserByEmail(string email)
//     {
//
//         return  _mapper.Map<UserDTO>(await _useRepository.GetUserByEmail(email));
//     
//     }
//
//     public async Task<LoginOutputDTO> Login(LoginInputDTO loginInputDto)
//     {
//         UserDTO? existingUser = await GetUserByUserName(loginInputDto.Username);
//
//         if (existingUser is null)
//             throw new CustomException(
//                 HttpStatusCode.NotFound,
//                 "User not found",
//                 ErrorCode.USER_NOT_FOUND);
//         
//         existingUser.Roles.ForEach(role => Console.WriteLine("role:  "+role.RoleName));
//
//         PasswordVerificationResult hasher = new PasswordHasher<object>()
//             .VerifyHashedPassword(existingUser, existingUser.UserPassword, loginInputDto.Password);
//
//         if (hasher == PasswordVerificationResult.Failed)
//             throw new CustomException(
//                 HttpStatusCode.BadRequest, "Wrong Password", ErrorCode.PASSWORD_WRONG);
//
//         JWTDTO jwtdto = _mapper.Map<JWTDTO>(existingUser);
//
//         string token = GenerateJWTToken(jwtdto);
//         
//         return new LoginOutputDTO("Login successful", true, new LoginData(existingUser.UserName, token));
//     }
//
//     private string GenerateJWTToken(JWTDTO jwtDTO)
//     {
//         SymmetricSecurityKey _key = new(
//             Encoding.UTF8.GetBytes(_config["Jwt:Key"]!)
//         );
//         
//         SigningCredentials creds = new(
//             _key,
//             SecurityAlgorithms.HmacSha256
//         );
//         
//         List<Claim> claims = new List<Claim>()
//         {
//         new Claim(ClaimTypes.Name, jwtDTO.Username),
//         new Claim(ClaimTypes.Email, jwtDTO.UserEmail),
//         };
//         
//         // Claim[] claims = new[]
//         // {
//         //     new Claim(ClaimTypes.Name, jwtDTO.Username),
//         //     new Claim(ClaimTypes.Email, jwtDTO.UserEmail),
//         //     new Claim(ClaimTypes.Role, nameof(RolesEnum.CUSTOMER))
//         // };
//
//         jwtDTO.Roles.ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role.RoleName)));
//
//         JwtSecurityToken token = new(
//             issuer: _config["Jwt:Issuer"],
//             audience: _config["Jwt:Audience"],
//             claims: claims.ToArray(),
//             expires: DateTime.UtcNow.AddMinutes(30),
//             signingCredentials: creds
//             );
//
//         return new JwtSecurityTokenHandler().WriteToken(token);
//     }
// }