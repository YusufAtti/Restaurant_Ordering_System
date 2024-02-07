using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sondeneme1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void baslatBtn_Click(object sender, EventArgs e)
        {
            
            SimuleEkran sml = new SimuleEkran(Convert.ToInt16(musteriTxt.Text), Convert.ToInt16(oncelikTxt.Text), Convert.ToInt16(masaTxt.Text), Convert.ToInt16(garsonTxt.Text), Convert.ToInt16(asciTxt.Text));
            this.Hide();
            sml.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            Problem2 pr = new Problem2(Convert.ToInt16(textBox1.Text));
            this.Hide();
            pr.Show();

        }
    }
}
