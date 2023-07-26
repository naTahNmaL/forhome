using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;

namespace PTP.DAL.Domains.Mappings;

public class UserAvatarMapping : ClassMapping<UserAvatar>
{
    public UserAvatarMapping()
    {
        Table("UserAvatar");
        Id(x => x.Id, m =>
        {
            m.Column("Id");
            m.Generator(Generators.Native);
        });

        Property(x => x.Avatar, m =>
        {
            m.Type<BinaryBlobType>();
            m.Column(c => c.SqlType("varbinary(max)"));
        });
        
        OptimisticLock(OptimisticLockMode.Version);
        Version(x => x.Version, m =>   {
            m.Column("Version");
            m.Generated(VersionGeneration.Always);
            m.UnsavedValue(0);
        });
    }
}