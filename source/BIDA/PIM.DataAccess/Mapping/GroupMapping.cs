using FluentNHibernate.Mapping;
using PIM.DataAccess.Entity;
namespace PIM.DataAccess.Mapping
{
    public class GroupMapping : ClassMap<Group>
    {
        public GroupMapping()
        {
            Id(x => x.Id).GeneratedBy.Guid().Column("ID").Not.Nullable();
            Version(x => x.Version).Column("VERSION").Not.Nullable();
            OptimisticLock.Version();
            Map(x => x.Name).Column("NAME").Not.Nullable().Length(50);
            References<Employee>(x => x.GroupLeader).Nullable().Column("GROUP_LEADER_ID");
            HasMany<Project>(x => x.ProjectList).Inverse().Cascade.AllDeleteOrphan();
        }
    }
}
