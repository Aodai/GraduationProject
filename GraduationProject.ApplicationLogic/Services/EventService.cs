using GraduationProject.ApplicationLogic.Abstractions;
using GraduationProject.ApplicationLogic.Exceptions;
using GraduationProject.ApplicationLogic.Models;

namespace GraduationProject.ApplicationLogic.Services
{
    public class EventService
    {
        public IEventRepository eventRepository { get; set; }
        
        public EventService(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public Event Get(string id)
        {
            if (!Guid.TryParse(id, out Guid eventGuid))
                throw new Exception("Invalid GUID format");
            var entity = eventRepository.Get(eventGuid);
            return entity;
        }

        public IEnumerable<Event> GetEvents()
        {
            var events = eventRepository.GetAll() ?? throw new EntityNotFoundException("No events found");
            return events;
        }

        public Event Add(Event entity)
        {
            return eventRepository.Add(entity);
        }

        public Event Update(Event entity)
        {
            return eventRepository.Update(entity);
        }

        public void Delete(Event entity)
        {
            eventRepository.Delete(entity);
        }
    }
}
