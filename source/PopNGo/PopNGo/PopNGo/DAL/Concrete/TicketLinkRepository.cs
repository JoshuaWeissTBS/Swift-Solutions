using PopNGo.DAL.Abstract;
using PopNGo.Models;
using Microsoft.EntityFrameworkCore;
using PopNGo.ExtensionMethods;

namespace PopNGo.DAL.Concrete
{
    public class TicketLinkRepository : Repository<TicketLink>, ITicketLinkRepository
    {
        private readonly DbSet<TicketLink> _ticketLink;
        public TicketLinkRepository(PopNGoDB context) : base(context)
        {
            _ticketLink = context.TicketLinks;
        }

        public void AddTicketLink(PopNGo.Models.DTO.TicketLink ticketLink)
        {
            var newTicketLink = new TicketLink {
                EventId = ticketLink.EventId,
                Source = ticketLink.Source,
                Link = ticketLink.Link,
            };
            AddOrUpdate(newTicketLink);
        }

        public IEnumerable<PopNGo.Models.DTO.TicketLink> GetTicketLinksFromApiEventId(string apiEventId)
        {
            if (string.IsNullOrEmpty(apiEventId))
            {
                throw new ArgumentException("ApiEventId cannot be null or empty", nameof(apiEventId));
            }
            return _ticketLink.Where(tl => tl.Event.ApiEventId == apiEventId).Select(tl => tl.ToDTO()).ToList();
        }
    }
}
