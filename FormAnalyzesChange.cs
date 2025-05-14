using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace WindowsFormsAppPolyclinic
{
    public partial class FormAnalyzesChange : Form
    {
        private FormAnalyzes form1;
        public FormAnalyzesChange(FormAnalyzes form1, int id, string name, string prise, string description, string str)
        {
            InitializeComponent();
            this.id = id;
            this.form1 = form1;
            this.str = str;
            textBoxName.Text = name;
            textBoxPrise.Text = prise;
            richTextBoxDescription.Text = description;
        }
        int id;
        string str;
        private void textBoxSalary_TextChanged(object sender, EventArgs e)
        {
            string text = textBoxPrise.Text;
            if (text.Length > 0)
            {
                text = string.Format("{0:#,##0.00}", double.Parse(text));//формат ввода 
                textBoxPrise.Text = text;
                textBoxPrise.SelectionStart = text.Length - 3; // Переместить перед запятой
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxName.Text == "" || textBoxPrise.Text == "" || richTextBoxDescription.Text == "" )
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            //считываем данные
            string name = textBoxName.Text.ToString();
            string prise = textBoxPrise.Text.ToString();
            string description = richTextBoxDescription.Text.ToString();

            //соеденение с БД
            string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаём новое соеденение 

            //выполнение запроса к БД
            dbConnection.Open();//открытие соеденения
            string query = "";
            if (str == "add")
            {
                query = "INSERT INTO analyzes VALUES(" + id + ",'" + name + "','" + prise + "','" + description + "')";//сам запрос
            }
            else
            {
                query = "UPDATE analyzes SET nameAnaliz = '" + name + "', prise = '" + prise + "',description = '" + description + "' WHERE ID = " + id;
            }
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);// команда

            //выполнение запроса 
            if (dbCommand.ExecuteNonQuery() != 1)//этот метот возвращает кол-во добавленных строк 
            { MessageBox.Show("Ошибка выполнения запроса!", "Внимание!"); dbConnection.Close(); Close(); return; }
            else
            { MessageBox.Show("Успешно!", "Готово!", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            //закрытие соединения с БД
            dbConnection.Close();

            form1.setDGV(name, prise, description, str);
            Close();
        }

        private void textBoxPrise_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
