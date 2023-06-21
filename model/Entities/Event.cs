namespace model.Entities
{
    public class Event : BaseEntity
    {
        public Guid EventOwnerId { get; set; }
        public User EventOwner { get; set; }
        
        public String Name {get;set;} = null!;
        public String DetailsInfo {get;set;} = null!;

        public List<EventLocation>? EventLocations{get;set;} = null!;
        
        public List<SocialMedia>? EventSocialMediaLinks {get;set;} 
        
        public List<EventParticipant>? EventParticipants { get; set; }

        public List<EventPreferenceTime>? EventPreferenceTimes {get; set; } = null;

        public DateTime VattingLastTime {get;set;} 
        public String TimeDuration {get; set;} = null!; 
    }
}