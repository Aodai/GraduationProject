using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationProject.ApplicationLogic.Models
{
    public class Event
    {
        public Guid Id { get; set; }
        public Guid OrganiserId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
