using AdoNet.SMN_182.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.SMN_182.Repositories
{
    public class MongoDbCategoryRepository : IRepository<Category>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Category Read(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Category Update(int id, Category updated)
        {
            throw new NotImplementedException();
        }
    }
}
