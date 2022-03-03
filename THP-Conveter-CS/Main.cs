using System;
using System.Windows.Forms;

namespace THP_Conveter_CS
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            
        }
        private void AboutMenu_Click(object sender, EventArgs e)
        {
            GUI.AboutBox aboutBox = new();
            aboutBox.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI.THP THP = new();
            THP.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GUI.MP4 MP4 = new();
            MP4.ShowDialog();
        }
    }
}
