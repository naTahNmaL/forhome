using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace PTP.DAL.Domains.Mappings;

public class PlaceMapping : ClassMapping<Place>
{
    public PlaceMapping()
    {
        Table("Place");
        
        Id(x => x.Id, m =>
        {
            m.Column("Id");
            m.Generator(Generators.Native);
        });

        Property(x => x.Name, m => m.Length(255));
        
        OptimisticLock(OptimisticLockMode.Version);
        Version(x => x.Version, m =>   {
            m.Column("Version");
            m.Generated(VersionGeneration.Always);
            m.UnsavedValue(0);
        });
        
        ManyToOne(x => x.Country, m => m.Column("CountryId"));
    }
}