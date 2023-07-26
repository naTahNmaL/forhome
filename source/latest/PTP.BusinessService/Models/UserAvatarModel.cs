using PTP.DAL.Domains;

namespace PTP.BusinessService.Models;

public class UserAvatarModel
{
    public virtual int Id { get; set; }
    public virtual byte[]? Avatar { get; set; }
    public virtual UserInfo User { get; set; }
}