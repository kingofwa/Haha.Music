
using Haha.Music.Application.Constants;
using Haha.Music.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Http;

namespace Haha.Music.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly HahaMusicDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public UnitOfWork(HahaMusicDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

            await _context.SaveChangesAsync(username);
        }
    }
}
