using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

public static class NHibernateHelper
{
    private static ISessionFactory _sessionFactory;

    public static ISessionFactory SessionFactory
    {
        get
        {
            if (_sessionFactory == null)
                AppConfigure();

            return _sessionFactory;
        }
    }

    public static Configuration ConfigureNhibernate(string databaseName)
    {
        var mapper = new ModelMapper();
        mapper.AddMappings(typeof(NHibernateHelper).Assembly.ExportedTypes);
        HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

        var configuration = new Configuration();
        configuration.DataBaseIntegration(c =>
        {
            c.Dialect<MsSql2012Dialect>();
            c.ConnectionString = $"Data Source = (localdb)\\mssqllocaldb; Initial Catalog = {databaseName}";
            c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
            c.SchemaAction = SchemaAutoAction.Validate;
            c.LogFormattedSql = true;
            c.LogSqlInConsole = true;
            c.AutoCommentSql = true;
        });
        configuration.AddMapping(domainMapping);
        return configuration;
    }


    public static void AppConfigure()
    {
        #region NHibernate configuration

        var NHConfiguration = ConfigureNhibernate("PIMP");

        //var schemaExport = new SchemaExport(NHConfiguration);
        //schemaExport.Drop(true, true);
        //schemaExport.Create(true, true);

        _sessionFactory = NHConfiguration.BuildSessionFactory();

        #endregion
    }
}

