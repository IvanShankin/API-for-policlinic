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
    public partial class FormAnalyzFromPatients : Form
    {
       
        public FormAnalyzFromPatients(FormPatients form1, int id, string FIO,string diagnosis, string DateOfAdmission)
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
     
        private void FormAnalyzFromPatients_Load(object sender, EventArgs e)
        {
            string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);

            dbConnection.Open();
            string query = "SELECT * FROM analyzesForPatients WHERE ID =" + id;
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader = dbCommand.ExecuteReader();

            if (dbReader.HasRows == true)
            {
                dbReader.Read();
                
                comboBox1.Text = dbReader["analyzesName"].ToString(); 
                dateTimePicker1.Text = dbReader["dateOfDelivery"].ToString();
                comboBoxResult.Text = dbReader["result"].ToString();
            }

            query = "SELECT * FROM analyzes";
            OleDbCommand dbCommand2 = new OleDbCommand(query, dbConnection);
            OleDbDataReader dbReader2 = dbCommand2.ExecuteReader();

            if (dbReader2.HasRows == true)
            {
                while (dbReader2.Read())
                {
                    comboBox1.Items.Add(dbReader2["nameAnaliz"]);
                }
            }

            dbReader.Close();
            dbReader2.Close();
            dbConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || dateTimePicker1.Text == "" )
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            string analyzesName = comboBox1.Text.ToString();
            string dateOfDelivery = dateTimePicker1.Text.ToString();
            string result = comboBoxResult.Text.ToString();

            string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = dataBase.accdb;";
            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаём новое соеденение 
    
            dbConnection.Open();
          
            string query = "UPDATE analyzesForPatients SET analyzesName = '" + analyzesName + "', dateOfDelivery = '" + dateOfDelivery + "',result = '" + result + "' WHERE ID = " + id;
            
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);

            if (dbCommand.ExecuteNonQuery() != 1)
            { MessageBox.Show("Ошибка выполнения запроса!", "Внимание!"); dbConnection.Close(); Close(); return; }
            else
            {
                if (comboBoxResult.Text != "")
                { form1.setDGVAndBD("analyzes"); }
            }
            dbConnection.Close();
            Close();
        }
    }
}
