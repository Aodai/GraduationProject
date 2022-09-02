using GraduationProject.ApplicationLogic.Abstractions;
using GraduationProject.ApplicationLogic.Exceptions;
using GraduationProject.ApplicationLogic.Models;

namespace GraduationProject.ApplicationLogic.Services
{
    public class AttendeeService
    {
        private IAttendeeRepository attendeeRepository { get; set; }

        public AttendeeService(IAttendeeRepository attendeeRepository)
        {
            this.attendeeRepository = attendeeRepository;
        }

        public Attendee Get(string id)
        {
            if (!Guid.TryParse(id, out Guid attendeeGuid))
                throw new Exception("Invalid GUID format");
            var entity = attendeeRepository.Get(attendeeGuid);
            return entity;
        }

        public IEnumerable<Attendee> GetAttendees()
        {
            var attendees = attendeeRepository.GetAll() ?? throw new EntityNotFoundException("No events found");
            return attendees;
        }

        public IEnumerable<Attendee> GetAttendeesForEvent(string eventId)
        {
            if (!Guid.TryParse(eventId, out Guid eventGuid))
                throw new Exception("Invalid GUID format");
            var attendees = attendeeRepository.GetAll().Where(attendee => attendee.EventId == eventGuid);
            return attendees;
        }

        public IEnumerable<Attendee> GetEventsForUser(string userId)
        {
            if (!Guid.TryParse(userId, out Guid userGuid))
                throw new Exception("Invalid GUID format");
            var events = attendeeRepository.GetAll().Where(attendee => attendee.AttendeeId == userGuid);
            return events;
        }

        public bool AlreadyInterested(string userId, string eventId)
        {
            if (!Guid.TryParse(userId, out Guid userGuid))
                throw new Exception("Invalid GUID format");
            if(!Guid.TryParse(eventId, out Guid eventGuid))
                throw new Exception("Invalid GUID format");

            var attnd = attendeeRepository.GetAll().Where(attendee => attendee.EventId == eventGuid && attendee.AttendeeId == userGuid).FirstOrDefault();
            if (attnd == null)
                return false;
            return true;
        }

        public Attendee Add(Attendee attendee)
        {
            return attendeeRepository.Add(attendee);
        }

        public Attendee Update(Attendee attendee)
        {
            return attendeeRepository.Update(attendee);
        }

        public void Delete(Attendee attendee)
        {
            attendeeRepository.Delete(attendee);
        }
    }
}
