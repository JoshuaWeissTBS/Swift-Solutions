using PopNGo.Models;

namespace PopNGo.DAL.Abstract
{
    public interface ITicketLinkRepository : IRepository<TicketLink>
    {
        void AddTicketLink(PopNGo.Models.DTO.TicketLink ticketLink);
        IEnumerable<PopNGo.Models.DTO.TicketLink> GetTicketLinksFromApiEventId(string apiEventId);
    }
}
