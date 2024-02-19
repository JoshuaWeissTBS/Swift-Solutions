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
/*    private readonly ILogger<EventApiController> _logger;
    private readonly IConfiguration _configuration;
    private readonly IEventRepository _eventRepository;

    public EventApiController(IEventRepository eventRepository, ILogger<EventApiController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        _eventRepository = eventRepository;
    }

    // GET: api/orders
    [HttpGet("eventHistory")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Models.DTO.Order>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<Models.DTO.Order>> GetUnfilledOrders()
    {
        List<Models.DTO.Order> orders = _orderRepository.GetUnfilledOrders();
        if (orders == null || !orders.Any())
        {
            return NotFound();
        }

        return orders;
    }*/
}
