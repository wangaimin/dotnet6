
using CommonDAL.Interfaces;
using CommonDAL.Model;
using CoreModel;
using Microsoft.Extensions.Options;
namespace CoreService.Impl;

public class SystemUserDomainServiceImpl : ISystemUserDomainService
{
    private readonly IEfCoreSystemUserRepository _systemUserRepository;
    //取结构化的配置信息
    /*
     * 取结构化的配置信息
     * IOptions:配置不会热更新
     * IOptionsSnapshot：配置热更新
     * IOptionsMonitor:配置热更新
     */
    private readonly DefaultSystemUserOption defaultSystemUserOption;

    public SystemUserDomainServiceImpl(IEfCoreSystemUserRepository efCoreSystemUserRepository,IOptions<DefaultSystemUserOption> options)
    {
        _systemUserRepository = efCoreSystemUserRepository;
        defaultSystemUserOption = options.Value;
    }
    #region 热更新配置
    /*
    public SystemUserDomainServiceImpl(IEfCoreSystemUserRepository efCoreSystemUserRepository,IOptionsSnapshot<DefaultSystemUserOption> options)
    {
        _systemUserRepository = efCoreSystemUserRepository;
        defaultSystemUserOption = options.Value;
    }
    public SystemUserDomainServiceImpl(IEfCoreSystemUserRepository efCoreSystemUserRepository,IOptionsMonitor<DefaultSystemUserOption> options)
    {
        _systemUserRepository = efCoreSystemUserRepository;
        defaultSystemUserOption = options.CurrentValue;
    }*/
    #endregion

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
        var systemUserModels= systemUsers.Select(systemUser => new SystemUserModel()
        {
            SysNo = systemUser.SysNo, 
            CellPhone = systemUser.CellPhone, 
            CommonStatus = systemUser.CommonStatus,
            LoginName = systemUser.LoginName
        }).ToList();
        systemUserModels.Add(new SystemUserModel()
        {
             LoginName = defaultSystemUserOption.UserName,
             LoginPassword = defaultSystemUserOption.PassWord
        });
        return systemUserModels;
    }
}