using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Diagnostics;

namespace EthernetAnalyzer
{
    class Analyzer
    {
        static private bool[] Flag = { false, true, true, true, true, true, true, false };
        static private bool[] Terminator = { true, true, true, true, true, true };

        static public List<Packet> AnalyzeBitStream(BitArray bits, bool revert)
        {
            List<Packet> packets = new List<Packet>();
            int curPos = 0;
            int distance = 0;
            while (true)
            {
                int flagStartInd = FindFlag(bits, curPos);
                bool[] test = ExtractBits(bits, flagStartInd, 8);
                bool[] test2 = ExtractBits(bits, flagStartInd + 8, 8);
                if (flagStartInd < 0)
                    break;
                int packetStart = FindPacketStart(bits, flagStartInd+8);
                if (packetStart < 0)
                    break;

                distance = packetStart - flagStartInd;
                Debug.Assert(distance % 8 == 0);
                distance /= 8;

                int packetEnd = FindPacketEnd(bits, packetStart);
                if (packetEnd < 0)
                    break;
                Tuple<List<bool>, int> packetInfo = ExtractPacket(bits, packetStart, packetEnd);
                if (packetInfo.Item2 < 0)
                {
                    var cur = packetInfo.Item1;
                    Packet newPacket = new Packet(ReverseBits(cur, revert), distance);
                    packets.Add(newPacket);
                }
                    
                curPos = packetEnd+1;
                
            }
            return packets;
        }

        /// <summary>
        /// Searhes for 0x7E flag. Returns starting index in the case of success and -1 in the case of failure.
        /// </summary>
        /// <param name="bits"></param>
        /// <param name="startInd"></param>
        /// <returns></returns>
        static private int FindFlag(BitArray bits, int startInd)
        {
            for (int i = startInd; i <= bits.Length-8; i++)
            {
                bool[] cur = ExtractBits(bits, i, 8);   
                if (cur.SequenceEqual(Flag))
                    return i;
            }
            return -1;
        }

        static private bool[] ExtractBits(BitArray bits, int startInd, int n)
        {
            bool[] cur = new bool[n];
            for (int j = 0; j < n; j++)
            {
                cur[j] = bits[startInd + j];
            }
            return cur;
        }

        static private int FindPacketStart(BitArray bits, int startInd)
        {
            for (int i = startInd; i <= bits.Length-8; i += 8)
            {
                bool[] cur = ExtractBits(bits, i, 8);
                if (!cur.SequenceEqual(Flag))
                    return i;
            }
            return -1;
        }

        static private int FindPacketEnd(BitArray bits, int startInd)
        {
            for (int i = startInd; i <= bits.Length - 8; i++)
            {
                bool[] cur = ExtractBits(bits, i, 8);
                //Console.WriteLine(i.ToString() + ":" + bits[i].ToString());
                if (cur.SequenceEqual(Flag))
                    return i;
            }
            return -1;
        }

        static private Tuple<List<bool>, int> ExtractPacket(BitArray bits, int startInd, int endInd)
        {
            List<bool> packet = new List<bool>();
            int cnt = 0;
            int ind = -1;
            for (int i = startInd; i < endInd; i++)
            {
                if (cnt == 5)
                {
                    if (bits[i] == false)
                    {
                        // do nothing
                    }
                    if (bits[i] == true)
                    {
                        if (bits[i++] == true)
                        {
                            packet = new List<bool>();
                            ind = i;
                            break;
                        }
                        else
                            throw new Exception("1 1 1 1 1 1 0 inside a packet");
                    }
                    cnt = 0;
                }
                else
                {
                    packet.Add(bits[i]);
                    if (bits[i])
                        cnt++;
                    else
                        cnt = 0;
                }
            }
            return new Tuple<List<bool>, int>(packet, ind);
        }

        static private List<byte> ReverseBits(List<bool> input, bool revert)
        {
            List<byte> newList = new List<byte>();
            for (int i = 0; i <= input.Count-8; i+=8)
            {
                var part = input.GetRange(i, 8);
                if (revert)
                    part.Reverse();
                newList.Add(ConvertToByte(part));
            }
            return newList;
        }

        static private byte ConvertToByte(List<bool> input)
        {
            int b = 0;
            for (int i = 0; i < 8; i++)
            {
                if (input[i])
                    b |= (1 << i);
            }
            return (byte)b;
        }
    }
}
