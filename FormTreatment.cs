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
    public partial class FormTreatment : Form
    {
        public FormTreatment(FormPatients form1, int id, string FIO, string diagnosis, string DateOfAdmission)
        {
            InitializeComponent();
            this.form1 = form1;
            this.id = id;
            labelFIO.Text = FIO;
            labelDiagnosis.Text = diagnosis;
            labelDateOfAdmission.Text = DateOfAdmission;
        }
        private FormPatients form1;
        int id = 0;

        private void FormTreatment_Load(object sender, EventArgs e)
        {
            string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = "SELECT * FROM treatment WHERE ID =" + id;
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            if (dbReader.HasRows == true)
            {
                dbReader.Read();
                textBoxDescription.Text = dbReader["description"].ToString();
            }

            dbReader.Close();
            dbConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxDescription.Text == "" )
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            string description = textBoxDescription.Text.ToString();

            string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаём новое соеденение 

            dbConnection.Open();

            string query = "UPDATE treatment SET description = '" + description + "' WHERE ID = " + id;

            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

            if (dbCommand.ExecuteNonQuery() != 1)
            { MessageBox.Show("Ошибка выполнения запроса!", "Внимание!"); dbConnection.Close(); Close(); return; }
            else
            {
                form1.setDGVAndBD("treatment");
            }
            dbConnection.Close();
            Close();
        }
    }
}
