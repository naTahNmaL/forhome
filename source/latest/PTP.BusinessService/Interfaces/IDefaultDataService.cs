using PTP.BusinessService.Models;

namespace PTP.BusinessService.Interfaces;

public interface IDefaultDataService
{
    Task<DefaultDataModel> LoadDefaultData();
}