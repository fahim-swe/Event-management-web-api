using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dto
{
    public class EventDto
    {
        public String Name {get;set;} = null!;
        public String DetailsInfo {get;set;} = null!;

        public List<String>? EventLocations{get;set;} = null!;
        
        public List<SocialMediaDto>? EventSocialMediaLinks {get;set;} 
        
        public List<PraticipantDto>? EventParticipants { get; set; }

        public List<PreferenceDateTimeDto>? EventPreferenceTimes {get; set; } = null;
        
        public DateTime VattingLastTime {get;set;} 
        public String TimeDuration {get; set;} = null!; 
    }
}