using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace model.Entities
{
    public class EventPreferenceTime : BaseEntity
    {
        public Guid PreferenceTimeId { get; set; }
        public PreferenceDateTime PreferenceDateTime { get; set; } = null!;
        public Guid EventId { get; set; }
        public Event Event { get; set; } = null!;
    }
}