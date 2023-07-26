using PTP.BusinessService.Models;

namespace PTP.BusinessService.Interfaces;

public interface IJourneyServices
{
    Task<JourneyModel> GetAllJourneyByUserId(int id);
    // Task CreateAsync(JourneyModel journey);
    // Task UpdateAsync(JourneyModel journey);
    // Task DeleteAsync(int id);
}