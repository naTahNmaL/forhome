namespace PTP.DAL.Domains;

public class UserAvatar : BaseEntity 
{
    public virtual byte[]? Avatar { get; set; }
    public virtual UserInfo User { get; set; }
}