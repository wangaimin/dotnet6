using CommonServiceFacade;
using CoreModel;

namespace CoreService;

public interface ISystemUserDomainService
{
    /*
     * 保存
     */
    Task<int> SaveAsync(SystemUserModel systemUserModel);
    Task<List<SystemUserModel>> GetAllAsync();

}