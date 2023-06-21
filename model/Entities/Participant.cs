using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace model.Entities
{
    public class Participant : BaseEntity
    {
        public ParticipantType ParticipantType { get; set; }
        public Guid? ParticipantId {get; set; } = null;
        public User? ParticipantInfo { get; set; } = null;
        public List<EventParticipant>? EventParticipants { get; set; }
    }


    public enum ParticipantType 
    {
        Orgatizer, 
        Normal
    }
}