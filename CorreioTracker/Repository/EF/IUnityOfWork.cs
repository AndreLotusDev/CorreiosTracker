using CorreioTracker.Repository.Areas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorreioTracker.Repository.EF
{
    public interface IUnityOfWork
    {
        IUserRepository UserRepository { get; }
        Task Commit();
    }
}
