using PTP.BusinessService.Models;

namespace PTP.BusinessService.Interfaces;

public interface IPlaceServices
{
    Task<IList<PlaceModel>> GetAllAsync();
}