using AutoMapper;
using NHibernate;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Common;
using PTP.BusinessService.Binding;
using PTP.BusinessService.Interfaces;
using PTP.BusinessService.Services;
using PTP.DAL.Config;
using PTP.DAL.Interfaces;
using PTP.DAL.Repositories;
using PTP.DAL.UnitOfWork;


namespace PTP.BusinessService.DIConfig;

public class ServicesBinding : NinjectModule
{
    public override void Load()
    {
        // Bind NHibernate's ISessionFactory to the configured session factory.
        //Bind<ISessionFactory>().ToMethod(ctx => NHibernateConfig.SessionFactory).InSingletonScope();
        Bind<ISession>().ToMethod(ctx => ctx.Kernel.Get<ISessionFactory>().OpenSession()).InRequestScope();
        // Bind IUnitOfWork to UnitOfWork with InRequestScope.
        Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();

        // Bind AutoMapper's IMapper to the configured mapper instance in SingletonScope.
        //Bind<IMapper>().ToMethod(ctx => MapperBinding.Configure()).InSingletonScope();
        //
        // Bind<IPlaceRepository>().To<PlaceRepository>().InRequestScope();
        // Bind<ICurrencyRepository>().To<CurrencyRepository>().InRequestScope();
        // Bind<ICountryRepository>().To<CountryRepository>().InRequestScope();
        // Bind<IUserAvatarRepository>().To<UserAvatarRepository>().InRequestScope();
        // Bind<IUsersRoleRepository>().To<UsersRoleRepository>();
        // Bind<IJourneyRepository>().To<JourneyRepository>().InRequestScope();

        Bind<IUserInfoRepository>().To<UserInfoRepository>();

        Bind<IUserInfoServices>().To<UserInfoService>().InRequestScope();
        // Bind<IUsersRoleServices>().To<UsersRoleService>().InRequestScope();
        //Bind<IUserAvatarServices>().To<UserAvatarServices>().InRequestScope();
        // Bind<IPlaceServices>().To<PlaceServices>();
        // Bind<ICurrencyServices>().To<CurrencyServices>();
        // Bind<ICountryServices>().To<CountryServices>().InRequestScope();
        // Bind<IJourneyServices>().To<JourneyServices>().InRequestScope();
        // Bind<IDefaultDataService>().To<DefaultDataService>().InRequestScope();
    }
}