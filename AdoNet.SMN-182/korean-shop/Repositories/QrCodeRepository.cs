using AdoNet.SMN_182.korean_shop.Entities;
using AdoNet.SMN_182.Unit_1_3;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.SMN_182.korean_shop.Repositories
{
    public class QrCodeRepository
    {
        private string GetTableName()
        {
            return $"[dbo].[qrCodes]";
        }

        public void Add(QrCodeEntity entity)
        {
            string sqlCommand = $"INSERT INTO {GetTableName()}(UserId, Content, QrCodeType) " +
                $"VALUES (@userId, @content, @qrCodeType)";

            using(SqlConnection sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                using(SqlCommand command = new SqlCommand(sqlCommand, sqlConnection))
                {
                    SqlParameter userIdParam = new SqlParameter("@userId", entity.UserId);
                    SqlParameter contentParam = new SqlParameter("@content", entity.Content);
                    SqlParameter qrCodeTypeParam = new SqlParameter("@qrCodeType", (int)entity.QrCodeType);

                    command.Parameters.Add(userIdParam);
                    command.Parameters.Add(contentParam);
                    command.Parameters.Add(qrCodeTypeParam);

                    command.ExecuteNonQuery();
                }
            }
        }

        public QrCodeEntity Read(int id)
        {
            QrCodeEntity entity = new QrCodeEntity();
            string sql = $"SELECT * FROM {GetTableName()} WHERE ID= @id";
            using (SqlConnection sqlConnection = new SqlConnection(GetConnectionString()))
            {
                sqlConnection.Open();
                SqlParameter IdParam = new SqlParameter("@id", id);

                using (SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection))
                {
                    sqlCommand.Parameters.Add(IdParam);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            entity.Id = Int32.Parse(reader["Id"].ToString());
                            entity.Content = (byte[])reader["Content"];
                            entity.QrCodeType = (QrCodeType)reader["QrCodeType"];
                        }
                    }
                    else throw new Exception("No data found!");
                }
                return entity;
            }
        }
            
        private string GetConnectionString()
        {
            ConnectionStringInAppConfigDemo appConfig =
                new ConnectionStringInAppConfigDemo();
            return appConfig.GetConnectionString();
        }

    }
}
