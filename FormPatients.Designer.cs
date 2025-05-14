namespace WindowsFormsAppPolyclinic
{
    partial class FormPatients
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPatients));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNameSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAnalyzes = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.buttonStaff = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonChange = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPatientsFIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDoctorFIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDiagnos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAnalyzes = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnTreatment = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnDateOfAdmission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonChangePassword = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonExit
            // 
            this.buttonExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExit.BackgroundImage")));
            this.buttonExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonExit.Location = new System.Drawing.Point(-3, 23);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 47;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonUpdate.BackgroundImage")));
            this.buttonUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonUpdate.Location = new System.Drawing.Point(1666, 11);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(35, 36);
            this.buttonUpdate.TabIndex = 46;
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSearch.BackgroundImage")));
            this.buttonSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSearch.Location = new System.Drawing.Point(692, 23);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(101, 25);
            this.buttonSearch.TabIndex = 45;
            this.buttonSearch.Text = "Поиск";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "ФИО пациента:";
            // 
            // textBoxNameSearch
            // 
            this.textBoxNameSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxNameSearch.Location = new System.Drawing.Point(316, 23);
            this.textBoxNameSearch.Multiline = true;
            this.textBoxNameSearch.Name = "textBoxNameSearch";
            this.textBoxNameSearch.Size = new System.Drawing.Size(370, 24);
            this.textBoxNameSearch.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(241, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 24);
            this.label1.TabIndex = 42;
            this.label1.Text = "Поиск:";
            // 
            // buttonAnalyzes
            // 
            this.buttonAnalyzes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAnalyzes.BackgroundImage")));
            this.buttonAnalyzes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAnalyzes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAnalyzes.Location = new System.Drawing.Point(-3, 227);
            this.buttonAnalyzes.Name = "buttonAnalyzes";
            this.buttonAnalyzes.Size = new System.Drawing.Size(248, 70);
            this.buttonAnalyzes.TabIndex = 41;
            this.buttonAnalyzes.Text = "Анализы";
            this.buttonAnalyzes.UseVisualStyleBackColor = true;
            this.buttonAnalyzes.Click += new System.EventHandler(this.buttonAnalyzes_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(-3, 313);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(248, 70);
            this.button3.TabIndex = 40;
            this.button3.Text = "Отчёт";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // buttonStaff
            // 
            this.buttonStaff.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonStaff.BackgroundImage")));
            this.buttonStaff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonStaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStaff.Location = new System.Drawing.Point(-3, 141);
            this.buttonStaff.Name = "buttonStaff";
            this.buttonStaff.Size = new System.Drawing.Size(248, 70);
            this.buttonStaff.TabIndex = 39;
            this.buttonStaff.Text = "Персонал";
            this.buttonStaff.UseVisualStyleBackColor = true;
            this.buttonStaff.Click += new System.EventHandler(this.buttonStaff_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(-3, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(248, 70);
            this.button1.TabIndex = 38;
            this.button1.Text = "Пациенты";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDelete.BackgroundImage")));
            this.buttonDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelete.Location = new System.Drawing.Point(1701, 156);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(203, 45);
            this.buttonDelete.TabIndex = 37;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonChange
            // 
            this.buttonChange.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonChange.BackgroundImage")));
            this.buttonChange.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChange.Location = new System.Drawing.Point(1701, 105);
            this.buttonChange.Name = "buttonChange";
            this.buttonChange.Size = new System.Drawing.Size(203, 45);
            this.buttonChange.TabIndex = 36;
            this.buttonChange.Text = "Изменить";
            this.buttonChange.UseVisualStyleBackColor = true;
            this.buttonChange.Click += new System.EventHandler(this.buttonChange_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAdd.BackgroundImage")));
            this.buttonAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdd.Location = new System.Drawing.Point(1701, 54);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(203, 45);
            this.buttonAdd.TabIndex = 35;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnID,
            this.ColumnPatientsFIO,
            this.ColumnDoctorFIO,
            this.ColumnDiagnos,
            this.ColumnAnalyzes,
            this.ColumnTreatment,
            this.ColumnDateOfAdmission,
            this.ColumnTelephone,
            this.ColumnAddress,
            this.ColumnDateOfBirth});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(245, 54);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1456, 978);
            this.dataGridView1.TabIndex = 34;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ColumnID
            // 
            this.ColumnID.HeaderText = "ID";
            this.ColumnID.Name = "ColumnID";
            this.ColumnID.ReadOnly = true;
            this.ColumnID.Visible = false;
            // 
            // ColumnPatientsFIO
            // 
            this.ColumnPatientsFIO.HeaderText = "ФИО пациента";
            this.ColumnPatientsFIO.Name = "ColumnPatientsFIO";
            this.ColumnPatientsFIO.ReadOnly = true;
            this.ColumnPatientsFIO.Width = 370;
            // 
            // ColumnDoctorFIO
            // 
            this.ColumnDoctorFIO.HeaderText = "ФИО Врача";
            this.ColumnDoctorFIO.Name = "ColumnDoctorFIO";
            this.ColumnDoctorFIO.ReadOnly = true;
            this.ColumnDoctorFIO.Width = 370;
            // 
            // ColumnDiagnos
            // 
            this.ColumnDiagnos.HeaderText = "Диагноз";
            this.ColumnDiagnos.Name = "ColumnDiagnos";
            this.ColumnDiagnos.ReadOnly = true;
            this.ColumnDiagnos.Width = 353;
            // 
            // ColumnAnalyzes
            // 
            this.ColumnAnalyzes.HeaderText = "Анализы";
            this.ColumnAnalyzes.Name = "ColumnAnalyzes";
            this.ColumnAnalyzes.ReadOnly = true;
            this.ColumnAnalyzes.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnAnalyzes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnAnalyzes.Width = 90;
            // 
            // ColumnTreatment
            // 
            this.ColumnTreatment.HeaderText = "Лечение";
            this.ColumnTreatment.Name = "ColumnTreatment";
            this.ColumnTreatment.ReadOnly = true;
            this.ColumnTreatment.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnTreatment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnTreatment.Width = 90;
            // 
            // ColumnDateOfAdmission
            // 
            this.ColumnDateOfAdmission.HeaderText = "Дата приёма";
            this.ColumnDateOfAdmission.Name = "ColumnDateOfAdmission";
            this.ColumnDateOfAdmission.ReadOnly = true;
            this.ColumnDateOfAdmission.Width = 180;
            // 
            // ColumnTelephone
            // 
            this.ColumnTelephone.HeaderText = "Телефон";
            this.ColumnTelephone.Name = "ColumnTelephone";
            this.ColumnTelephone.ReadOnly = true;
            this.ColumnTelephone.Visible = false;
            // 
            // ColumnAddress
            // 
            this.ColumnAddress.HeaderText = "адрес";
            this.ColumnAddress.Name = "ColumnAddress";
            this.ColumnAddress.ReadOnly = true;
            this.ColumnAddress.Visible = false;
            // 
            // ColumnDateOfBirth
            // 
            this.ColumnDateOfBirth.HeaderText = "Дата рожднния";
            this.ColumnDateOfBirth.Name = "ColumnDateOfBirth";
            this.ColumnDateOfBirth.ReadOnly = true;
            this.ColumnDateOfBirth.Visible = false;
            // 
            // buttonChangePassword
            // 
            this.buttonChangePassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChangePassword.Location = new System.Drawing.Point(-3, 983);
            this.buttonChangePassword.Name = "buttonChangePassword";
            this.buttonChangePassword.Size = new System.Drawing.Size(248, 36);
            this.buttonChangePassword.TabIndex = 48;
            this.buttonChangePassword.Text = "Пароли";
            this.buttonChangePassword.UseVisualStyleBackColor = true;
            this.buttonChangePassword.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormPatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1031);
            this.Controls.Add(this.buttonChangePassword);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNameSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAnalyzes);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.buttonStaff);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonChange);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormPatients";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPatients";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPatients_FormClosing);
            this.Load += new System.EventHandler(this.FormPatients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonUpdate;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNameSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAnalyzes;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button buttonStaff;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonChange;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPatientsFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDoctorFIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDiagnos;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnAnalyzes;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnTreatment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateOfAdmission;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateOfBirth;
        private System.Windows.Forms.Button buttonChangePassword;
    }
}