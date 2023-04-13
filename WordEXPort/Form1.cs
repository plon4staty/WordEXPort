using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordEXPort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var help = new Wordhelp("Компания строй модерн.docx");
            var items = new Dictionary<string, string>
            {
                {"<NTOVARA>", textBox1.Text },
                {"<KOLICHESTVO>", textBox2.Text },
                {"<PRICE>", textBox3.Text },
                {"<IPRICE>", textBox4.Text },

            };
            help.Process(items);
            MessageBox.Show("Файл экспортирован!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            

            e.Graphics.DrawString(  textBox1.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(10, 10));
            e.Graphics.DrawString( textBox2.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(250, 10));
            e.Graphics.DrawString( textBox3.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(500, 10));
            e.Graphics.DrawString( textBox4.Text, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, new Point(700, 10));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
            PrintDialog printdialog1 = new PrintDialog();
            printdialog1.Document = printDocument1;

            DialogResult result = printdialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
            MessageBox.Show("Файл экспортирован!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
