using System.Threading.Tasks;
using LifeCore.Interfaces;
using LifeCore.Models;
using NHibernate;

namespace LifeCore.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ISession _session;

        public Repository(ISession session)
        {
            _session = session;
        }

        public void Flush()
        {
            try
            {
                if (_session.Transaction?.IsActive ?? false)
                    _session.Transaction.Commit();
            }
            catch
            {
                if (_session.Transaction?.IsActive ?? false)
                    _session.Transaction.Rollback();

                throw;
            }
        }

        public async Task FlushAsync()
        {
            try
            {
                if (_session.Transaction?.IsActive ?? false)
                    await _session.Transaction.CommitAsync();
            }
            catch
            {
                if (_session.Transaction?.IsActive ?? false)
                    await _session.Transaction.RollbackAsync();

                throw;
            }
        }

        public T GetById(int? id)
        {
            return id is null ? null : _session.Get<T>(id);
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            return id is null ? null : await _session.GetAsync<T>(id);
        }

        public T Save(T model)
        {
            _session.Save(model);
            return model;
        }

        public async Task<T> SaveAsync(T model)
        {
            await _session.SaveAsync(model);
            return model;
        }

        public T Update(T model)
        {
            _session.Update(model);
            return model;
        }

        public async Task<T> UpdateAsync(T model)
        {
            await _session.UpdateAsync(model);
            return model;
        }
    }
}
