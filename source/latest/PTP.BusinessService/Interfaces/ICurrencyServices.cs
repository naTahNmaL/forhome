using PTP.BusinessService.Models;

namespace PTP.BusinessService.Interfaces;

public interface ICurrencyServices
{
    Task<IList<CurrencyModel>> GetAllAsync();
}