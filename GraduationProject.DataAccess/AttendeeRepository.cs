using GraduationProject.ApplicationLogic.Abstractions;
using GraduationProject.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationProject.DataAccess
{
    public class AttendeeRepository : BaseRepository<Attendee>, IAttendeeRepository
    {
        public AttendeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
