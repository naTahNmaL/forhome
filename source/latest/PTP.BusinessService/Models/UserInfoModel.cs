using PTP.DAL.Domains;

namespace PTP.BusinessService.Models;

public class UserInfoModel
{
    public virtual int Id { get; set; }
    public virtual string UserName { get; set; }
  
    public virtual string Name { get; set; }
    public virtual string Email { get; set; }
    public virtual UserAvatar Avatar { get; set; }
    public virtual IList<Journey> Journeys { get; set; } = new List<Journey>();
    // public virtual IList<UsersRole> Roles { get; set; } = new List<UsersRole>();
}