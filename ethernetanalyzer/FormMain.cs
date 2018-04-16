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
    public partial class FormMain : Form
    {

        const string labelPrefix = "Флагов от предыдущего пакета: ";

        public FormMain()
        {
            InitializeComponent();
            Packets = new List<Packet>();
        }

        private List<Packet> Packets;

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            var defaultColor = ButtonOpen.BackColor;
            ButtonOpen.BackColor = Color.Red;

            var dialogResult = OpenFileDialog.ShowDialog();
            if (dialogResult != DialogResult.OK)
            {
                ButtonOpen.BackColor = defaultColor;
                return;
            }

            string fileName = OpenFileDialog.FileName;

            byte[] bytes = System.IO.File.ReadAllBytes(fileName);
            if (CheckBoxReverseBefore.Checked)
                bytes = ReverseAllBits(bytes);
            BitArray bits = new BitArray(bytes);
            Packets = Analyzer.AnalyzeBitStream(bits, CheckBoxReverseFinal.Checked);
            if (Packets.Count == 0)
            {
                MessageBox.Show("No packets found");
                ButtonOpen.BackColor = defaultColor;
                return;
            }
            PacketSelecter.Text = "1";
            if (PacketSelecter.Items.Count > 1) // Due to some strange behaivour Items.Clear() does not return internal counter to 0
            {
                var item = PacketSelecter.Items[0];
                PacketSelecter.SelectedItem = item;
            }
            PacketSelecter.Items.Clear();
            for (int i = 1; i <= Packets.Count; i++)
                PacketSelecter.Items.Add(i.ToString());
            ButtonOpen.BackColor = Color.Green;
            TextBox.Text = Packets[0].ToString();
            LabelDistance.Text = labelPrefix + Packets[0].FlagsBefore.ToString();

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
            TextBox.Text = Packets[value-1].ToString();
            LabelDistance.Text = labelPrefix + Packets[value - 1].FlagsBefore.ToString();
        }

        private void ReverseFinalTrue_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
