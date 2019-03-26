using AdoNet.SMN_182.Entities;
using AdoNet.SMN_182.Unit_1_3;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.SMN_182.Repositories
{
    public class DefaultCategoryRepository : IRepository<Category>
    {
        private readonly string _tableName = "[dbo].[Categories]";
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Category Read(int id)
        {
            string sql = $"SELECT * FROM {_tableName} WHERE ID = {id}";
            using(SqlConnection sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                using(SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                }
            }
            return null;
        }

        public IEnumerable<Category> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Category Update(int id, Category updated)
        {
            throw new NotImplementedException();
        }

        private string GetConnectionString()
        {
            ConnectionStringInAppConfigDemo appConfig = 
                new ConnectionStringInAppConfigDemo();
            return appConfig.GetConnectionString();
        }
    }
}
