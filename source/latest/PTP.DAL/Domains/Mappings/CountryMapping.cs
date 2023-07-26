using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using NHibernate.Type;

namespace PTP.DAL.Domains.Mappings;

public class CountryMapping  : ClassMapping<Country>
{
    public CountryMapping()
    {
        Table("Country");
        
        Id(x => x.Id, m =>
        {
            m.Column("Id");
            m.Generator(Generators.Native);
        });

        Property(x => x.Name, m =>
        {
            m.Column("Name");
            m.Length(255);
        });
        Property(x => x.Code, m =>
        {
            m.Column("Code");
            m.Length(10);
        });
        Property(x => x.Continent, m =>
        {
            m.Column("Continent");
            m.Length(255);
        });
        
        OptimisticLock(OptimisticLockMode.Version);
        Version(x => x.Version, m =>   {
            m.Column("Version");
            m.Generated(VersionGeneration.Always);
            m.UnsavedValue(0);
        });
        
        Bag(x => x.Places, m =>
        {
            m.Key(k => k.Column("CountryId"));
            m.Cascade(Cascade.All | Cascade.DeleteOrphans);
            m.Inverse(true);
            m.Lazy(CollectionLazy.Lazy);
        }, r => r.OneToMany());
    }
}