using Model.Entity;
using System.Collections.Generic;

namespace Model.DAO
{
    public interface SaleRepository
    {
        string Create(Sale obj);

        void Delete(Sale obj);

        void Update(Sale obj);

        bool Find(Sale obj);

        List<Sale> FindAll();
    }
}
