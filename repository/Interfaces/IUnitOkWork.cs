
using model.Entities;

namespace repository.Interfaces
{
    public interface IUnitOkWork
    {
        IRepository<User> UserRepository { get; }
        IRepository<Event> EventRepository { get; }

        IRepository<Location> LocationRepository { get; }   
        IRepository<Participant> ParticipantRepository { get; }
        
        Task<bool> Commit();
        Task Dispose();
    }
}