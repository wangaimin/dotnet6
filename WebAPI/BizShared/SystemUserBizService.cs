using biz_shared.Request;
using CoreModel;

namespace biz_shared;

public interface ISystemUserBizService
{
    Task<int> SaveAsync(SystemUserRequest systemUserRequest);
    Task<List<SystemUserModel>> GetAllAsync();
}