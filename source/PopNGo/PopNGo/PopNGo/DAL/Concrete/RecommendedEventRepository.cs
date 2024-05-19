using PopNGo.DAL.Abstract;
using PopNGo.Models;
using Microsoft.EntityFrameworkCore;
using PopNGo.ExtensionMethods;

namespace PopNGo.DAL.Concrete
{
    public class RecommendedEventRepository : Repository<RecommendedEvent>, IRecommendedEventRepository
    {
        private readonly DbSet<RecommendedEvent> _recommendedEvents;
        public RecommendedEventRepository(PopNGoDB context) : base(context)
        {
            _recommendedEvents = context.RecommendedEvents;
        }

        public List<Models.DTO.Event> GetRecommendedEvents(int userId)
        {
            var events = _recommendedEvents.Where(e => e.UserId == userId).Select(e => e.Event.ToDTO()).ToList();
            return events;
        }

        public void SetRecommendedEvents(int userId, List<int> eventIds)
        {
            var recommendedEvents = _recommendedEvents.Where(e => e.UserId == userId).ToList();

            // Delete all existing recommended events for the user
            foreach (var recommendedEvent in recommendedEvents)
            {
                Delete(recommendedEvent);
            }

            // Add the new recommended events
            foreach (var eventId in eventIds)
            {
                var recommendedEvent = new RecommendedEvent { UserId = userId, EventId = eventId };
                AddOrUpdate(recommendedEvent);
            }
        }
    }
}
