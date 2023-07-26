namespace PTP.DAL.Domains;

public class UserInfo : BaseEntity
{
    public virtual string UserName { get; set; }
    public virtual string Password { get; set; }
    public virtual string Name { get; set; }
    public virtual string Email { get; set; }
    public virtual UserAvatar Avatar { get; set; }
    public virtual IList<Journey> Journeys { get; set; } = new List<Journey>();
    public virtual IList<UsersRole> Roles { get; set; } = new List<UsersRole>();
}