using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class GameService : IGameService
    {
        private readonly GameStoreContext _context;
        public GameService(GameStoreContext context) => _context = context;

        public async Task<Game> GetByIdAsync(int id)
        {
            return await _context.Games.AsSplitQuery()
                .Include(x => x.Genres)
                .Include(x => x.Comments).ThenInclude(x => x.Comments)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(Game model)
        {
            _context.Games.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var model = await _context.Games.AsSplitQuery()
                .Include(x => x.Genres)
                .Include(x => x.Comments).ThenInclude(x => x.Comments)
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id);
            _context.Games.Remove(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Game model)
        {
            _context.Games.Update(model);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _context.Games.AsSplitQuery()
                .Include(x => x.Genres)
                .Include(x => x.Comments).ThenInclude(x => x.Comments)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}