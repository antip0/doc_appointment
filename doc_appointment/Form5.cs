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
    public partial class Form5 : Form
    {
        private static Form5 alreadyOpened = null;
        public Form5()
        {
            if (alreadyOpened != null && !alreadyOpened.IsDisposed)
            {
                MessageBox.Show("Вкладка 'Список врачей' уже открыта!");
                alreadyOpened.Focus();       
                Shown += (s, e) => this.Close(); 
                return;
            }

            alreadyOpened = this;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "select * from doctors";
            MySqlConnection connection = DBUtils.GetDBConnection();
            try
            {
                connection.Open();
                MySqlCommand cmDB = new MySqlCommand(query, connection);
                MySqlDataAdapter mySql_dataAdapter = new MySqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                mySql_dataAdapter.Fill(table);
                dataGridView1.DataSource = table;
                textBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "select * from doctors where id_doctor = '" + textBox1.Text + "';";
            string query1 = "select * from doctors where fio_doctor = '" + textBox2.Text + "';";
            string query2 = "select * from doctors where specialization = '" + textBox3.Text + "';";
            string query3 = "select * from doctors where num_cabinet = '" + textBox4.Text + "';";
            MySqlConnection connection = DBUtils.GetDBConnection();
            try
            {
                connection.Open();
                if (textBox1.Text != "")
                {
                    MySqlCommand cmDB = new MySqlCommand(query, connection);
                    MySqlDataAdapter mySql_dataAdapter = new MySqlDataAdapter(query, connection);
                    DataTable table = new DataTable();
                    mySql_dataAdapter.Fill(table);
                    dataGridView1.DataSource = table;
                    textBox1.Clear();
                }
                else if (textBox2.Text != "")
                {
                    MySqlCommand cmDB = new MySqlCommand(query, connection);
                    MySqlDataAdapter mySql_dataAdapter = new MySqlDataAdapter(query1, connection);
                    DataTable table = new DataTable();
                    mySql_dataAdapter.Fill(table);
                    dataGridView1.DataSource = table;
                    textBox2.Clear();
                }
                else if (textBox3.Text != "")
                {
                    MySqlCommand cmDB = new MySqlCommand(query, connection);
                    MySqlDataAdapter mySql_dataAdapter = new MySqlDataAdapter(query2, connection);
                    DataTable table = new DataTable();
                    mySql_dataAdapter.Fill(table);
                    dataGridView1.DataSource = table;
                    textBox3.Clear();
                }
                else if (textBox4.Text != "")
                {
                    MySqlCommand cmDB = new MySqlCommand(query, connection);
                    MySqlDataAdapter mySql_dataAdapter = new MySqlDataAdapter(query3, connection);
                    DataTable table = new DataTable();
                    mySql_dataAdapter.Fill(table);
                    dataGridView1.DataSource = table;
                    textBox4.Clear();
                }   
            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                connection.Close();
            }
        }
    }
}
