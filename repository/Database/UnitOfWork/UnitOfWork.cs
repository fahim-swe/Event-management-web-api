using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using model.Entities;
using repository.Database.Generic;
using repository.Interfaces;
using repository.StoreContext;

namespace repository.Database.UnitOfWork
{
    public class UnitOfWork : IUnitOkWork
    {

        private readonly DataContext _context;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }


        public IRepository<User> UserRepository => new Repository<User>(_context);
        public IRepository<Event> EventRepository => new Repository<Event>(_context);
        public IRepository<Location> LocationRepository => new Repository<Location>(_context);

        public IRepository<Participant> ParticipantRepository => new Repository<Participant>(_context);

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task Dispose()
        {
            await _context.DisposeAsync();
        }
    }
}