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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT id_doctor FROM doctors_auth WHERE login ='" + textBox1.Text + "' and password = '" + textBox2.Text + "';";
            MySqlConnection connection = DBUtils.GetDBConnection();
            try
            {
                connection.Open();
                MySqlCommand cmDB = new MySqlCommand(query, connection);
                int result = 0;
                result = Convert.ToInt32(cmDB.ExecuteScalar());
                if (result >= 1)
                {
                    MessageBox.Show("Добро пожаловать, " + textBox1.Text + "!");
                    Form2 Win = new Form2();
                    Win.Owner = this;
                    this.Hide();
                    Win.Show();
                    textBox1.Clear();
                    textBox2.Clear();
                    cmDB.ExecuteNonQuery();
                }
                else if (String.IsNullOrWhiteSpace(textBox1.Text) && String.IsNullOrWhiteSpace(textBox2.Text))
                {
                    label3.Visible = true;
                    label3.Text = "Поля Логин и Пароль не заполнены!";
                }
                else if (String.IsNullOrWhiteSpace(textBox1.Text))
                {
                    label3.Visible = true;
                    label3.Text = "Поле Логин не заполнено!";
                }
                else if (String.IsNullOrWhiteSpace(textBox2.Text))
                {
                    label3.Visible = true;
                    label3.Text = "Поле Пароль не заполнено!";
                }
                else
                {
                    label3.Visible = true;
                    label3.Text = "Неверный Логин или Пароль!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть программу?", "Выход", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }

        }
    }
}
