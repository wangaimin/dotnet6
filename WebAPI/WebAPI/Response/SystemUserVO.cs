using CommonServiceFacade.Enums;
using Microsoft.OpenApi.Extensions;

namespace WebAPI.Response;

public class SystemUserVO
{
    public int SysNo { get; set; }

    public String LoginName { get; set; }


    public string UserFullName { get; set; }

    /// <summary>
    /// 用户状态
    /// </summary>
    public CommonStatus CommonStatus { get; set; }

    public string CommonStatusStr {
        get
        {
            return CommonStatus.GetDisplayName();
        }
    }

    /// <summary>
    /// 用户手机
    /// </summary>
    public string CellPhone { get; set; }

    public string Email { get; set; }
}