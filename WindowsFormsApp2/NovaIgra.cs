using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class NovaIgra : Form
    {
        MSMain glavna;
        public NovaIgra(MSMain gl, String Username)
        {
            InitializeComponent();
            glavna = gl;
            textBox1.Text = Username;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(""))
            {
                MessageBox.Show("Polje za nadimak ne sme biti prazno!");
                return;
            }

            int br= Convert.ToInt32(numericUpDown1.Text);
            if (br < 3 || br>9)
            {
                MessageBox.Show("Velčina kvadrata mora biti broj izmedju 3 i 9!");
                return;
            }
            glavna.N = br;
            glavna.Username = textBox1.Text;
            this.Close();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {

        }

        private void NovaIgra_Load(object sender, EventArgs e)
        {

        }

        private void NovaIgra_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
