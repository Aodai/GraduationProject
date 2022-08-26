using GraduationProject.ApplicationLogic.Models;

namespace GraduationProject.DataAccess
{
    public class EventRepository : BaseRepository<Event>
    {
        public EventRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
