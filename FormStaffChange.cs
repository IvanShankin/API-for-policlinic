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
    public partial class FormStaffChange : Form
    {
        private FormStaff form1;
        public FormStaffChange(FormStaff staff, int id,string fio,string phone,string salary,string post,string str)
        {
            InitializeComponent();
            this.id = id;
            this.form1 = staff;
            this.str = str;
            textBoxFIO.Text = fio;
            maskedTextBoxTelephone.Text = phone;
            textBoxSalary.Text = salary;
            textBoxPost.Text = post;
        }
        int id;
        string str;

        private void FormStaffChange_Load(object sender, EventArgs e)
        { }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxFIO.Text == "" || textBoxPost.Text == "" || textBoxSalary.Text == "" || !maskedTextBoxTelephone.MaskCompleted)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            //считываем данные
            string fio = textBoxFIO.Text.ToString();
            string phone = maskedTextBoxTelephone.Text.ToString();
            string salary = textBoxSalary.Text.ToString();
            string post = textBoxPost.Text.ToString();
           
            //соеденение с БД
            string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаём новое соеденение 

            //выполнение запроса к БД
            dbConnection.Open();//открытие соеденения
            string query = "";
            if (str == "add")
            {
                query = "INSERT INTO staff VALUES(" + id + ",'" + fio + "','" + phone + "','" + salary + "','" + post + "')";//сам запрос
            }
            else 
            {
                query = "UPDATE staff SET FIO = '" + fio + "',telephone = '" + phone + "',salary = '" + salary + "',post = '" + post + "' WHERE ID = " + id;
            }
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);// команда

            //выполнение запроса 
            if (dbCommand.ExecuteNonQuery() != 1)
            { MessageBox.Show("Ошибка выполнения запроса!", "Внимание!"); dbConnection.Close(); Close(); return; }
            else
            { MessageBox.Show("Успешно!", "Готово!", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            dbConnection.Close();
            
            form1.setDGV(fio,phone,salary,post,str);
            Close();
        }

        private void textBoxSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBoxSalary_TextChanged(object sender, EventArgs e)
        {
            string text = textBoxSalary.Text;
            if (text.Length > 0)
            {
                text = string.Format("{0:#,##0.00}", double.Parse(text));//формат ввода 
                textBoxSalary.Text = text ;
                textBoxSalary.SelectionStart = text.Length - 3; // Переместить курсор перед запятой
            }
        }

    }
}
