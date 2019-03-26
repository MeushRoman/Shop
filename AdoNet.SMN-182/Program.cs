using AdoNet.SMN_182.korean_shop;
using AdoNet.SMN_182.korean_shop.Entities;
using AdoNet.SMN_182.korean_shop.Repositories;
using AdoNet.SMN_182.Unit_1_3;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.SMN_182
{
    class Program
    {
        static void Main(string[] args)
        {
            //decimal cost = 1000;
            //string name = "Vaccum Cleaner); drop table products;";

            //string sqlTemplate = "insert into [dbo].[products]([ProductName],[Cost]) " +
            //    "values(@productName, @cost)";

            //ConnectionStringInAppConfigDemo appConfig =
            //    new ConnectionStringInAppConfigDemo();

            //using (SqlConnection sqlConnection = new SqlConnection(appConfig.GetConnectionString()))
            //{
            //    sqlConnection.Open();
            //    using(SqlCommand sqlCommand = new SqlCommand(sqlTemplate, sqlConnection))
            //    {
            //        SqlParameter parameterI = new SqlParameter("@productName", name);
            //        SqlParameter parameterII = new SqlParameter("@cost", cost);

            //        sqlCommand.Parameters.Add(parameterI);
            //        sqlCommand.Parameters.Add(parameterII);

            //        sqlCommand.ExecuteNonQuery();
            //    }

            //}


            //QrCodeGeneratorService qrCodeGeneratorService = new QrCodeGeneratorService();
            //qrCodeGeneratorService.GetQrCodePurchaseInfo(1, 1);
            //QrCodeRepository qrRep = new QrCodeRepository();
            //QrCodeEntity entity = qrRep.Read(1);

            //QRCodeData data = new QRCodeData(entity.Content, QRCodeData.Compression.Uncompressed);
            //QRCode qRCode = new QRCode(data);
            //using(MemoryStream ms = new MemoryStream())
            //{
            //    ms.Write(entity.Content, 0, entity.Content.Length);
            //    Bitmap qrCodeImage = new Bitmap(ms);
            //    qrCodeImage.Save(@"C:\qr-codes\111.png");
            //}

            TransactionDemo tDemo = new TransactionDemo();
            tDemo.MakeOrderProcess(1, "Computer", 1);
            // Console.WriteLine(sqlTemplate);
            Console.ReadLine();
        }
    }
}
