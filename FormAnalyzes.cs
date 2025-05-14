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

namespace WindowsFormsAppPolyclinic
{
    public partial class FormAnalyzes : Form
    {
        public FormAnalyzes()
        {
            InitializeComponent();
        }

        int id = 0;
        string str = "";
        int index = 0;//отображает текущий index выбранной строки в dataGrideView
        bool noClose = false;

        private void FormAnalyzes_Load(object sender, EventArgs e)
        {
            string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = "SELECT * FROM analyzes";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Данные не найдены", "Внимаение!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                while (dbReader.Read())
                {
                    dataGridView1.Rows.Add(dbReader["ID"], dbReader["nameAnaliz"], dbReader["prise"], dbReader["description"]);
                    id++;
                }
            }
       
            dbReader.Close();
            dbConnection.Close();
        }

       

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());//узнаём ID который записан в выбранной строке 
                index = dataGridView1.CurrentRow.Index;
                dataGridView1.Rows[index].Selected = true;
            }
            //еcли данных нету в dgv и мы нажимаем на заголовок столбцов, то может выдать ошибку 
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //соеденение с БД
            string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаём новое соеденение 

            //выполнение запроса к БД
            dbConnection.Open();//открытие соеденения
            string query = "SELECT * FROM analyzes";//сам запрос
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);// команда
            OleDbDataReader dbReader = dbCommand.ExecuteReader();//считывание данных

            //проверяем данные
            if (dbReader.HasRows == false)
            {
                id = 0;
            }
            else
            {
                while (dbReader.Read())
                {
                    id = Convert.ToInt32(dbReader["ID"]);
                } 
                id++;//т.к. установить ID на 1 больше чем последний ID в БД
            }//если данные считались 
           

            //закрытие соеденения с БД
            dbReader.Close();
            dbConnection.Close();

            FormAnalyzesChange add = new FormAnalyzesChange(this,id,"","","","add");
            add.Owner = this;
            add.ShowDialog();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void setDGV(string name, string prise, string description,string str)
        {
            if (index < dataGridView1.Rows.Count)
            { dataGridView1.Rows[index].Selected = false; }//на тот случий если убирать выделение неоткуда 
            if (str == "add")
            {
                dataGridView1.Rows.Add();
                index = dataGridView1.Rows.Count - 1;
            }

            dataGridView1.Rows[index].Cells[0].Value = id;
            dataGridView1.Rows[index].Cells[1].Value = name;
            dataGridView1.Rows[index].Cells[2].Value = prise;
            dataGridView1.Rows[index].Cells[3].Value = description;
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count != 1)
            { MessageBox.Show("Пожалуйста Выберите только одну строку", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            FormAnalyzesChange change = new FormAnalyzesChange(this, id, dataGridView1.Rows[index].Cells[1].Value.ToString(), dataGridView1.Rows[index].Cells[2].Value.ToString(), dataGridView1.Rows[index].Cells[3].Value.ToString(), "change");
            change.Owner = this;
            change.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Пожалуйста выберите только одну строку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Вы действительно хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                dataGridView1.Rows[index].Selected = false;

                //соеденение с БД
                string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
                OleDbConnection dbConnection = new OleDbConnection(connectionString);

                //выполнение запроса к БД
                dbConnection.Open();
                string query = "DELETE FROM analyzes WHERE ID = " + id;

                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

                if (dbCommand.ExecuteNonQuery() != 1)
                { MessageBox.Show("Ошибка выполнения запроса!", "Внимание!"); dbConnection.Close(); return; }
                else
                {

                    int count = 0;
                    string queryCount = "SELECT * FROM analyzes";
                    OleDbCommand dbCommandCount = new OleDbCommand(queryCount, dbConnection);
                    OleDbDataReader dbReaderCount = dbCommandCount.ExecuteReader();

                    if (dbReaderCount.HasRows == false)
                    { id = 0; }
                    else
                    {
                        while (dbReaderCount.Read())
                        {
                            count++;
                        }
                    }//если данные считались 
                    dbReaderCount.Close();


                    dataGridView1.Rows.RemoveAt(index);
                    string queryUpdate = "UPDATE analyzes SET ID = 0 WHERE ID = " + id;
                    id++;
                    for (int i = id - 1; i < count; i++, id++)
                    {
                        queryUpdate = "UPDATE analyzes SET ID = " + i + " WHERE ID = " + id;
                        OleDbCommand dbCommandUpdate = new OleDbCommand(queryUpdate, dbConnection);
                        if (dbCommandUpdate.ExecuteNonQuery() != 1)
                        { MessageBox.Show("Ошибка выполнения запроса!", "Внимание!"); return; }

                        for (int j = 0; j < dataGridView1.Rows.Count; j++)
                        {
                            if (Convert.ToInt32(dataGridView1.Rows[j].Cells[0].Value) == id)
                            { dataGridView1.Rows[j].Cells[0].Value = i; }
                        }//ищем ячейку с изменённым ID в БД и если нашли то изменяем её в DGV
                    }//этот цикл меняет последовательность ID в БД и в dataGrideView
                     //меняем все id в БД которые идту после удалённого ID

                    MessageBox.Show("Данные Удалены", "Готово!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //закрытие соединения с БД
                dbConnection.Close();
            }
        }

        private void FormAnalyzes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (noClose == false)
                Application.Exit();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            FormAnalyzes_Load(sender, e);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Rows.Clear();

            //соеденение с БД
            string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            string name = textBoxNameSearch.Text;
            

            //выполнение запроса к БД
            dbConnection.Open();//открытие соеденения
            string query = "SELECT * FROM analyzes WHERE nameAnaliz LIKE '%" + name + "%'";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            //проверяем данные
            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Таких данных нет", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                while (dbReader.Read())
                {
                    dataGridView1.Rows.Add(dbReader["ID"], dbReader["nameAnaliz"], dbReader["prise"], dbReader["description"]);
                }
            }//если данные считались 

            //закрытие соеденения с БД
            dbReader.Close();
            dbConnection.Close();
        }

        private void buttonStaff_Click(object sender, EventArgs e)
        {
            noClose = true;
            FormStaff staff = new FormStaff();
            this.Close();
            staff.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            noClose = true;
            FormPatients patients = new FormPatients("no");
            this.Close();
            patients.Show();
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            noClose = true;
            FormReport report = new FormReport();
            this.Close();
            report.Show();
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            FormChangePassword changePassword = new FormChangePassword();
            changePassword.ShowDialog();
        }
    }
}
