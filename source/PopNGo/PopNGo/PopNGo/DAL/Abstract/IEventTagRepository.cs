using PopNGo.Models;

namespace PopNGo.DAL.Abstract
{
    public interface IEventTagRepository : IRepository<EventTag>
    {
        public void AddEventTag(int tagId, int eventId);
    }
}
