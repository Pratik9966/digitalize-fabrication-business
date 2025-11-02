using DigitalizeFabricationBussiness.ApplicationDBContext;
using DigitalizeFabricationBussiness.Models;
using DigitalizeFabricationBussiness.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DigitalizeFabricationBussiness.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly IDbContextFactory<DigitalizeFabricationBusinessDBContext> _contextFactory;

    public RoleRepository(IDbContextFactory<DigitalizeFabricationBusinessDBContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<Role?> GetRoleByName(string roleName)
    {
        await using var context = await _contextFactory.CreateDbContextAsync();
        return await context.Roles.FirstOrDefaultAsync(role => role.RoleName == roleName);
    }
}
