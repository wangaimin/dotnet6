using CommonDAL.Context;
using CommonDAL.Interfaces;
using CommonDAL.Model;
using Microsoft.EntityFrameworkCore;

namespace CommonDAL.Impl;

public class EfCoreSystemUserRepository : IEfCoreSystemUserRepository
{

    private readonly AuthCenterContext context;  

    public EfCoreSystemUserRepository(AuthCenterContext authCenterContext)
    {
        context = authCenterContext;
    }

    public async Task<int> AddAsync(SystemUser systemUser)
    {
        context.SystemUser.Add(systemUser);
        return await context.SaveChangesAsync();
    }

    public async Task<bool> UpdateAsync(SystemUser systemUser)
    {
        context.SystemUser.Update(systemUser);
        return await context.SaveChangesAsync()>0;
    }

    public async Task<List<SystemUser>> GetAllAsync()
    {
        return await context.SystemUser.OrderByDescending(m => m.SysNo).Take(10).ToListAsync();
    }
}