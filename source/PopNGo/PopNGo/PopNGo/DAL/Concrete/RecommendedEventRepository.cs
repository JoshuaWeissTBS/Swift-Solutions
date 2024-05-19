using PopNGo.DAL.Abstract;
using PopNGo.Models;
using Microsoft.EntityFrameworkCore;

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
            throw new NotImplementedException();
        }

        public void SetRecommendedEvents(int userId, List<int> eventIds)
        {
            throw new NotImplementedException();
        }
    }
}
