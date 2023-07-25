using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace PersistentLayer.Domains.Mappings
{
    public class GroupMapping : ClassMapping<Group>
    {
        public GroupMapping()
        {
            Table("Group");

            Id(x => x.Id, map =>
            {
                map.Column("ID");
                map.Generator(Generators.Identity);
            });

            Property(x => x.GroupName, map =>
            {
                map.Column("GROUP_NAME");
                map.NotNullable(true);
            });


            ManyToOne(x => x.Leader, map =>
            {
                map.Column("GROUP_LEADER_ID");
                map.NotNullable(false);
                map.Cascade(Cascade.None);
            });
            OptimisticLock(OptimisticLockMode.Version);
            Version(b => b.Version, x =>
            {
                x.Generated(VersionGeneration.Never);
                x.Type(NHibernateUtil.Int32);
                x.Column("VERSION");
            });

            Bag(x => x.Projects, map =>
            {
                map.Key(k => k.Column("GROUP_ID"));
                map.Cascade(Cascade.All);
                map.Inverse(true);
                map.Lazy(CollectionLazy.Lazy);
            }, rel => rel.OneToMany(x => x.Class(typeof(Project))));

            Version(p => p.Version, mapper => mapper.Generated(VersionGeneration.Never));
            OptimisticLock(OptimisticLockMode.Version);
        }
    }

}
