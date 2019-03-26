using AdoNet.SMN_182.korean_shop.Entities;
using AdoNet.SMN_182.korean_shop.Repositories;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.SMN_182.korean_shop
{
    public class QrCodeGeneratorService
    {
        private readonly ProductRepository _productRepository;
        private readonly QrCodeRepository _qrCodeRepository;
        public void GetQrCodePurchaseInfo(int userId, int productId)
        {
            var productInfo = _productRepository.Read(productId);
            var userInfo = "Ruslan Z.";
            string purchaseInfoString = 
                $"At {DateTime.Now.ToShortTimeString()} {userInfo} " +
                $"purchased {productInfo.ProductName}";

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(purchaseInfoString, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            string pathToSave = ConfigurationManager.AppSettings["qrCodesOutputDirectory"];
            string fileName = $"{Guid.NewGuid().ToString()}.png";

            // qrCodeImage.Save(Path.Combine(pathToSave, fileName));

            using (MemoryStream ms = new MemoryStream())
            {
                qrCodeImage.Save(ms, ImageFormat.Png);
                _qrCodeRepository.Add(new QrCodeEntity()
                {
                    UserId = userId,
                    QrCodeType = QrCodeType.TextEncodedQrCode,
                    Content = ms.ToArray()
                });
            }
        }

        public QrCodeGeneratorService()
        {
            _productRepository = new ProductRepository();
            _qrCodeRepository = new QrCodeRepository();
        }
    }
}
