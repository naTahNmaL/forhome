using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace PersistentLayer.Domains.Mappings
{
    public class ProjectMapping : ClassMapping<Project>
    {
        public ProjectMapping()
        {
            Table("Project");

            Id(x => x.Id, map =>
            {
                map.Column("ID");
                map.Generator(Generators.Identity);
            });
            Property(p => p.ProjectNumber, map =>
            {
                map.Column("PROJECT_NUMBER");
                map.NotNullable(true);
                map.Unique(true);
                map.Column(x => x.SqlType("numeric(4,0)"));
            });
            Property(x => x.Name, map =>
            {
                map.Column("NAME");
                map.NotNullable(true);
            });
            Property(x => x.Customer, map =>
            {
                map.Column("CUSTOMER");
                map.NotNullable(true);
            });
            Property(x => x.Status, map =>
            {
                map.Column("STATUS");
                map.NotNullable(true);
            });
            Property(x => x.StartDate, map =>
            {
                map.Column("START_DATE");
                map.NotNullable(true);
            });
            Property(x => x.EndDate, map =>
            {
                map.Column("END_DATE");
                map.NotNullable(false);
            });

            OptimisticLock(OptimisticLockMode.Version);
            Version(b => b.Version, x =>
            {
                x.Generated(VersionGeneration.Never);
                x.Type(NHibernateUtil.Int32);
                x.Column("VERSION");
            });

            ManyToOne(p => p.Group, mapper =>
            {
                mapper.NotNullable(false);
                mapper.Column("GROUP_ID");
            });

            Bag(x => x.Employees, map =>
            {
                map.Table("ProjectEmployee");
                map.Key(k => k.Column("PROJECT_ID"));
                map.Cascade(Cascade.All);
                map.Inverse(false);
                map.Lazy(CollectionLazy.Lazy);
            },
            relation => relation.ManyToMany(m =>
            {
                m.Column("EMPLOYEE_ID");
            }));

        }
    }
}
