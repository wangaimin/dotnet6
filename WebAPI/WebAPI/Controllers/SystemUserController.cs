using biz_shared;
using biz_shared.Request;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Response;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class SystemUserController : ControllerBase
{
    private readonly ISystemUserBizService _systemUserBizService;

    public SystemUserController(ISystemUserBizService systemUserBizService)
    {
        _systemUserBizService = systemUserBizService;
    }

    [HttpPost(Name = "保存用户信息")]
    public async Task<int> Save()
    {
        var result= await _systemUserBizService.SaveAsync(new SystemUserRequest());
        return result;
    }
    
    [HttpGet(Name = "查询所有用户信息")]
    public async Task<List<SystemUserVO>> GetAll()
    {
        var systemUserModels= await _systemUserBizService.GetAllAsync();
        return systemUserModels.Select(m=>new SystemUserVO()
        {
            SysNo =m.SysNo,
            LoginName = m.LoginName,
            CellPhone = m.CellPhone,
            CommonStatus = m.CommonStatus
        }).ToList();
    }
}