using System;
using System.Collections;
using EthernetAnalyzer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBitArrayIndexing()
        {
            // Arrange
            byte[] byteArray = { 1, 2, 3, 4 };
            BitArray reference = new BitArray(byteArray);
            BitArray64 dut = new BitArray64(byteArray);
            // Assert
            Assert.Equals(reference.Count, dut.Count);
        }
        private bool CompareElements(BitArray reference, BitArray64 dut)
        {
            bool res = true;
            for (int i = 0; i < reference.Count; i++)
            {
                res &= reference[i] == dut[i];
            }
            return res;
        }
    }
}
