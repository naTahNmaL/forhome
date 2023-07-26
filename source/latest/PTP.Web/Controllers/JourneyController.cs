using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PTP.BusinessService.Interfaces;
using PTP.BusinessService.Models;


namespace PTP.Web.Controllers;

[ApiController]
[Route("[controller]")]
public class JourneyController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IJourneyServices _journeyServices;

    public JourneyController(IMapper mapper, IJourneyServices journeyServices)
    {
        _mapper = mapper;
        _journeyServices = journeyServices;
    }

    // [HttpGet]
    // public async Task<IActionResult> Get()
    // {
    //     // Use 'await' to get the actual data from the asynchronous method.
    //     var source = await _journeyServices.GetAllAsync();
    //
    //     // Ensure to map the list to your desired DTO before returning the response.
    //     var journeyModels = _mapper.Map<IList<JourneyModel>>(source);
    //
    //     return Ok(journeyModels);
    // }
}