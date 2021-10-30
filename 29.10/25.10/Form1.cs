using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace _25._10
{

    public partial class Form1 : Form
    {
        public struct Person 
        {
            public string aftor;
            public DateTime date;
            public string name;
            public int kolstr;
  
        }
    public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            dataGridView1.RowCount = Convert.ToInt32(numericUpDown1.Value);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.RowCount = Convert.ToInt32(numericUpDown1.Value);
            Person[] mas = new Person[n];            
            for (int i = 0; i < n; i++)
            {
                mas[i].aftor = dataGridView1[0, i].Value.ToString();
                mas[i].date = Convert.ToDateTime(dataGridView1[1, i].Value);
                mas[i].name = dataGridView1[2, i].Value.ToString();
                mas[i].kolstr = Convert.ToInt32(dataGridView1[3, i].Value);
            }
            int max = mas[0].kolstr;
            for (int i = 0; i < n; i++)
            {
                if (max < mas[i].kolstr)
                {
                    max = mas[i].kolstr;
                }
            }
            MessageBox.Show(max.ToString());
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int n = dataGridView1.RowCount = Convert.ToInt32(numericUpDown1.Value);
            Person[] mas = new Person[n];
            for (int i = 0; i < n; i++)
            {
                mas[i].aftor = dataGridView1[0, i].Value.ToString();
                mas[i].date = Convert.ToDateTime(dataGridView1[1, i].Value);
                mas[i].name = dataGridView1[2, i].Value.ToString();
                mas[i].kolstr = Convert.ToInt32(dataGridView1[3, i].Value);
            }
            int min = mas[0].kolstr; 
            for (int i = 0; i < n; i++)
            {
                if (min > mas[i].kolstr)
                {

                  min = mas[i].kolstr;
                }
            }
            MessageBox.Show(min.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                int n = dataGridView1.RowCount = Convert.ToInt32(numericUpDown1.Value);
                Person[] mas = new Person[n];
                for (int i = 0; i < n; i++)
                {
                    mas[i].aftor = dataGridView1[0, i].Value.ToString();
                    mas[i].date = Convert.ToDateTime(dataGridView1[1, i].Value);
                    mas[i].name = dataGridView1[2, i].Value.ToString();
                    mas[i].kolstr = Convert.ToInt32(dataGridView1[3, i].Value);
                }
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName, true, System.Text.Encoding.Default);
                for (int i = 0; i < n; i++) 
                {
                    sw.WriteLine(mas[i].aftor);
                    sw.WriteLine(mas[i].date);
                    sw.WriteLine(mas[i].name);
                    sw.WriteLine(mas[i].kolstr);
                }
                sw.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                StreamReader sr = new StreamReader(saveFileDialog1.FileName,System.Text.Encoding.Default);
                Person[] mas = new Person[0];
                int k = 0;
                while (!sr.EndOfStream)
                {
                    k++;
                    Array.Resize(ref mas, k);
                    mas[k - 1].aftor = sr.ReadLine();
                    mas[k - 1].date =Convert.ToDateTime(sr.ReadLine());
                    mas[k - 1].name = sr.ReadLine();
                    mas[k - 1].kolstr = Convert.ToInt32(sr.ReadLine());
                }
                sr.Close();
                dataGridView1.RowCount = k;
                for (int i = 0; i < k; i++) 
                {
                    dataGridView1[0, i].Value = mas[i].aftor;
                    dataGridView1[1, i].Value = mas[i].date;
                    dataGridView1[2, i].Value = mas[i].name;
                    dataGridView1[3, i].Value = mas[i].kolstr;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
