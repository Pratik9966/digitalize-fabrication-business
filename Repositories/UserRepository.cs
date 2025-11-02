// using System.Data;
using System.Net;
using DigitalizeFabricationBussiness.ApplicationDBContext;
using DigitalizeFabricationBussiness.Models;
using DigitalizeFabricationBussiness.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace DigitalizeFabricationBussiness.Repositories;

public class UserRepository(IDbContextFactory<DigitalizeFabricationBusinessDBContext> contextFactory)
    : IUserRepository
{
    public async Task<User> CreateUser(User user)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetUserByUsername(string username)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.Users
            .Include(u => u.Roles)
            .Include(u => u.Address)
            .FirstOrDefaultAsync(u => u.UserName == username);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        await using var context = await contextFactory.CreateDbContextAsync();
        return await context.Users.FirstOrDefaultAsync(u => u.UserEmail == email);
    }
}
