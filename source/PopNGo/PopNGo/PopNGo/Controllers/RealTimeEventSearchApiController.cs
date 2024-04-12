using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PopNGo.DAL.Abstract;
using PopNGo.Models;
using PopNGo.Services;

namespace PopNGo.Controllers
{
    [Route("api/")]
    [ApiController]
    public class RealTimeEventSearchApiController : ControllerBase
    {
        private readonly IRealTimeEventSearchService _realTimeEventSearchService;
        private readonly IEventRepository _eventRepository;
        private readonly ILogger<RealTimeEventSearchApiController> _logger;
        public RealTimeEventSearchApiController(IRealTimeEventSearchService realTimeEventSearchService, IEventRepository eventRepository, ILogger<RealTimeEventSearchApiController> logger)
        {
            _realTimeEventSearchService = realTimeEventSearchService;
            _eventRepository = eventRepository;
            _logger = logger;
        }
        // GET: api/search/events/?q=Q&start=0
        [HttpGet("search/events")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<EventDetail>))]
        public async Task<ActionResult<IEnumerable<PopNGo.Models.DTO.Event>>> GetRealTimeAPIEvents(string q, int start)
        {
            try
            {
                IEnumerable<EventDetail> eventsDetails = await _realTimeEventSearchService.SearchEventAsync(q, start);
                // Save events to database
                for (int i = 0; i < eventsDetails.Count(); i++)
                {
                    EventDetail eventDetail = eventsDetails.ElementAt(i);
                    if (!_eventRepository.IsEvent(eventDetail.EventID))
                    {
                        _eventRepository.AddEvent(eventDetail);
                    }
                }

                // Convert EventDetail to EventDTO
                List<PopNGo.Models.DTO.Event> events = new List<PopNGo.Models.DTO.Event>();

                foreach (EventDetail eventDetail in eventsDetails)
                {
                    PopNGo.Models.DTO.Event eventDTO = new PopNGo.Models.DTO.Event
                    {
                        ApiEventID = eventDetail.EventID,
                        EventDate = eventDetail.EventStartTime ?? eventDetail.EventStartTime.Value,
                        EventName = eventDetail.EventName,
                        EventDescription = eventDetail.EventDescription,
                        EventLocation = eventDetail.Full_Address,
                        EventImage = eventDetail.EventThumbnail,
                        VenueName = eventDetail.VenueName,
                        VenueRating = eventDetail.VenueRating,
                        VenueWebsite = eventDetail.VenueWebsite,
                        VenuePhoneNumber = eventDetail.Phone_Number,
                    };
                    events.Add(eventDTO);
                }

                return Ok(events);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error searching movies repositories");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }

}
