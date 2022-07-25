using Microsoft.AspNetCore.Identity;

namespace GraduationProject.ApplicationLogic.Models
{
    public class Attendee
    {
        public Guid Id { get; set; }
        public Guid EventId { get; set; }
        public Guid AttendeeId { get; set; }
    }
}
