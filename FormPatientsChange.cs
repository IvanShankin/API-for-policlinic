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
    public partial class FormPatientsChange : Form
    {
        private FormPatients form1;
        int id;
        string str;
        public FormPatientsChange(FormPatients form1, int id, string fioPatients, string fioDoctor, string diagnosis, string dateOfAdmission, string telephone, string address, string dateOfBirth, string str)
        {
            InitializeComponent();
            this.id = id;
            this.form1 = form1;
            this.str = str;

            textBoxFIOPatients.Text = fioPatients;
            comboBoxFIODoctor.Text = fioDoctor;
            richTextBoxDiagnosis.Text = diagnosis;
            dateTimePickerDateOfAdmission.Text = dateOfAdmission;
            maskedTextBoxTelephone.Text = telephone;
            textBoxAddress.Text = address;
            dateTimePickerDateOfBirth.Text = dateOfBirth;

        }
        public FormPatientsChange(FormPatients form1, int id, string str)
        {
            InitializeComponent();
            this.id = id;
            this.form1 = form1;
            this.str = str;
        }

        private void FormPatientsChange_Load(object sender, EventArgs e)
        {
           
            string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = "SELECT * FROM staff";
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            //проверяем данные
            if (dbReader.HasRows == false)
            {
                MessageBox.Show("Заполните таблицу с врачами!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                while (dbReader.Read())
                {
                    comboBoxFIODoctor.Items.Add(dbReader["FIO"]);
                }
            }

            dbReader.Close();
            dbConnection.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (textBoxFIOPatients.Text == "" || comboBoxFIODoctor.Text == "" || richTextBoxDiagnosis.Text == "" || dateTimePickerDateOfAdmission.Text == "" ||
                maskedTextBoxTelephone.MaskCompleted == false || textBoxAddress.Text == "" || dateTimePickerDateOfBirth.Text == "")
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            //считываем данные
            string FIOPatients = textBoxFIOPatients.Text.ToString();
            string FIODoctor = comboBoxFIODoctor.Text.ToString();
            string diagnosis = richTextBoxDiagnosis.Text.ToString();
            string dateOfAdmission = dateTimePickerDateOfAdmission.Text.ToString();
            string telephone = maskedTextBoxTelephone.Text.ToString();
            string address = textBoxAddress.Text.ToString();
            string dateOfBirth = dateTimePickerDateOfBirth.Text.ToString();

            //соеденение с БД
            string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();

            string querySearch = "SELECT * FROM staff WHERE FIO = '" + FIODoctor + "'";
            OleDbCommand dbCommandSearch = new OleDbCommand(querySearch, dbConnection);
            OleDbDataReader dbReaderSearch = dbCommandSearch.ExecuteReader();

            if (dbReaderSearch.HasRows == false)
            {
                MessageBox.Show("Такого доктора нет", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            dbReaderSearch.Close();

            string query = "";
            if (str == "add")
            {
                query = "INSERT INTO patients VALUES(" + id + ",'" + FIOPatients + "','" + FIODoctor + "','" + diagnosis + "','Нет','Нет','"+ dateOfAdmission + "','"+ telephone + "','"+ address + "','"+ dateOfBirth + "')";//сам запрос
               
                string queryAnalyzes = "INSERT INTO analyzesForPatients VALUES(" + id + ",'','','')";
                string queryTreatment = "INSERT INTO treatment VALUES(" + id + ",'')";
                string queryReport = "INSERT INTO report VALUES(" + id + ",'" + FIODoctor + "', '" + FIOPatients + "', '" + dateOfAdmission + "')";
                OleDbCommand dbCommandAnalyz = new OleDbCommand(queryAnalyzes, dbConnection);
                OleDbCommand dbCommandTreatment = new OleDbCommand(queryTreatment, dbConnection);
                OleDbCommand dbCommandReport = new OleDbCommand(queryReport, dbConnection);
                dbCommandAnalyz.ExecuteNonQuery();
                dbCommandTreatment.ExecuteNonQuery();
                dbCommandReport.ExecuteNonQuery();
            }
            else
            {
                query = "UPDATE patients SET patientsFIO = '" + FIOPatients + "', doctorFIO = '" + FIODoctor + "',diagnosis = '" + diagnosis + "', dateOfAdmission= '" + dateOfAdmission + "', telephone= '" + telephone + "', address= '" + address + "', dateOfBirth = '" + dateOfBirth + "' WHERE ID = " + id;
            }
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);// команда

            //выполнение запроса 
            if (dbCommand.ExecuteNonQuery() != 1)//этот метот возвращает кол-во добавленных строк 
            { MessageBox.Show("Ошибка выполнения запроса!", "Внимание!"); dbConnection.Close(); Close(); return; }
            else
            { MessageBox.Show("Успешно!", "Готово!", MessageBoxButtons.OK, MessageBoxIcon.Information); }

            

            //закрытие соединения с БД
            dbConnection.Close();

            form1.setDGV(FIOPatients, FIODoctor, diagnosis, dateOfAdmission, telephone, address, dateOfBirth, str);
            Close();
        }
    }
}
