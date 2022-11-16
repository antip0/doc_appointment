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
    public partial class Form3 : Form
    {
        private static Form3 alreadyOpened = null;
        public Form3()
        {
            // If the form already exists, and has not been closed
            if (alreadyOpened != null && !alreadyOpened.IsDisposed)
            {
                MessageBox.Show("Вкладка 'Пациенты' уже открыта!");
                alreadyOpened.Focus();        // Bring the old one to top    
                Shown += (s, e) => this.Close();  // and destroy the new one.
                return;
            }

            // Otherwise store this one as reference
            alreadyOpened = this;

            // Initialization
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            Size size = SystemInformation.PrimaryMonitorSize;
            this.Location = new Point(size.Width - size.Width, size.Height - this.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "select * from patients";
            MySqlConnection connection = DBUtils.GetDBConnection();
            try
            {
                connection.Open();
                MySqlCommand cmDB = new MySqlCommand(query, connection);
                MySqlDataAdapter mySql_dataAdapter = new MySqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                mySql_dataAdapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "select * from patients where id_patient = '" + textBox1.Text + "';";
            string query1 = "select * from patients where fio_patient = '" + textBox2.Text + "';";
            string query2 = "select * from patients where address = '" + textBox3.Text + "';";
            string query3 = "select * from patients where gender = '" + textBox4.Text + "';";
            string query4 = "select * from patients where birthday = '" + textBox5.Text + "';";
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
                else if (textBox5.Text != "")
                {
                    MySqlCommand cmDB = new MySqlCommand(query, connection);
                    MySqlDataAdapter mySql_dataAdapter = new MySqlDataAdapter(query4, connection);
                    DataTable table = new DataTable();
                    mySql_dataAdapter.Fill(table);
                    dataGridView1.DataSource = table;
                    textBox5.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string query = "select outpatient_cards.id_patient, patients.fio_patient, outpatient_cards.id_doctor, doctors.fio_doctor, outpatient_cards.id_therapy, therapy.name, outpatient_cards.visit_time, " +
                "outpatient_cards.diagnose, outpatient_cards.result_of_therapy, outpatient_cards.patient_complaints from outpatient_cards join patients on patients.id_patient = outpatient_cards.id_patient join doctors " +
                "on doctors.id_doctor = outpatient_cards.id_doctor join therapy on therapy.id_therapy = outpatient_cards.id_therapy";
            MySqlConnection connection = DBUtils.GetDBConnection();
            try
            {
                connection.Open();
                MySqlCommand cmDB = new MySqlCommand(query, connection);
                MySqlDataAdapter mySql_dataAdapter = new MySqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                mySql_dataAdapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                connection.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string query = "insert into recipes (id_patient, id_therapy, id_doctor, the_condition_of_the_use) values ('" + textBox6.Text + "', '" + textBox7.Text + "', '" + textBox8.Text + "', '" + textBox9.Text + "')";
            MySqlConnection connection = DBUtils.GetDBConnection();
            try
            {
                connection.Open();
                MySqlCommand cmDB = new MySqlCommand(query, connection);
                if (textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "")
                {                   
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    cmDB.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                connection.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string script = "select * from recipes";
            MySqlConnection connection = DBUtils.GetDBConnection();
            try
            {
                connection.Open();
                MySqlCommand cmDB = new MySqlCommand(script, connection);
                MySqlDataAdapter mySql_dataAdapter = new MySqlDataAdapter(script, connection);
                DataTable table = new DataTable();
                mySql_dataAdapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                connection.Close();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string script = "select * from therapy";
            MySqlConnection connection = DBUtils.GetDBConnection();
            try
            {
                connection.Open();
                MySqlCommand cmDB = new MySqlCommand(script, connection);
                MySqlDataAdapter mySql_dataAdapter = new MySqlDataAdapter(script, connection);
                DataTable table = new DataTable();
                mySql_dataAdapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                connection.Close();
            }
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            string script = "update recipes set id_patient = '" + textBox13.Text + "', id_therapy = '" + textBox12.Text + "', id_doctor = '" + textBox11.Text + "', " +
                "the_condition_of_the_use = '" + textBox10.Text + "' where id_patient = '" + textBox13.Text + "'";
            MySqlConnection connection = DBUtils.GetDBConnection();
            try
            {
                connection.Open();
                MySqlCommand cmDB = new MySqlCommand(script, connection);
                if (textBox13.Text != "" && textBox12.Text != "" && textBox11.Text != "" && textBox10.Text != "")
                {
                    textBox13.Clear();
                    textBox12.Clear();
                    textBox11.Clear();
                    textBox10.Clear();
                    cmDB.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Непредвиденная ошибка!");
                connection.Close();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string query = "delete from recipes where id_patient = '" + textBox19.Text + "'";
            MySqlConnection connection = DBUtils.GetDBConnection();
            try
            {
                connection.Open();
                MySqlCommand cmDB = new MySqlCommand(query, connection);
                if (textBox19.Text != "")
                {
                    textBox19.Clear();
                    cmDB.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Непредвиденная ошибка!");
                connection.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string query = "insert into therapy (id_therapy, name) values ('" + textBox14.Text + "', '" + textBox15.Text + "')";
            MySqlConnection connection = DBUtils.GetDBConnection();
            try
            {
                connection.Open();
                MySqlCommand cmDB = new MySqlCommand(query, connection);
                if (textBox14.Text != "" && textBox15.Text != "")
                {
                    textBox14.Clear();
                    textBox15.Clear();
                    cmDB.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Непредвиденная ошибка!");
                connection.Close();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string query = "update therapy set id_therapy = '" + textBox17.Text + "', name = '" + textBox16.Text + "' where id_therapy = '" + textBox17.Text + "'";
            MySqlConnection connection = DBUtils.GetDBConnection();
            try
            {
                connection.Open();
                MySqlCommand cmDB = new MySqlCommand(query, connection);
                if (textBox17.Text != "" && textBox16.Text != "")
                {
                    textBox17.Clear();
                    textBox16.Clear();
                    cmDB.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Непредвиденная ошибка!");
                connection.Close();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string query = "delete from therapy where id_therapy = '" + textBox18.Text + "'";
            MySqlConnection connection = DBUtils.GetDBConnection();
            try
            {
                connection.Open();
                MySqlCommand cmDB = new MySqlCommand(query, connection);
                if (textBox18.Text != "")
                {
                    textBox18.Clear();
                    cmDB.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Непредвиденная ошибка!");
                connection.Close();
            }
        }
    }
}
