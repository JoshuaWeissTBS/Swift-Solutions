using Microsoft.AspNetCore.Mvc;
using PopNGo.Models;
using PopNGo.DAL.Abstract;
using PopNGo.DAL.Concrete;
// using PopNGo.Models.DTO;
// using PopNGo.ExtensionMethods;

namespace PopNGo.Controllers;
[ApiController]
[Route("api/[controller]")]
public class EventApiController : Controller
{
    private readonly ILogger<EventApiController> _logger;
    private readonly IConfiguration _configuration;
    private readonly IEventHistoryRepository _eventHistoryRepository;

    public EventApiController(IEventHistoryRepository eventHistoryRepository, ILogger<EventApiController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        _eventHistoryRepository = eventHistoryRepository;
    }

    // GET: api/eventHistory
    [HttpGet("eventHistory")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Models.DTO.EventHistory>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public ActionResult<IEnumerable<Models.DTO.EventHistory>> GetUserEventHistory(int userId)
    {
        List<Models.DTO.EventHistory> events = _eventHistoryRepository.GetEventHistory(userId);
        if (events == null || events.Count == 0)
        {
            return NotFound();
        }

        return events;
    }
}
