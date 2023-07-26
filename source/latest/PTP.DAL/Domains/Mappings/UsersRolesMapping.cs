using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace PTP.DAL.Domains.Mappings;

public class UsersRolesMapping : ClassMapping<UsersRolesMap>
{
    public UsersRolesMapping()
    {
        Table("UsersRolesMapping");
        ManyToOne(x => x.User, m =>
        {
            m.Column("UserId");
            m.Cascade(Cascade.None);
        });
        ManyToOne(x => x.Role, m =>
        {
            m.Column("UserRoleId");
            m.Cascade(Cascade.None);
        });
    }
}