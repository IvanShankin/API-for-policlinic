namespace WindowsFormsAppPolyclinic
{
    partial class FormChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChangePassword));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxLoginRegistrator = new System.Windows.Forms.TextBox();
            this.textBoxPasswordRegistrator = new System.Windows.Forms.TextBox();
            this.textBoxPasswordDoctor = new System.Windows.Forms.TextBox();
            this.buttonCansel = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(26, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин для регистратора:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(14, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Пароль для регистратора:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(53, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(209, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Пароль для докторов:";
            // 
            // textBoxLoginRegistrator
            // 
            this.textBoxLoginRegistrator.Location = new System.Drawing.Point(269, 42);
            this.textBoxLoginRegistrator.Multiline = true;
            this.textBoxLoginRegistrator.Name = "textBoxLoginRegistrator";
            this.textBoxLoginRegistrator.Size = new System.Drawing.Size(235, 24);
            this.textBoxLoginRegistrator.TabIndex = 3;
            // 
            // textBoxPasswordRegistrator
            // 
            this.textBoxPasswordRegistrator.Location = new System.Drawing.Point(269, 82);
            this.textBoxPasswordRegistrator.Multiline = true;
            this.textBoxPasswordRegistrator.Name = "textBoxPasswordRegistrator";
            this.textBoxPasswordRegistrator.Size = new System.Drawing.Size(235, 24);
            this.textBoxPasswordRegistrator.TabIndex = 4;
            // 
            // textBoxPasswordDoctor
            // 
            this.textBoxPasswordDoctor.Location = new System.Drawing.Point(268, 121);
            this.textBoxPasswordDoctor.Multiline = true;
            this.textBoxPasswordDoctor.Name = "textBoxPasswordDoctor";
            this.textBoxPasswordDoctor.Size = new System.Drawing.Size(235, 24);
            this.textBoxPasswordDoctor.TabIndex = 5;
            // 
            // buttonCansel
            // 
            this.buttonCansel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonCansel.BackgroundImage")));
            this.buttonCansel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCansel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCansel.Location = new System.Drawing.Point(398, 177);
            this.buttonCansel.Name = "buttonCansel";
            this.buttonCansel.Size = new System.Drawing.Size(172, 44);
            this.buttonCansel.TabIndex = 7;
            this.buttonCansel.Text = "Назад        ";
            this.buttonCansel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonCansel.UseVisualStyleBackColor = true;
            this.buttonCansel.Click += new System.EventHandler(this.buttonCansel_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSave.BackgroundImage")));
            this.buttonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSave.Location = new System.Drawing.Point(12, 177);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(172, 44);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Сохранить   ";
            this.buttonSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click_1);
            // 
            // FormChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 233);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonCansel);
            this.Controls.Add(this.textBoxPasswordDoctor);
            this.Controls.Add(this.textBoxPasswordRegistrator);
            this.Controls.Add(this.textBoxLoginRegistrator);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormChangePassword";
            this.Load += new System.EventHandler(this.FormChangePassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxLoginRegistrator;
        private System.Windows.Forms.TextBox textBoxPasswordRegistrator;
        private System.Windows.Forms.TextBox textBoxPasswordDoctor;
        private System.Windows.Forms.Button buttonCansel;
        private System.Windows.Forms.Button buttonSave;
    }
}