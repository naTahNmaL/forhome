using FluentNHibernate.Mapping;
using PIM.DataAccess.Entity;
namespace PIM.DataAccess.Mapping
{
    public class EmployeeMapping : ClassMap<Employee>
    {
        public EmployeeMapping()
        {
            Id(x => x.Id).GeneratedBy.Guid().Column("ID").Nullable();
            Version(x => x.Version).Column("VERSION").Not.Nullable();
            OptimisticLock.Version();
            Map(x => x.FirstName).Column("FIRST_NAME").Not.Nullable().Length(50);
            Map(x => x.Visa).Column("VISA").Not.Nullable().Length(3);
            Map(x => x.LastName).Column("LAST_NAME").Not.Nullable().Length(50);
            Map(x => x.BirthDate).Column("BIRTH_DATE").Not.Nullable();
            HasManyToMany(x => x.ProjectList).Table("PROJECT_EMPLOYEE").Inverse().Cascade.All();  //Owner: inverse=false; Non-owner: inverse=true
            HasOne(x => x.Group).Cascade.AllDeleteOrphan();
        }
    }
}
