using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.SMN_182.Repositories
{
    // Контракт с внешним хранилищем
    // CRUD-операции - Create, Read, Update, Delete
    public interface IRepository<T>
    {
        T Read(int id);
        IEnumerable<T> ReadAll();
        void Delete(int id);
        T Update(int id, T updated);
    }
}
