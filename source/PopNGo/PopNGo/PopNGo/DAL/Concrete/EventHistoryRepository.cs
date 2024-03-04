using PopNGo.DAL.Abstract;
using PopNGo.Models;
using Microsoft.EntityFrameworkCore;
using PopNGo.ExtensionMethods;
using PopNGo.Models.DTO;

namespace PopNGo.DAL.Concrete
{
    public class EventHistoryRepository : Repository<EventHistory>, IEventHistoryRepository
    {
        private readonly DbSet<EventHistory> _eventHistories;
        private readonly DbSet<Models.Event> _events;
        public EventHistoryRepository(PopNGoDB context) : base(context)
        {
            _eventHistories = context.EventHistories;
            _events = context.Events;
        }

        public List<PopNGo.Models.DTO.Event> GetEventHistory(int userId)
        {
            return _eventHistories.Where(eh => eh.UserId == userId).Select(eh => eh.Event.ToDTO()).ToList();
        }

        public void AddEventHistory(int userId, string apiEventId)
        {
            if (string.IsNullOrEmpty(apiEventId))
            {
                throw new ArgumentException("EventId cannot be null or empty", nameof(apiEventId));
            }

            var eventEntity = _events.FirstOrDefault(e => e.ApiEventId == apiEventId);
            if (eventEntity == null)
            {
                throw new ArgumentException($"No event found with the id {apiEventId}", nameof(apiEventId));
            }
            var eventHistory = new EventHistory { UserId = userId, EventId = eventEntity.Id };

            try
            {
                AddOrUpdate(eventHistory);
            }
            catch (Exception ex)
            {
                // Log the exception, rethrow it, or handle it in some other way
                throw new Exception("Error adding or updating event history", ex);
            }
        }
    }
}
