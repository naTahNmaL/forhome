using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace PTP.DAL.Domains.Mappings;

public class JourneyMapping : ClassMapping<Journey>
{
    public JourneyMapping()
    {
        Table("Journey");
        
        Id(x => x.Id, m =>
        {
            m.Column("Id");
            m.Generator(Generators.Native);
        });

        Property(x => x.Name , m => m.Length(255));
        Property(x => x.Description,  m => m.Type(NHibernateUtil.StringClob));
        Property(x => x.StartDate);
        Property(x => x.EndDate);
        Property(x => x.Status, m => m.Length(20));
        Property(x => x.Amount);

        ManyToOne(x => x.User, m => m.Column("UserId"));
        ManyToOne(x => x.Country, m => m.Column("CountryId"));
        ManyToOne(x => x.Place, m => m.Column("PlaceId"));
        ManyToOne(x => x.Currency, m => m.Column("CurrencyId"));
        
        OptimisticLock(OptimisticLockMode.Version);
        Version(x => x.Version, m =>   {
            m.Column("Version");
            m.Generated(VersionGeneration.Always);
            m.UnsavedValue(0);
        });
        
        
    }
}