using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNet.SMN_182.korean_shop.Entities
{
    public enum QrCodeType : int
    {
        TextEncodedQrCode,
        LocationEncodedQrCode
    }
    public class QrCodeEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte [] Content { get; set; }
        public QrCodeType QrCodeType { get; set;}
    }
}
