using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiWebDAL
{
    public interface IGenericRepository<TEntity>
    {
        List<TEntity> GetAllAsync();
        Task<TEntity> GetAsync(int id);
        void InsertAsync(TEntity entity);
        void DeleteAsync(int id);
        void UpdateAsync(TEntity entityToUpdate);
    }
}
