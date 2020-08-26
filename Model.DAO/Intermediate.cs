using System.Collections.Generic;

namespace Model.DAO
{
   public interface Intermediate<TEntity>
    {
        void Create(TEntity obj);

        void Delete(TEntity obj);

        void Update(TEntity obj);

        bool Find(TEntity obj);

        List<TEntity> FindAll();
    }
}
