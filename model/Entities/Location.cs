using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace model.Entities
{
    public class Location : BaseEntity
    {
        public String Name { get; set; } = null!;
        
        public List<EventLocation>? EventLocations { get; set; }
    }
}