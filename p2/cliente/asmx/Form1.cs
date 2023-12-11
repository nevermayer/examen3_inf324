using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace asmx
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.ReadOnly = true;
            updatelist();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!textBox1.ReadOnly)
                return;
            var ws = new ServiceReference1.WebService1SoapClient();
            MessageBox.Show(ws.eliminaEstudiante(textBox1.Text));
            updatelist();
            clean();
        }

        private void updatelist()
        {
            var ws = new ServiceReference1.WebService1SoapClient();
            DataSet ds = new DataSet();
            ds = ws.ListaEstudiante();
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dg=(DataGridView)sender;
            int index=dg.CurrentRow.Index;
            textBox1.ReadOnly = true;
            textBox1.Text = dg.Rows[index].Cells[0].Value.ToString();
            textBox2.Text = dg.Rows[index].Cells[1].Value.ToString();
            textBox3.Text = dg.Rows[index].Cells[2].Value.ToString();
            textBox4.Text = dg.Rows[index].Cells[3].Value.ToString();
            comboBox1.Text= dg.Rows[index].Cells[4].Value.ToString();
            dateTimePicker1.Text = dg.Rows[index].Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ws = new ServiceReference1.WebService1SoapClient();
            if(textBox1.ReadOnly)
                MessageBox.Show( ws.editaEstudiante(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Text,comboBox1.Text));
            else
                MessageBox.Show(ws.CreaEstudiante(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, dateTimePicker1.Text, comboBox1.Text));
            updatelist();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clean();
        }

        private void clean()
        {
            textBox1.ReadOnly = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "";
            dateTimePicker1.Text ="";
        }
    }
}
