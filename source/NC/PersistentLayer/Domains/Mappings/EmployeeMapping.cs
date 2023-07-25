using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace PersistentLayer.Domains.Mappings
{
    public class EmployeeMapping : ClassMapping<Employee>
    {
        public EmployeeMapping()
        {
            Table("Employee");

            Id(x => x.Id, map =>
            {
                map.Column("ID");
                map.Generator(Generators.Identity);
            });

            Property(x => x.Visa, map =>
            {
                map.Column("VISA");
                map.NotNullable(true);
                map.Length(3);
            });

            Property(x => x.FirstName, map =>
            {
                map.Column("FIRST_NAME");
                map.NotNullable(true);
            });

            Property(x => x.LastName, map =>
            {
                map.Column("LAST_NAME");
                map.NotNullable(true);
            });

            Property(x => x.BirthDate, map =>
            {
                map.Column("BIRTH_DATE");
                map.NotNullable(true);
            });

            OptimisticLock(OptimisticLockMode.Version);
            Version(b => b.Version, x =>
            {
                x.Generated(VersionGeneration.Never);
                x.Type(NHibernateUtil.Int32);
                x.UnsavedValue(1);
            });

            Bag(x => x.Projects, map =>
            {
                map.Table("ProjectEmployee");
                map.Key(k => k.Column("EMPLOYEE_ID"));
                map.Inverse(true);
                map.Lazy(CollectionLazy.Lazy);
            },
            relation => relation.ManyToMany(m => m.Column("PROJECT_ID")));
        }
    }
}
