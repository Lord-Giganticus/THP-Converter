
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
            this.UseAudioCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 280);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(351, 183);
            this.button1.TabIndex = 0;
            this.button1.Text = "Search for a mp4 file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(610, 280);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(351, 183);
            this.button2.TabIndex = 1;
            this.button2.Text = "Save the new thp file";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(669, 190);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.PlaceholderText = "29.97";
            this.textBox1.Size = new System.Drawing.Size(245, 31);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(673, 160);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "The frame rate of the thp video";
            // 
            // VideoSizeComboBox
            // 
            this.VideoSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.VideoSizeComboBox.FormattingEnabled = true;
            this.VideoSizeComboBox.Items.AddRange(new object[] {
            "Original",
            "640x368",
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
            this.VideoSizeComboBox.Location = new System.Drawing.Point(704, 79);
            this.VideoSizeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.VideoSizeComboBox.MaxDropDownItems = 13;
            this.VideoSizeComboBox.Name = "VideoSizeComboBox";
            this.VideoSizeComboBox.Size = new System.Drawing.Size(171, 33);
            this.VideoSizeComboBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(743, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Video Size";
            // 
            // UseAudioCheckBox
            // 
            this.UseAudioCheckBox.AutoSize = true;
            this.UseAudioCheckBox.Checked = true;
            this.UseAudioCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseAudioCheckBox.Location = new System.Drawing.Point(723, 238);
            this.UseAudioCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UseAudioCheckBox.Name = "UseAudioCheckBox";
            this.UseAudioCheckBox.Size = new System.Drawing.Size(128, 29);
            this.UseAudioCheckBox.TabIndex = 8;
            this.UseAudioCheckBox.Text = "Use Audio?";
            this.UseAudioCheckBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(541, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(501, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Note: If using Original, Height/Width must be multiples of 16.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MP4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1143, 750);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UseAudioCheckBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.VideoSizeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
        private System.Windows.Forms.CheckBox UseAudioCheckBox;
        private System.Windows.Forms.Label label2;
    }
}