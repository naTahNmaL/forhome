using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ninject;
using PTP.BusinessService.DTO;
using PTP.BusinessService.Interfaces;
using PTP.BusinessService.Models;
using PTP.BusinessService.Services;
using PTP.DAL.Domains;

namespace PTP.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class UserInfoController : ControllerBase
{
    private readonly IUserInfoServices _userInfoServices;
    private readonly IMapper _mapper;

    public UserInfoController(IUserInfoServices userInfoService, IMapper mapper )
    {
        _userInfoServices = userInfoService;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        var source = await _userInfoServices.GetByIdAsync(id);

        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            MaxDepth = 64 // or any value that fits your object graph
        };
        return Content(JsonSerializer.Serialize(source, options), "application/json");
    }

}