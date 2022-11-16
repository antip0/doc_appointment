using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace doc_appointment
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            Size s = SystemInformation.PrimaryMonitorSize;
            this.Location = new Point(s.Width - this.Width, s.Height - this.Height);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 Win = new Form1();
            for (int i = Application.OpenForms.Count - 1; i >= 0; i--)
            {
                if (Application.OpenForms[i].Name != "Form1")
                    Application.OpenForms[i].Close();
            }
            Win.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 Win = new Form3();
            Win.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 Win = new Form4();
            Win.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 Win = new Form5();
            Win.Show();
        }
    }
}
