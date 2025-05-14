using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsAppPolyclinic
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string login = "";
        string password = "";
        string passwordDoctor = "";
        bool registrator = true;

        private void button1_Click(object sender, EventArgs e)
        {


            if (registrator == true)
            {
                if (textBoxLogin.Text == "" || textBoxPassword.Text == "")
                {
                    MessageBox.Show("Строка с логином и паролем обязательна для заполнения!", "Внимание!");
                    return;
                }

                if (textBoxPassword.Text == passwordDoctor)
                {
                    string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
                    OleDbConnection dbConnection = new OleDbConnection(connectionString);

                    dbConnection.Open();
                    string query = "SELECT [FIO] FROM staff";
                    OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
                    OleDbDataReader dbReader = dbCommand.ExecuteReader();

                    if (dbReader.HasRows == false)
                    {
                        MessageBox.Show("Введён неверный логин или пароль!", "Внимаение!");
                    }
                    else
                    {
                        while(dbReader.Read())
                        {
                            string FIODoctor = dbReader["FIO"].ToString();

                            if (textBoxLogin.Text.ToString() == FIODoctor)
                            {
                                FormPatients patients = new FormPatients(FIODoctor);
                                this.Hide();
                                patients.Show();
                            }
                        }
                        dbReader.Close();
                        dbConnection.Close();
                        return;
                    }

                    dbReader.Close();
                    dbConnection.Close();

                }

                if (textBoxLogin.Text == login || textBoxPassword.Text == password)
                {
                    FormMain mainForm = new FormMain();
                    this.Hide();
                    mainForm.Show();
                }
                else {
                    MessageBox.Show("Введён неверный пароль", "Внимание!");
                    return;
                }
            }
            else
            {
                if (textBoxPassword.Text == "admin")
                {
                    FormMain mainForm = new FormMain();
                    this.Hide();
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Введён неврный пароль!", "Внимание!");
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = "SELECT * FROM loginAndPassword";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            //проверяем данные
            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Данные не найдены зайдите через администратора!", "Внимаение!");
            }
            else
            {
                dbReader.Read();
                login = dbReader["loginUser"].ToString();
                password = dbReader["passwordUser"].ToString();
                dbReader.Read();//смещаемся на строку ниже
                passwordDoctor = dbReader["passwordUser"].ToString();
            }

            dbReader.Close();
            dbConnection.Close();

            buttonMenedger_Click(sender, e);
        }
        private void buttonMenedger_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBoxLogin.Visible = true;
            this.textBoxPassword.Location = new System.Drawing.Point(177, 99);
            this.label2.Location = new System.Drawing.Point(66, 99);
            this.button2.Location = new System.Drawing.Point(334, 99);
            this.buttonNoVisible.Location = new System.Drawing.Point(334, 99);

            buttonAdmin.BackColor = SystemColors.Control;
            buttonMenedger.BackColor = Color.White;

            registrator = true;
        }
        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBoxLogin.Visible = false;
            this.textBoxPassword.Location = new System.Drawing.Point(177, 80);
            this.label2.Location = new System.Drawing.Point(66, 80);
            this.button2.Location = new System.Drawing.Point(334, 80);
            this.buttonNoVisible.Location = new System.Drawing.Point(334, 80);

            buttonMenedger.BackColor = SystemColors.Control;
            buttonAdmin.BackColor = Color.White;

            registrator = false;
        }

        private void buttonNoVisible_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = false;
            buttonNoVisible.Visible = false;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = true;
            button2.Visible = false;
            buttonNoVisible.Visible = true;
        }
    }
}
