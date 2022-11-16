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
    public partial class Form4 : Form
    {
        private static Form4 alreadyOpened = null;
        public Form4()
        {
            if (alreadyOpened != null && !alreadyOpened.IsDisposed)
            {
                MessageBox.Show("Вкладка 'Запись' уже открыта!");
                alreadyOpened.Focus();
                Shown += (s, e) => this.Close();
                return;
            }

            alreadyOpened = this;

            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            Size size = SystemInformation.PrimaryMonitorSize;
            this.Location = new Point(size.Width - this.Width, size.Height - size.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "select doctors.id_doctor, fio_doctor, patients.id_patient, fio_patient, birthday, visit_time " +
                "from tickets join doctors on doctors.id_doctor = tickets.id_doctor join patients on patients.id_patient = tickets.id_patient WHERE fio_doctor ='" + textBox1.Text + "';";
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                connection.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "insert into tickets (id_patient, id_doctor, visit_time) values ('" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')";
            MySqlConnection connection = DBUtils.GetDBConnection();
            try
            {
                connection.Open();
                MySqlCommand cmDB = new MySqlCommand(query, connection);
                if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    cmDB.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка!" + Environment.NewLine + ex.Message);
                connection.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "delete from tickets where id_patient = '" + textBox8.Text + "';";
            MySqlConnection connection = DBUtils.GetDBConnection();
            try
            {
                connection.Open();
                MySqlCommand cmDB = new MySqlCommand(query, connection);
                if (textBox8.Text != "")
                {
                    textBox8.Clear();
                    cmDB.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Непредвиденная ошибка!");
                connection.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string script = "select patients.id_patient, fio_patient, doctors.id_doctor, fio_doctor, visit_time, birthday from tickets join patients on patients.id_patient = tickets.id_patient join doctors on doctors.id_doctor = tickets.id_doctor";
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

        private void button4_Click(object sender, EventArgs e)
        {
            string script = "update tickets set id_patient = '" + textBox7.Text + "', id_doctor = '" + textBox6.Text + "', " +
            "visit_time = '" + textBox5.Text + "' where id_patient = '" + textBox7.Text + "'";
            MySqlConnection connection = DBUtils.GetDBConnection();
            try
            {
                connection.Open();
                MySqlCommand cmDB = new MySqlCommand(script, connection);
                if (textBox7.Text != "" && textBox6.Text != "" && textBox5.Text != "")
                {                                               
                    textBox7.Clear();
                    textBox6.Clear();
                    textBox5.Clear();
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
