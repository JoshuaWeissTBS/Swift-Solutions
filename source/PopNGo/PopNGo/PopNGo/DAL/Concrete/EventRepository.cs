using PopNGo.DAL.Abstract;
using PopNGo.Models;
using Microsoft.EntityFrameworkCore;
using PopNGo.ExtensionMethods;

namespace PopNGo.DAL.Concrete
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        private readonly DbSet<Event> _event;
        public EventRepository(PopNGoDB context) : base(context)
        {
            _event = context.Events;
        }

        public void AddEvent(EventDetail eventDetail)
        {
            ValidateEventParameters(eventDetail);
            var newEvent = new Event {
                ApiEventId = eventDetail.EventID,
                EventDate = eventDetail.EventStartTime,
                EventName = eventDetail.EventName,
                EventDescription = eventDetail.EventDescription,
                EventLocation = eventDetail.Full_Address,
                EventImage = eventDetail.EventThumbnail,
            };
            AddOrUpdate(newEvent);
        }

        public bool IsEvent(string apiEventId)
        {
            if (string.IsNullOrEmpty(apiEventId))
            {
                throw new ArgumentException("ApiEventId cannot be null or empty", nameof(apiEventId));
            }
            return _event.Any(e => e.ApiEventId == apiEventId);
        }

        private void ValidateEventParameters(EventDetail eventDetail)
        {
            if (string.IsNullOrEmpty(eventDetail.EventID))
            {
                throw new ArgumentException("EventId cannot be null or empty", nameof(eventDetail.EventID));
            }

            if (eventDetail.EventStartTime == default(DateTime))
            {
                throw new ArgumentException("EventDate cannot be default", nameof(eventDetail.EventStartTime));
            }

            if (string.IsNullOrEmpty(eventDetail.EventName))
            {
                throw new ArgumentException("EventName cannot be null or empty", nameof(eventDetail.EventName));
            }
        }
    }
}
