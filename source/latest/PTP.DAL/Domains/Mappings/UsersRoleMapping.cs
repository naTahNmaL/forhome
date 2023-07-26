using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace PTP.DAL.Domains.Mappings;

public class UsersRoleMapping: ClassMapping<UsersRole>
{
    public UsersRoleMapping()
    {
        Table("UsersRole");
        Id(x => x.Id, m =>
        {
            m.Column("Id");
            m.Generator(Generators.Native);
        });

        Property(x => x.RoleName, map => map.Length(255));
        Property(x => x.RoleCode);
        
        Version(x => x.Version, m =>   {
            m.Column("Version");
            m.Generated(VersionGeneration.Always);
            m.UnsavedValue(0);
        });
    }
}