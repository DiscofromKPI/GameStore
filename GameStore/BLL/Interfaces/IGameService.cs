using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL.Interfaces
{
    public interface IGameService : ICrud<Game>
    {
        Task<IEnumerable<Game>> GetAllAsync();
    }
}