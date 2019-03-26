using AdoNet.SMN_182.Entities;
using AdoNet.SMN_182.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.SMN_182.Services
{
    public class ShopManagement
    {
        private readonly IRepository<Category> _categoryRepository;

        public void AddNewCategory(string categoryName)
        {
            //_categoryRepository.Add();
        }
        public ShopManagement()
        {
            _categoryRepository = new MongoDbCategoryRepository();
        }
    }
}
