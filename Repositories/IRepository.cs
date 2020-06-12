using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadAPI.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //IQueryable<TEntity> Entities { get; }
        void Delete(TEntity entity);
        void Add(TEntity entity);
        TEntity GetByID(object id);
        List<TEntity> GetAll();
        void Update(TEntity entityToUpdate);
        void Delete(object id);

    }
}
