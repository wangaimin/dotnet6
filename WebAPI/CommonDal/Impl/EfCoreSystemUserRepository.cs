using CommonDAL.Context;
using CommonDAL.Interfaces;
using CommonDAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CommonDAL.Impl;

public class EfCoreSystemUserRepository : IEfCoreSystemUserRepository
{

    private readonly AuthCenterContext context;  
    private readonly IConfiguration configuration;
    private readonly ILogger logger;


    public EfCoreSystemUserRepository(IConfiguration configuration, AuthCenterContext context,ILogger<EfCoreSystemUserRepository> logger
    )
    {
        this.configuration = configuration;
        this.context = context;
        this.logger = logger;
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
        var defaultPageSizeStr=configuration["DefaultPageSize"];
        logger.LogInformation(defaultPageSizeStr);
        int.TryParse(defaultPageSizeStr, out int defaultPageSize);
        return await context.SystemUser.OrderByDescending(m => m.SysNo).Take(defaultPageSize).ToListAsync();
    }
}