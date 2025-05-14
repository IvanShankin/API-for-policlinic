using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsAppPolyclinic
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonStaff_Click(object sender, EventArgs e)
        {
            FormStaff staff = new FormStaff();
            this.Close();
            staff.Show();
        }

        private void buttonAnalyzes_Click(object sender, EventArgs e)
        {
            FormAnalyzes analiz = new FormAnalyzes();
            this.Close();
            analiz.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPatients patients = new FormPatients("no");
            this.Close();
            patients.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormReport report = new FormReport();
            this.Close();
            report.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonChangePassword_Click(object sender, EventArgs e)
        {
            FormChangePassword changePassword = new FormChangePassword();
            changePassword.ShowDialog();
        }
    }
}
