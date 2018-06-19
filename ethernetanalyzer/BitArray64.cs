using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime;

namespace EthernetAnalyzer
{
    public class BitArray64
    {
        const int MaxBitArrayInputArraySize = int.MaxValue / 8;
        const int MaxBitArrayIndex = int.MaxValue - 7;

        List<BitArray> arrays;
        public long Count
        {
            get
            {
                long l = 0;
                foreach (var ar in arrays)
                    l += ar.Count;
                return l;
            }
        }

        public int NumberOfBitArrays { get { return arrays.Count; } }

        public BitArray64(byte[] bytes)
        {
            long size = bytes.LongLength;
            (int intPart, int fracPart) = GetIntFrac(size, MaxBitArrayInputArraySize);
            int addition = fracPart > 0 ? 1 : 0;
            int numberOfArrays = intPart + addition;
            arrays = new List<BitArray>();
            for (int i = 0; i < numberOfArrays; i++)
            {
                if (i < numberOfArrays - 1) // not last
                {
                    //byte[] testAr = new byte[upperBound];
                    byte[] newAr = bytes.Take(MaxBitArrayInputArraySize).ToArray();
                    arrays.Add(new BitArray(newAr));
                    //arrays.Add(new BitArray(bytes.);
                    bytes = bytes.Skip(MaxBitArrayInputArraySize).ToArray();
                }
                else
                {
                    arrays.Add(new BitArray(bytes));
                }
            }
        }

        public bool this[long i]
        {
            get
            {
                if (i > Count)
                    throw new Exception("Index out of range");
                (int intPart, int fracPart) = GetIntFrac(i, MaxBitArrayIndex);
                var ar = arrays[intPart];
                return ar[fracPart];
            }
        }

        private (int _intPart, int _fracPart) GetIntFrac(long sz, int upperBound)
        {
            int fracPart = (int)(sz % upperBound);
            int intPart = (int)(sz / upperBound);
            return (intPart, fracPart);
        }
    }
}
