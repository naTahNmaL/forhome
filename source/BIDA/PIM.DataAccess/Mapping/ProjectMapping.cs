using FluentNHibernate.Mapping;
using PIM.DataAccess.Entity;
namespace PIM.DataAccess.Mapping
{
    public class ProjectMapping: ClassMap<Project>
    {
        public ProjectMapping()
        {
            Id(x => x.Id).GeneratedBy.Guid().Column("ID").Not.Nullable();
            Version(x => x.Version).Column("VERSION").Not.Nullable();
            OptimisticLock.Version();
            Map(x => x.ProjectNumber).Column("PROJECT_NUMBER").Not.Nullable().Length(4).Unique();
            Map(x => x.Name).Column("NAME").Not.Nullable().Length(50);
            Map(x => x.Customer).Column("CUSTOMER").Not.Nullable().Length(50);
            Map(x => x.Status).Column("STATUS").Not.Nullable().Length(3);
            Map(x => x.StartDate).Column("START_DATE").Not.Nullable();
            Map(x => x.EndDate).Column("END_DATE").Nullable();
            HasManyToMany(x => x.EmployeeList).Table("PROJECT_EMPLOYEE").Cascade.None(); 
            References(x => x.Group, "GROUP_ID").Class<Group>();
        }
    }
}
