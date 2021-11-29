using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICrud<T>
    {
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T model);
        Task DeleteByIdAsync(int id);
        Task UpdateByIdAsync(int id, T model);
    }
}