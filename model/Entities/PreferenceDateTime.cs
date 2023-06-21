using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace model.Entities
{
    public class PreferenceDateTime : BaseEntity
    {
        public DateOnly Date { get; set; } 
        public TimeOnly Time { get; set; }
        
        public List<EventPreferenceTime> EventPreferenceTimes { get; set; } = null!;
    }
}