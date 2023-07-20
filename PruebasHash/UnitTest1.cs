using HashFilesMA.FileHelpers;
using HashFilesMA.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PruebasHash
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string ruta = "C:\\Users\\Marco\\Pictures\\curso-node-restserver-4.0.0.zip";


            FileHashCalculator caluladoraHash = new FileHashCalculator();
            FileHmacHashCalculator hmacHashCalculator = new FileHmacHashCalculator();


            Assert.AreEqual("6C2D78388D4100710125AD00ABF75555", hmacHashCalculator.CalcularHashAll(TipoHMACHash.HMACMD5, ruta,"patito12345"));

        }

        [TestMethod]
        public void ProbarHex()
        {
            byte[] data = { 0b11111111,0b00001111 };

            string strHex = BytesConverter.ConvertBytesToHex(data);

            Assert.AreEqual("FF0F", strHex);
            

        }

    }
}
