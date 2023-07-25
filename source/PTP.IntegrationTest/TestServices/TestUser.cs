using System.Transactions;
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

namespace PTP.IntegrationTest.TestServices;

//
// [TestFixture]
// public class TestUser
// {
//     private KernelBase _kernelBase;
//     private IUserInfoServices _userInfoServices;
//  
//     [OneTimeSetUp]
//     public void SetupOnce()
//     {
//         _kernelBase = new StandardKernel(new ServicesBinding());
//         _userInfoServices = _kernelBase.Get<IUserInfoServices>();
//     }
//     
//     
//
//     // [Test]
//     // public async Task Test_GetAllAsync()
//     // {
//     //     // Arrange
//     //     using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
//     //     {
//     //         // Act
//     //         var result = await _userInfoServices.GetAllAsync();
//     //
//     //         // Assert
//     //         Assert.IsNotNull(result);
//     //     }
//     // }
//     
// }
// public class ServicesBinding : NinjectModule
// {
//    
//     public override void Load()
//     {
//         // Bind NHibernate's ISessionFactory to the configured session factory.
//         Bind<ISessionFactory>().ToMethod(ctx => NHibernateConfig.SessionFactory).InSingletonScope();
//
//         // Bind IUnitOfWork to UnitOfWork with InRequestScope.
//         Bind<IUnitOfWork>().To<UnitOfWork>().InSingletonScope();
//
//         // Bind AutoMapper's IMapper to the configured mapper instance in SingletonScope.
//         Bind<IMapper>().ToMethod(ctx => MapperBinding.Configure()).InSingletonScope();
//
//         Bind<IUserInfoRepository>().To<UserInfoRepository>().InSingletonScope();
//         
//         Bind<IUserInfoServices>().To<UserInfoService>().InSingletonScope();
//     }
// }