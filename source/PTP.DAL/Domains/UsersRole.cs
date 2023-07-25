namespace PTP.DAL.Domains;

public class UsersRole : BaseEntity
{
    public virtual string RoleName { get; set; }
    public virtual string RoleCode { get; set; }
}