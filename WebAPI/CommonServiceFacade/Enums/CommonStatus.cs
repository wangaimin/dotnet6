using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CommonServiceFacade.Enums;

public enum CommonStatus : int
{
    [Description("无效")]
    DeActived = 0,
    [Description("有效")]
    Actived = 1,
    [Description("已删除")]
    Deleted = -999
}