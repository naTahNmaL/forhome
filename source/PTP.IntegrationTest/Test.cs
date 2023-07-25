using Ninject;
using PTP.BusinessService.DIConfig;
using PTP.BusinessService.Interfaces;

namespace PTP.IntegrationTest;

[TestFixture]
public class Test
{
    private static IKernel _kernel = new StandardKernel(new ServicesBinding());
    private readonly IUserInfoServices _userInfoServices = _kernel.Get<IUserInfoServices>();

    [Test]
    public async Task TestNinject()
    {
        var result = await _userInfoServices.GetByIdAsync(1);
        Assert.IsNotNull(result);
    }
}
