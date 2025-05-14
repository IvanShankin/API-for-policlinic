using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.Remoting.Messaging;//задаём имя т.к. мужик из видео сказал что это может привести к ошибке совместимости с System.data
using System.Windows.Forms;

namespace WindowsFormsAppPolyclinic
{
    public partial class FormReport : Form
    {
        public FormReport()
        {
            InitializeComponent();
        }
        int id = 0;//отображает id у выбронной строки
        int index = 0;//отображает текущий index выбранной строки в dataGrideView
        bool noClose = false;
        private void FormReport_Load(object sender, EventArgs e)
        {
            //соеденение с БД
            string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаём новое соеденение 

            //выполнение запроса к БД
            dbConnection.Open();//открытие соеденения
            string query = "SELECT * FROM report";//сам запрос
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);// команда
            OleDbDataReader dbReader = dbCommand.ExecuteReader();//считывание данных

            //проверяем данные
            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Данные не найдены", "Внимание!");
            }
            else
            {
                while (dbReader.Read())
                {
                    dataGridView1.Rows.Add(dbReader["ID"], dbReader["FIOPatients"], dbReader["FIODoctor"], dbReader["dateAcceptance"]);
                    id++;
                }
            }//если данные считались 


            //закрытие соеденения с БД
            dbReader.Close();
            dbConnection.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());//узнаём выбранную строку 

            index = id;

            dataGridView1.Rows[index].Selected = true;
        }

        private void comboBoxTypeTabel_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (comboBoxTypeTabel.SelectedIndex)//отображает выбранный индекс
            {
                case 0:
                    dataGridView1.Rows.Clear();
                    ColumnPatientsFIO.Visible = true;
                    ColumnFIODoctor.Width -= 345;
                    ColumnDate.HeaderText = "Дата приёма";
                    FormReport_Load(sender, e);
                    break;
                case 1:
                    dataGridView1.Rows.Clear();
                    string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
                    OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаём новое соеденение 

                    //выполнение запроса к БД
                    dbConnection.Open();//открытие соеденения
                    string query = "SELECT * FROM staff";//сам запрос
                    OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);// команда
                    OleDbDataReader dbReader = dbCommand.ExecuteReader();//считывание данных

                    //проверяем данные
                    if (dbReader.HasRows == false)
                    {
                        MessageBox.Show("Данные не найдены", "Внимание!");
                    }
                    else
                    {
                        ColumnPatientsFIO.Visible = false;
                        ColumnFIODoctor.Width += 345;
                        ColumnDate.HeaderText = "Количество принятых пациентов";
                        for (int i = 0; dbReader.Read(); i++)
                        {
                            dataGridView1.Rows.Add(0, 0, dbReader["FIO"], 0);

                            string query1 = "SELECT * FROM patients WHERE doctorFIO = '" + dataGridView1.Rows[i].Cells[2].Value.ToString() + "'";
                            OleDbCommand dbCommand1 = new OleDbCommand(query1, dbConnection);
                            OleDbDataReader dbReader1 = dbCommand1.ExecuteReader();

                            for (int j = 1; dbReader1.Read(); j++)
                            {
                                dataGridView1.Rows[i].Cells[3].Value = j;
                            }
                            dbReader1.Close();
                        }
                    }//если данные считались 


                    //закрытие соеденения с БД
                    dbReader.Close();
                    dbConnection.Close();
                    break;
            }
        }

        private void FormReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (noClose == false)
                Application.Exit();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            switch (comboBoxTypeTabel.SelectedIndex)
            {
                case 0:
                    dataGridView1.Rows.Clear();
                    string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
                    OleDbConnection dbConnection = new OleDbConnection(connectionString);

                    dbConnection.Open();
                    string query = "SELECT * FROM report";

                    OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

                    OleDbDataReader dbReader = dbCommand.ExecuteReader();

                    //проверяем данные
                    if (dbReader.HasRows == false)
                    {
                        MessageBox.Show("Данные не найдены", "Внимание!");
                    }
                    else
                    {
                        while (dbReader.Read())
                        {
                            if (Convert.ToDateTime(dbReader["dateAcceptance"]) >= dateTimePickerWith.Value && Convert.ToDateTime(dbReader["dateAcceptance"]) <= dateTimePickerBy.Value)
                            {
                                dataGridView1.Rows.Add(dbReader["ID"], dbReader["FIOPatients"], dbReader["FIODoctor"], dbReader["dateAcceptance"]);
                                id++;
                            }
                        }
                    }

                    dbReader.Close();
                    dbConnection.Close();

                    if (dataGridView1.Rows.Count == 0)
                    {
                        MessageBox.Show("Данных за этот период нету!", "Внимание!");
                    }
                    break;
                case 1:
                    dataGridView1.Rows.Clear();
                   
                    string connectionString2 = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
                    OleDbConnection dbConnection2 = new OleDbConnection(connectionString2);

                    dbConnection2.Open();
                    string query2 = "SELECT * FROM staff";
                    OleDbCommand dbCommand2 = new OleDbCommand(query2, dbConnection2);
                    OleDbDataReader dbReader2 = dbCommand2.ExecuteReader();

                    if (dbReader2.HasRows == false)
                    {
                        MessageBox.Show("Данные не найдены", "Внимание!");
                    }
                    else
                    {
                        for (int i = 0; dbReader2.Read(); i++)
                        {
                            dataGridView1.Rows.Add(0, 0 , dbReader2["FIO"], 0);

                            string query3 = "SELECT * FROM report WHERE FIODoctor = '" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "'";
                            OleDbCommand dbCommand3 = new OleDbCommand(query3, dbConnection2);
                            OleDbDataReader dbReader3 = dbCommand3.ExecuteReader();

                            DateTime date;
                            for (int j = 1; dbReader3.Read();)
                            {
                                date = Convert.ToDateTime(dbReader3["dateAcceptance"]);
                                if (date >= dateTimePickerWith.Value && date <= dateTimePickerBy.Value)
                                {
                                    dataGridView1.Rows[i].Cells[3].Value = j;
                                    j++;
                                }
                            }
                            dbReader3.Close();
                        }
                    }
                    break;
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            exApp.Workbooks.Add();
            Excel.Worksheet wsh = (Excel.Worksheet)exApp.ActiveSheet;

            switch (comboBoxTypeTabel.SelectedIndex)
            {
                case 0:
                    for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                    {
                        for (int j = 0; j <= dataGridView1.Columns.Count - 1; j++)
                        {
                            wsh.Cells[1, j + 1] = dataGridView1.Columns[j].HeaderText.ToString();//записываем название столбцов в excel
                            wsh.Cells[i + 2, j + 1] = dataGridView1[j, i].Value.ToString(); //записываем сами строки в exel
                                                                                            //(прибовляем +2 т.к.в excel отсчёт строки начинается с 1 и под 1 индексом у нас название столбца)
                        }
                    }
                    break;
                case 1:
                    for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                    {
                        for (int j = 2, q = 0; q < 2; j = 3, q++)
                        {
                            wsh.Cells[1, q + 1] = dataGridView1.Columns[j].HeaderText.ToString();
                            wsh.Cells[i + 2, q + 1] = dataGridView1[j, i].Value.ToString();
                        }
                    }
                    break;
            }//использую разные варианты выгрузки в excel т.к. таблица может отображаться по разному 

            exApp.Visible = true;
        }
 private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            noClose = true;
            FormPatients patients = new FormPatients("no");
            this.Close();
            patients.Show();
        }

       

        private void buttonStaff_Click(object sender, EventArgs e)
        {
            noClose = true;
            FormStaff staff = new FormStaff();
            this.Close();
            staff.Show();
        }

        private void buttonAnalyzes_Click(object sender, EventArgs e)
        {
            noClose = true;
            FormAnalyzes analiz = new FormAnalyzes();
            this.Close();
            analiz.Show();
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            FormChangePassword changePassword = new FormChangePassword();
            changePassword.ShowDialog();
        }
    }
}
