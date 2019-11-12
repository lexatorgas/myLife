using System.Threading.Tasks;
using LifeCore.Models;

namespace LifeCore.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        T Save(T model);
        
        Task<T> SaveAsync(T model);

        T Update(T model);

        Task<T> UpdateAsync(T model);

        void Flush();

        Task FlushAsync();

        T GetById(int? id);

        Task<T> GetByIdAsync(int? id);
    }
}
