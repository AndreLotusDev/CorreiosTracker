using CorreioTracker.Context;
using CorreioTracker.Models;
using CorreioTracker.Repository.EF;

namespace CorreioTracker.Repository.Areas
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(TrackerContext context) : base(context)
        {

        }


    }
}
