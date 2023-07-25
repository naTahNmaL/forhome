using PTP.BusinessService.Interfaces;
using PTP.BusinessService.Models;
using PTP.DAL.Interfaces;

namespace PTP.BusinessService.Services;

public class DefaultDataService : IDefaultDataService
{
    private readonly ICountryServices _countryService;
    private readonly ICurrencyServices _currencyService;
    public DefaultDataService(ICountryServices countryService, ICurrencyServices currencyService)
    {
        _countryService = countryService;
        _currencyService = currencyService;
    }
    
    public async Task<DefaultDataModel> LoadDefaultData()
    {
        var defaultData = new DefaultDataModel();
        defaultData.Countries = await _countryService.GetAllAsync();
        defaultData.Currencies = await _currencyService.GetAllAsync();
        return defaultData;
    }
}