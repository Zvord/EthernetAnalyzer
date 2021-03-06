﻿namespace EthernetAnalyzer
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ButtonOpen = new System.Windows.Forms.Button();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.PacketSelecter = new System.Windows.Forms.DomainUpDown();
            this.CheckBoxReverseFinal = new System.Windows.Forms.CheckBox();
            this.CheckBoxReverseBefore = new System.Windows.Forms.CheckBox();
            this.LabelDistance = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ButtonOpen
            // 
            this.ButtonOpen.Location = new System.Drawing.Point(14, 62);
            this.ButtonOpen.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonOpen.Name = "ButtonOpen";
            this.ButtonOpen.Size = new System.Drawing.Size(122, 26);
            this.ButtonOpen.TabIndex = 0;
            this.ButtonOpen.Text = "Выбрать файл";
            this.ButtonOpen.UseVisualStyleBackColor = true;
            this.ButtonOpen.Click += new System.EventHandler(this.ButtonOpen_Click);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "bercut_send5_1_data.bin";
            this.OpenFileDialog.Filter = "Бинарники|*.bin|Все файлы|*.*";
            // 
            // TextBox
            // 
            this.TextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBox.Location = new System.Drawing.Point(13, 96);
            this.TextBox.Margin = new System.Windows.Forms.Padding(4);
            this.TextBox.Multiline = true;
            this.TextBox.Name = "TextBox";
            this.TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextBox.Size = new System.Drawing.Size(254, 412);
            this.TextBox.TabIndex = 1;
            // 
            // PacketSelecter
            // 
            this.PacketSelecter.Location = new System.Drawing.Point(143, 66);
            this.PacketSelecter.Margin = new System.Windows.Forms.Padding(4);
            this.PacketSelecter.Name = "PacketSelecter";
            this.PacketSelecter.Size = new System.Drawing.Size(91, 21);
            this.PacketSelecter.TabIndex = 2;
            this.PacketSelecter.Text = "1";
            this.PacketSelecter.SelectedItemChanged += new System.EventHandler(this.PacketSelecter_SelectedItemChanged);
            // 
            // CheckBoxReverseFinal
            // 
            this.CheckBoxReverseFinal.AutoSize = true;
            this.CheckBoxReverseFinal.Checked = true;
            this.CheckBoxReverseFinal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxReverseFinal.Location = new System.Drawing.Point(14, 9);
            this.CheckBoxReverseFinal.Margin = new System.Windows.Forms.Padding(4);
            this.CheckBoxReverseFinal.Name = "CheckBoxReverseFinal";
            this.CheckBoxReverseFinal.Size = new System.Drawing.Size(227, 19);
            this.CheckBoxReverseFinal.TabIndex = 4;
            this.CheckBoxReverseFinal.Text = "Развернуть байт после обработки";
            this.CheckBoxReverseFinal.UseVisualStyleBackColor = true;
            // 
            // CheckBoxReverseBefore
            // 
            this.CheckBoxReverseBefore.AutoSize = true;
            this.CheckBoxReverseBefore.Location = new System.Drawing.Point(14, 36);
            this.CheckBoxReverseBefore.Margin = new System.Windows.Forms.Padding(4);
            this.CheckBoxReverseBefore.Name = "CheckBoxReverseBefore";
            this.CheckBoxReverseBefore.Size = new System.Drawing.Size(207, 19);
            this.CheckBoxReverseBefore.TabIndex = 5;
            this.CheckBoxReverseBefore.Text = "Развернуть байт до обработки";
            this.CheckBoxReverseBefore.UseVisualStyleBackColor = true;
            // 
            // LabelDistance
            // 
            this.LabelDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LabelDistance.AutoSize = true;
            this.LabelDistance.Location = new System.Drawing.Point(11, 512);
            this.LabelDistance.Name = "LabelDistance";
            this.LabelDistance.Size = new System.Drawing.Size(192, 15);
            this.LabelDistance.TabIndex = 6;
            this.LabelDistance.Text = "Флагов от предыдущего пакета";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 536);
            this.Controls.Add(this.LabelDistance);
            this.Controls.Add(this.CheckBoxReverseBefore);
            this.Controls.Add(this.CheckBoxReverseFinal);
            this.Controls.Add(this.PacketSelecter);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.ButtonOpen);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(300, 265);
            this.Name = "FormMain";
            this.Text = "Etherseer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonOpen;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.DomainUpDown PacketSelecter;
        private System.Windows.Forms.CheckBox CheckBoxReverseFinal;
        private System.Windows.Forms.CheckBox CheckBoxReverseBefore;
        private System.Windows.Forms.Label LabelDistance;
    }
}

