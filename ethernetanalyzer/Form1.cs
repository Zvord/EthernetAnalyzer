using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace EthernetAnalyzer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Packets = new List<List<byte>>();
        }

        private List<List<byte>> Packets;

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            ButtonOpen.BackColor = Color.Red;
            var dialogResult = OpenFileDialog.ShowDialog();
            if (dialogResult != DialogResult.OK)
                return;
            string fileName = OpenFileDialog.FileName;
            byte[] bytes = System.IO.File.ReadAllBytes(fileName);
            if (CheckBoxReverseBefore.Checked)
                bytes = ReverseAllBits(bytes);
            BitArray bits = new BitArray(bytes);
            Packets = Analyzer.AnalyzeBitStream(bits, CheckBoxReverseFinal.Checked);
            TextBox.Text = PrintPacket(Packets[0]);
            PacketSelecter.Text = "1";
            PacketSelecter.Items.Clear();
            for (int i = 1; i <= Packets.Count; i++)
                PacketSelecter.Items.Add(i.ToString());
            ButtonOpen.BackColor = Color.Green;
        }

        private byte ReverseBits(byte v)
        {
            byte r = v; // r will be reversed bits of v; first get LSB of v
            //int s = sizeof(v) * CHAR_BIT - 1; // extra shift needed at end
            int s = 7;

            for (v >>= 1; v != 0; v >>= 1)
            {
                r <<= 1;
                r |= (byte)((int)v & 1);
                s--;
            }
            r <<= s; // shift when v's highest bits are zero
            return r;
        }

        private byte[] ReverseAllBits(byte[] bytes)
        {
            byte[] ret = new byte[bytes.Length];
            for (int i = 0; i < bytes.Length; i++)
            {
                ret[i] = ReverseBits(bytes[i]);
            }
            return ret;
        }

        static private string PrintPacket(List<byte> bytes)
        {
            StringBuilder hex = new StringBuilder(bytes.Count * 2);
            int count = 0;
            foreach (byte b in bytes)
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

        private void PacketSelecter_SelectedItemChanged(object sender, EventArgs e)
        {
            if (PacketSelecter.Text == string.Empty)
                return;
            var value = Convert.ToInt32(PacketSelecter.Text);
            if (Packets.Count == 0)
                PacketSelecter.Text = "1";
            else
            {
                if (value > Packets.Count)
                {
                    value = Packets.Count;
                    PacketSelecter.Text = value.ToString();
                }
            }
            TextBox.Text = PrintPacket(Packets[value-1]);
        }

        private void ReverseFinalTrue_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
