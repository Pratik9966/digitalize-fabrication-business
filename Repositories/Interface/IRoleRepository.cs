
using DigitalizeFabricationBussiness.Models;

namespace DigitalizeFabricationBussiness.Repositories.Interface;

public interface IRoleRepository
{
    Task<Role?> GetRoleByName(string roleName);
}
