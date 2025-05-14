using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppPolyclinic
{
    public partial class FormPatients : Form
    {
        public FormPatients(string FIODoctor)
        {
            InitializeComponent();
            this.FIODoctor = FIODoctor;
        }


        int id = 0;
        string FIODoctor = "";
        string str = "";
        int index = 0;//отображает текущий index выбранной строки в dataGrideView
        bool noClose = false;

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormPatients_Load(object sender, EventArgs e)
        {

            if (FIODoctor != "no")
            {
                buttonStaff.Visible = false;
                buttonAnalyzes.Visible = false;
                button3.Visible = false;
                buttonChangePassword.Visible = false;

                string connectionStringDoctor = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
                OleDbConnection dbConnectionDoctor = new OleDbConnection(connectionStringDoctor);

                dbConnectionDoctor.Open();
                string queryDoctor = "SELECT * FROM patients WHERE doctorFIO ='"+ FIODoctor +"'";
                OleDbCommand dbCommandDoctor = new OleDbCommand(queryDoctor, dbConnectionDoctor);
                OleDbDataReader dbReaderDoctor = dbCommandDoctor.ExecuteReader();

                if (dbReaderDoctor.HasRows == false)
                {
                    MessageBox.Show("На сегодня у вас нету записей", "Внимаение!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    while (dbReaderDoctor.Read())
                    {
                        dataGridView1.Rows.Add(dbReaderDoctor["ID"], dbReaderDoctor["patientsFIO"], dbReaderDoctor["doctorFIO"], dbReaderDoctor["diagnosis"], dbReaderDoctor["analyzes"], dbReaderDoctor["treatment"], dbReaderDoctor["dateOfAdmission"], dbReaderDoctor["telephone"], dbReaderDoctor["address"], dbReaderDoctor["dateOfBirth"]);
                        id++;
                    }
                }

                dbReaderDoctor.Close();
                dbConnectionDoctor.Close();
                return;
            }    

            string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = "SELECT * FROM patients";
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
                    dataGridView1.Rows.Add(dbReader["ID"], dbReader["patientsFIO"], dbReader["doctorFIO"], dbReader["diagnosis"], dbReader["analyzes"], dbReader["treatment"], dbReader["dateOfAdmission"], dbReader["telephone"], dbReader["address"], dbReader["dateOfBirth"]);
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
            
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 4)//при нажатии на анализы
                {
                    FormAnalyzFromPatients analyz = new FormAnalyzFromPatients(this,id,dataGridView1.Rows[index].Cells[1].Value.ToString(), dataGridView1.Rows[index].Cells[3].Value.ToString(), dataGridView1.Rows[index].Cells[6].Value.ToString());
                    analyz.ShowDialog();
                }
                if (e.ColumnIndex == 5)//при нажатии на лечение
                {
                    FormTreatment treatment = new FormTreatment(this, id, dataGridView1.Rows[index].Cells[1].Value.ToString(), dataGridView1.Rows[index].Cells[3].Value.ToString(), dataGridView1.Rows[index].Cells[6].Value.ToString());
                    treatment.ShowDialog();
                }
               
            }

            
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //соеденение с БД
            string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            //выполнение запроса к БД
            dbConnection.Open();
            string query = "SELECT * FROM patients";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

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

            FormPatientsChange add = new FormPatientsChange(this, id, "add");
            add.ShowDialog();
        }
        public void setDGV(string FIOPatients, string FIODoctor, string diagnosis, string dateOfAdmission, string telephone, string address, string dateOfBirth, string str)
        {
            if (index < dataGridView1.Rows.Count)
            { dataGridView1.Rows[index].Selected = false; }//на тот случий если убирать выделение неоткуда 
            if (str == "add")
            {
                dataGridView1.Rows.Add();
                index = dataGridView1.Rows.Count - 1;
            }

            dataGridView1.Rows[index].Cells[0].Value = id;
            dataGridView1.Rows[index].Cells[1].Value = FIOPatients;
            dataGridView1.Rows[index].Cells[2].Value = FIODoctor;
            dataGridView1.Rows[index].Cells[3].Value = diagnosis;
            dataGridView1.Rows[index].Cells[4].Value = "Нет";
            dataGridView1.Rows[index].Cells[5].Value = "Нет";
            dataGridView1.Rows[index].Cells[6].Value = dateOfAdmission;
            dataGridView1.Rows[index].Cells[7].Value = telephone;
            dataGridView1.Rows[index].Cells[8].Value = address;
            dataGridView1.Rows[index].Cells[9].Value = dateOfBirth;
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            { MessageBox.Show("Пожалуйста Выберите только одну строку", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            FormPatientsChange change = new FormPatientsChange(this, id, dataGridView1.Rows[index].Cells[1].Value.ToString(), dataGridView1.Rows[index].Cells[2].Value.ToString(), dataGridView1.Rows[index].Cells[3].Value.ToString(),
                dataGridView1.Rows[index].Cells[6].Value.ToString(), dataGridView1.Rows[index].Cells[7].Value.ToString(), dataGridView1.Rows[index].Cells[8].Value.ToString(), dataGridView1.Rows[index].Cells[9].Value.ToString(), "change");
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
                string query = "DELETE FROM patients WHERE ID = " + id;
                string queryAnalyz = "DELETE FROM analyzesForPatients WHERE ID = " + id;
                string queryTreatment = "DELETE FROM treatment WHERE ID = " + id;

                OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
                OleDbCommand dbCommandAnalyz = new OleDbCommand(queryAnalyz, dbConnection);
                OleDbCommand dbCommandTreatment = new OleDbCommand(queryTreatment, dbConnection);


                if (dbCommand.ExecuteNonQuery() != 1 || dbCommandAnalyz.ExecuteNonQuery() != 1 || dbCommandTreatment.ExecuteNonQuery() != 1)
                { MessageBox.Show("Ошибка выполнения запроса!", "Внимание!"); dbConnection.Close(); return; }
                else
                {
                    int count = 0;
                    string queryCount = "SELECT * FROM patients";
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
                    string queryUpdate = "UPDATE patients SET ID = 0 WHERE ID = " + id;
                    string queryUpdateAnalyz = "UPDATE analyzesForPatients SET ID = 0 WHERE ID = " + id;
                    string queryUpdateTreatment = "UPDATE treatment SET ID = 0 WHERE ID = " + id;
                    id++;
                    for (int i = id - 1; i < count; i++, id++)
                    {
                        queryUpdate = "UPDATE patients SET ID = " + i + " WHERE ID = " + id;
                        queryUpdateAnalyz = "UPDATE analyzesForPatients SET ID = "+ i +" WHERE ID = " + id;
                        queryUpdateTreatment = "UPDATE treatment SET ID = "+ i +" WHERE ID = " + id;

                        OleDbCommand dbCommandUpdate = new OleDbCommand(queryUpdate, dbConnection);
                        OleDbCommand dbCommandUpdateAnalyz = new OleDbCommand(queryUpdateAnalyz, dbConnection);
                        OleDbCommand dbCommandUpdateTreatment = new OleDbCommand(queryUpdateTreatment, dbConnection);

                        if (dbCommandUpdate.ExecuteNonQuery() != 1 || dbCommandUpdateAnalyz.ExecuteNonQuery() != 1 || dbCommandUpdateTreatment.ExecuteNonQuery() != 1)
                        { MessageBox.Show("Ошибка выполнения запроса!", "Внимание!"); dbConnection.Close(); return; }
                       
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

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            FormPatients_Load(sender, e);
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
            string query = "SELECT * FROM patients WHERE patientsFIO LIKE '%" + name + "%'";
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
                    dataGridView1.Rows.Add(dbReader["ID"], dbReader["patientsFIO"], dbReader["doctorFIO"], dbReader["diagnosis"], dbReader["analyzes"], dbReader["treatment"], dbReader["dateOfAdmission"], dbReader["telephone"], dbReader["address"], dbReader["dateOfBirth"]);
                }
            }//если данные считались 

            //закрытие соеденения с БД
            dbReader.Close();
            dbConnection.Close();
        }

        private void FormPatients_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (noClose == false)
                Application.Exit();
        }

        private void buttonData_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Пожалуйста выберите только одну строку!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
        public void setDGVAndBD(string str)
        {
            
            string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаём новое соеденение 

            dbConnection.Open();
            string query = "";
            if (str == "analyzes")
            {
                query = "UPDATE patients SET analyzes = 'Готово' WHERE ID = " + id;
                dataGridView1.Rows[index].Cells[4].Value = "Готово";
            }
            else 
            {
                query = "UPDATE patients SET treatment = 'Готово' WHERE ID = " + id;
                dataGridView1.Rows[index].Cells[5].Value = "Готово";
            }
            
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

            //выполнение запроса 
            if (dbCommand.ExecuteNonQuery() != 1)
            { MessageBox.Show("Ошибка выполнения запроса!", "Внимание!"); dbConnection.Close(); return; }
            else
            { MessageBox.Show("Успешно!", "Готово!", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            //закрытие соединения с БД
            dbConnection.Close();
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

        private void button3_Click(object sender, EventArgs e)
        {
            noClose = true;
            FormReport report = new FormReport();
            this.Close();
            report.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormChangePassword changePassword = new FormChangePassword();
            changePassword.ShowDialog();
        }
    }
}
