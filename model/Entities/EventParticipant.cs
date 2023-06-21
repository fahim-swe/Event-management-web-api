using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace model.Entities
{
    public class EventParticipant : BaseEntity
    {
        public Guid EventId { get; set; }
        public Event Event  { get; set; } = null!;
        
        public Guid ParticipantId { get; set; }
        public Participant Participant { get; set; } = null!;
    }
}