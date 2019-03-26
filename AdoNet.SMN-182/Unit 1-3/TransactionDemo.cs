using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.SMN_182.Unit_1_3
{
    public class TransactionDemo
    {
        public void MakeOrderProcess(int userId, string productName, int employeeId)
        {
            string cs = ConfigurationManager.ConnectionStrings["DefaultConnectionString"]
                .ConnectionString;

            using(SqlConnection sqlConnection = new SqlConnection(cs))
            {
                sqlConnection.Open();

                IsolationLevel isolationLevel = IsolationLevel.Serializable;

                using (SqlTransaction sqlTransactionScope = sqlConnection.BeginTransaction(isolationLevel))
                {
                    string insertSaleRecordSql = $"INSERT INTO SALES(ProductName, EmployeeId, Quntity) VALUES('{productName}',{employeeId},1)";
                    string updateEmployeeKpiSql = $"UPDATE EMPLOYEES SET KPI=KPI+10 WHERE ID={employeeId}";
                    string insertShipmentRecrodSql = $"INSERT INTO SHIPMENTS(SALE_ID, DEST_ADDR) VALUES(1)";

                    try
                    {
                        using (SqlCommand insertSaleRecordCommand = new SqlCommand(insertSaleRecordSql, sqlConnection))
                        {

                            insertSaleRecordCommand.Transaction = sqlTransactionScope;
                            insertSaleRecordCommand.ExecuteNonQuery();

                        }

                        using (SqlCommand updateEmployeeKpiSqlCommand = new SqlCommand(updateEmployeeKpiSql, sqlConnection))
                        {
                            updateEmployeeKpiSqlCommand.Transaction = sqlTransactionScope;
                            updateEmployeeKpiSqlCommand.ExecuteNonQuery();
                        }

                        using (SqlCommand insertShipmentRecrodSqlCommand = new SqlCommand(insertShipmentRecrodSql, sqlConnection))
                        {
                            insertShipmentRecrodSqlCommand.Transaction = sqlTransactionScope;
                            insertShipmentRecrodSqlCommand.ExecuteNonQuery();
                        }

                        sqlTransactionScope.Commit();
                    }
                    catch(Exception ex)
                    {
                        sqlTransactionScope.Rollback();
                        Console.WriteLine(ex.Message);                    
                    }


                }
                

            }

        }
    }
}
