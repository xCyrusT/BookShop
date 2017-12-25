using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.IRepository
{
    public interface IGenericRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetByID(int id);
        int Update(T item);
        int Delete(int id);
        int Create(T item);
    }
}
