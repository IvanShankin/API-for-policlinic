using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppPolyclinic
{
    public partial class FormChangePassword : Form
    {
        public FormChangePassword()
        {
            InitializeComponent();
        }
        string initiallyLogin = "";
        private void buttonCansel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormChangePassword_Load(object sender, EventArgs e)
        {
            string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = "SELECT * FROM loginAndPassword";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

           
            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Данные не найдены", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                dbReader.Read();
                initiallyLogin = dbReader["loginUser"].ToString();
                textBoxLoginRegistrator.Text = dbReader["loginUser"].ToString();
                textBoxPasswordRegistrator.Text = dbReader["passwordUser"].ToString();
                dbReader.Read();
                textBoxPasswordDoctor.Text = dbReader["passwordUser"].ToString();
            }

            dbReader.Close();
            dbConnection.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            if (textBoxLoginRegistrator.Text == "" || textBoxPasswordRegistrator.Text == "" || textBoxPasswordDoctor.Text == "")
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            string loginRegistrator = textBoxLoginRegistrator.Text.ToString();
            string PasswordRegistrator = textBoxPasswordRegistrator.Text.ToString();
            string PasswordDoctor = textBoxPasswordDoctor.Text.ToString();

            string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаём новое соеденение 

            dbConnection.Open();

            string query = "UPDATE loginAndPassword SET loginUser = '" + loginRegistrator + "', passwordUser = '" + PasswordRegistrator + "' WHERE loginUser = '" + initiallyLogin + "'";
            string query2 = "UPDATE loginAndPassword SET passwordUser = '" + PasswordDoctor + "' WHERE loginUser = '2'";

            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbCommand dbCommand2 = new OleDbCommand(query2, dbConnection);

            if (dbCommand.ExecuteNonQuery() != 1)
            { MessageBox.Show("Ошибка выполнения запроса!", "Внимание!"); dbConnection.Close(); Close(); return; }

            if (dbCommand2.ExecuteNonQuery() != 1)
            { MessageBox.Show("Ошибка выполнения запроса!", "Внимание!"); dbConnection.Close(); Close(); return; }
            else
            { MessageBox.Show("Успешно!", "Готово!", MessageBoxButtons.OK, MessageBoxIcon.Information); }


            dbConnection.Close();


            Close();
        }
    }
}
