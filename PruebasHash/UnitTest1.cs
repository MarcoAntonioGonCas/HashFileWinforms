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
            byte[] data = { 0b11111111, 0b11111111, 0b11111111 };

            int num = 16;

            string b1 = BytesConverter.IntToBitsEnd(num);
            string b2 = BytesConverter.IntToBitsEndEvil(num);
            string b3 = BytesConverter.IntToBitsStart(num);
            string b4 = BytesConverter.IntToBitsStartEvil(num);


            Assert.AreEqual(b1, "00010000".PadLeft(32, '0'));
            Assert.AreEqual(b2, "00010000".PadLeft(32, '0'));
            Assert.AreEqual(b3, "00010000".PadLeft(32, '0'));
            Assert.AreEqual(b4, "00010000".PadLeft(32, '0'));
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
