using PTP.BusinessService.Models;

namespace PTP.BusinessService.Interfaces;

public interface ICountryServices
{
    Task<IList<CountryModel>> GetAllAsync();
    Task<CountryModel> GetByIdAsync(int id);
}