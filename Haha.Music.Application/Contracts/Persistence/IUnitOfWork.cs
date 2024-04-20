using System;
using System.Threading.Tasks;

namespace Haha.Music.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save();
    }
}
