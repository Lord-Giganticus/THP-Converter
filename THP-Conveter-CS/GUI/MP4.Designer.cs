
namespace THP_Conveter_CS.GUI
{
    partial class MP4
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.VideoSizeComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(126, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(246, 110);
            this.button1.TabIndex = 0;
            this.button1.Text = "Search for a mp4 file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(427, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(246, 110);
            this.button2.TabIndex = 1;
            this.button2.Text = "Save the new thp file";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(460, 139);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "29.97";
            this.textBox1.Size = new System.Drawing.Size(173, 23);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(463, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "The frame rate of the thp video";
            // 
            // VideoSizeComboBox
            // 
            this.VideoSizeComboBox.FormattingEnabled = true;
            this.VideoSizeComboBox.Items.AddRange(new object[] {
            "336x528",
            "672x752",
            "496x240",
            "496x384",
            "352x256",
            "496x224",
            "512x512",
            "672x736",
            "400x576",
            "256x192",
            "608x464",
            "512x192"});
            this.VideoSizeComboBox.Location = new System.Drawing.Point(485, 95);
            this.VideoSizeComboBox.Name = "VideoSizeComboBox";
            this.VideoSizeComboBox.Size = new System.Drawing.Size(121, 23);
            this.VideoSizeComboBox.TabIndex = 6;
            this.VideoSizeComboBox.Text = "640x368";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(511, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Video Size";
            // 
            // MP4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.VideoSizeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.Name = "MP4";
            this.ShowIcon = false;
            this.Text = "THP-Converter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox VideoSizeComboBox;
        private System.Windows.Forms.Label label3;
    }
}