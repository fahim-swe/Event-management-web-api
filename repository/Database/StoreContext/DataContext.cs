using Microsoft.EntityFrameworkCore;
using model.Entities;

namespace repository.StoreContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {}

        public DbSet<User> User { get; set;}
        public DbSet<Event> Event { get; set;}
        public DbSet<Location> Location { get; set;}
        public DbSet<Participant> Participants { get; set;}
        public DbSet<EventLocation> EventLocations { get; set;}
        public DbSet<EventPreferenceTime> EventPreferenceTimes { get; set;}
        public DbSet<EventLocation> EventLocation  {    get; set;}
        public DbSet<PreferenceDateTime> DateTimes { get; set;}
        
        public DbSet<SocialMedia> SocialMedia { get; set;}

        
        protected override void  OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);


          

            modelBuilder.Entity<EventLocation>()
                .HasKey(key => new {key.Id, key.LocationId, key.EventId});
            

            modelBuilder.Entity<EventParticipant>()
               .HasKey(key => new {key.Id, key.EventId, key.ParticipantId});


            modelBuilder.Entity<EventPreferenceTime>()
                .HasKey(key => new {key.Id, key.EventId, key.PreferenceTimeId});

        }
    }
}