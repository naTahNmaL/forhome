using System.Text.Json;
using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PTP.BusinessService.Interfaces;

namespace PTP.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class DefaultDataController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IDefaultDataService _defaultDataService;

    public DefaultDataController(IDefaultDataService defaultDataService, IMapper mapper)
    {
        _mapper = _mapper;
        _defaultDataService = defaultDataService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var source = await _defaultDataService.LoadDefaultData();

        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            MaxDepth = 64 // or any value that fits your object graph
        };

        return Content(JsonSerializer.Serialize(source, options), "application/json");
    }
}