using CommonServiceFacade;
using CommonServiceFacade.Enums;

namespace CommonDAL.Model;

public class SystemUser:ModelBase
{
    public int SysNo { get; set; }

    public String LoginName { get; set; }

    public String LoginPassword { get; set; }

    public string UserFullName { get; set; }

    /// <summary>
    /// 用户状态
    /// </summary>
    public CommonStatus CommonStatus { get; set; }

    /// <summary>
    /// 用户手机
    /// </summary>
    public string CellPhone { get; set; }

    public string Email { get; set; }
}