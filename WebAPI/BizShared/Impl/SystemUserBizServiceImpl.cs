using biz_shared.Request;
using CoreModel;
using CoreService;
using CoreService.Impl;

namespace biz_shared.Impl;

public class SystemUserBizServiceImpl : ISystemUserBizService
{
    private readonly ISystemUserDomainService _systemUserDomainService;

    public SystemUserBizServiceImpl(ISystemUserDomainService systemUserDomainService)
    {
        _systemUserDomainService = systemUserDomainService;
    }

    public async Task<int> SaveAsync(SystemUserRequest systemUserRequest)
    {
        return await _systemUserDomainService.SaveAsync(new SystemUserModel());
    }

    public async Task<List<SystemUserModel>> GetAllAsync()
    {
        return await _systemUserDomainService.GetAllAsync();
    }
}