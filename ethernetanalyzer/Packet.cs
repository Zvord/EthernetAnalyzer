using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EthernetAnalyzer
{
    class Packet
    {
        public List<byte> Bytes;
        public int FlagsBefore;

        public Packet(List<byte> bytes, int flagsBefore)
        {
            Bytes = bytes;
            FlagsBefore = flagsBefore;
        }

        public override string ToString()
        {
            if (Bytes.Count == 0)
                return "Empty packet";
            StringBuilder hex = new StringBuilder(Bytes.Count * 2);
            int count = 0;
            foreach (byte b in Bytes)
            {
                if (count == 8)
                {
                    count = 0;
                    hex.Append("\n");
                }
                hex.AppendFormat("{0:X2}", b);
                count++;
            }
            return hex.ToString();
        }
    }
}
