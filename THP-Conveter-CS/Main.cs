using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            GUI.AboutBox aboutBox = new GUI.AboutBox();
            aboutBox.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GUI.THP THP = new GUI.THP();
            THP.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GUI.MP4 MP4 = new GUI.MP4();
            MP4.ShowDialog();
        }
    }
}
