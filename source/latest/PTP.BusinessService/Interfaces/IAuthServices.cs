using PTP.BusinessService.DTO;

namespace PTP.BusinessService.Interfaces;

public interface IAuthServices
{
    Task<int> Login(UserLoginRequestDTO user);
}