using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PTP.BusinessService.DTO;
using PTP.BusinessService.Interfaces;

namespace PTP.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class authController : ControllerBase
{   
    private readonly IAuthServices _authServices;
    private readonly IMapper _mapper;

    public authController(IAuthServices authServices, IMapper mapper )
    {
        _authServices = authServices;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserLoginRequestDTO user)
    {
        var check = await _authServices.Login(user);
        if (check != -1)
        {
            return Ok(new { success = true, message = "Login success", username= user.UserName, id = check});
        }
        else  
            return Ok(new { success = false, message = "Wrong Username or Password", username= user.UserName });

    }
}