using PopNGo.Models;

namespace PopNGo.DAL.Abstract
{
    public interface IEventRepository : IRepository<Event>
    {
        // Add methods specific to Event here
        void AddEvent(EventDetail eventDetail);
        
        bool IsEvent(string apiEventId);
        
    }
}
