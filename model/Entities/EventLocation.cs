using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace model.Entities
{
    public class EventLocation : BaseEntity
    {
        public Guid EventId { get; set; }
        public Event Event { get; set; } = null!;
        public Guid LocationId {get;set;}
        public Location location{get; set; } = null!;

    }
}