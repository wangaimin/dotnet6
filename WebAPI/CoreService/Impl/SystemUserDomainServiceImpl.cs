using CommonDAL.Impl;
using CommonDAL.Interfaces;
using CommonDAL.Model;
using CoreModel;

namespace CoreService.Impl;

public class SystemUserDomainServiceImpl : ISystemUserDomainService
{
    private readonly IEfCoreSystemUserRepository _systemUserRepository;

    public SystemUserDomainServiceImpl(IEfCoreSystemUserRepository efCoreSystemUserRepository)
    {
        _systemUserRepository = efCoreSystemUserRepository;
    }

    public async Task<int> SaveAsync(SystemUserModel systemUserModel)
    {
        if (systemUserModel.SysNo != 0)
        {
            var systemUser = new SystemUser()
            {
                SysNo = 1,
                LoginPassword = "111",
                InDate = DateTime.Now,
                EditDate = DateTime.Now,
                InUserSysNo = 1,
                InUserName = "Gene",
                LoginName = "Gene",
                Email = "123@qq.com",
                EditUserName = "Gene",
                EditUserSysNo = 0,
                UserFullName = "test",
                CellPhone = "13566666666"
            };
            await _systemUserRepository.UpdateAsync(systemUser);
            return systemUser.SysNo;
        }
        else
        {
            var systemUser = new SystemUser()
            {
                LoginPassword = "111",
                InDate = DateTime.Now,
                EditDate = DateTime.Now,
                InUserSysNo = 1,
                InUserName = "Gene",
                LoginName = "Gene",
                Email = "123@qq.com",
                EditUserName = "Gene",
                EditUserSysNo = 0,
                UserFullName = "test",
                CellPhone = "13566666666"
            };
            return await _systemUserRepository.AddAsync(systemUser);
        }
    }

    public async Task<List<SystemUserModel>> GetAllAsync()
    {
        var systemUsers = await _systemUserRepository.GetAllAsync();
        return systemUsers.Select(systemUser => new SystemUserModel()
        {
            SysNo = systemUser.SysNo, 
            CellPhone = systemUser.CellPhone, 
            CommonStatus = systemUser.CommonStatus,
            LoginName = systemUser.LoginName
        }).ToList();
    }
}