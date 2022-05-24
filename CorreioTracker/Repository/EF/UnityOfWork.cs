using CorreioTracker.Context;
using CorreioTracker.Repository.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorreioTracker.Repository.EF
{
    public class UnityOfWork : IUnityOfWork
    {
        private TrackerContext _context;
        private UserRepository _usuarioRepo;

        public UnityOfWork(TrackerContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository { get => _usuarioRepo ?? new UserRepository(_context);}

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
