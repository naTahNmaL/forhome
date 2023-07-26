using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using PTP.Common.Constants;
using PTP.DAL.Domains;
using PTP.DAL.Domains.Mappings;
using PTP.DAL.Interfaces;

namespace PTP.DAL.Config;

public class NHibernateConfig : INHibernateConfig
{
    public ISessionFactory SessionFactory { get; }

    public NHibernateConfig()
    {
        SessionFactory = NHibernateConfigurationAndBuild();
    }
    
    private static ISessionFactory NHibernateConfigurationAndBuild()
    {
        var configuration = new Configuration();
        configuration.SessionFactoryName("_sessionFactory");
        configuration.DataBaseIntegration(db =>
        {
            db.ConnectionString = ConnectConstants.ConnectionString;
            db.Dialect<MsSql2012Dialect>();
            db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
            db.LogFormattedSql = true;
            db.LogSqlInConsole = true;
            db.AutoCommentSql = true;
        });
        
        var mapper = new ModelMapper();
        mapper.AddMappings(typeof(NHibernateConfig).Assembly.ExportedTypes);
        HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
        configuration.AddMapping(domainMapping);
        // #region  mapper
        // mapper.AddMapping<CountryMapping>();
        // mapper.AddMapping<CurrencyMapping>();
        // mapper.AddMapping<JourneyMapping>();
        // mapper.AddMapping<PlaceMapping>();
        // mapper.AddMapping<UserAvatarMapping>();
        // mapper.AddMapping<UserInfoMapping>();       
        // mapper.AddMapping<UsersRoleMapping>();
        // mapper.AddMapping<UsersRolesMapping>();
        // #endregion
        
        // var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
        //
        // configuration.AddDeserializedMapping(mapping, "MyEntity");
        return configuration.BuildSessionFactory();
    }
    
}