using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace PTP.DAL.Domains.Mappings;

public class CurrencyMapping : ClassMapping<Currency>
{
    public CurrencyMapping()
    {
        Table("Currency");
        
        Id(x => x.Id, m =>
        {
            m.Column("Id");
            m.Generator(Generators.Native);
        });

        Property(x => x.Name, m => m.Length(100));
        Property(x => x.Symbol, m => m.Length(5));
        
        OptimisticLock(OptimisticLockMode.Version);
        Version(x => x.Version, m =>   {
            m.Column("Version");
            m.Generated(VersionGeneration.Always);
            m.UnsavedValue(0);
        });
    }
}