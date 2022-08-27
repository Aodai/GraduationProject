using GraduationProject.ApplicationLogic.Abstractions;
using GraduationProject.ApplicationLogic.Models;

namespace GraduationProject.DataAccess
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
