namespace Admin_Client
{
    partial class AddUser
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Email = new System.Windows.Forms.TextBox();
            this.GosNum = new System.Windows.Forms.TextBox();
            this.Auto = new System.Windows.Forms.TextBox();
            this.FIO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Phone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Гос номер";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Марка авто";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "ФИО";
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(103, 170);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(151, 20);
            this.Email.TabIndex = 14;
            // 
            // GosNum
            // 
            this.GosNum.Location = new System.Drawing.Point(103, 144);
            this.GosNum.Name = "GosNum";
            this.GosNum.Size = new System.Drawing.Size(151, 20);
            this.GosNum.TabIndex = 13;
            // 
            // Auto
            // 
            this.Auto.Location = new System.Drawing.Point(103, 118);
            this.Auto.Name = "Auto";
            this.Auto.Size = new System.Drawing.Size(151, 20);
            this.Auto.TabIndex = 12;
            // 
            // FIO
            // 
            this.FIO.Location = new System.Drawing.Point(103, 92);
            this.FIO.Name = "FIO";
            this.FIO.Size = new System.Drawing.Size(151, 20);
            this.FIO.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Телефон";
            // 
            // Phone
            // 
            this.Phone.Location = new System.Drawing.Point(103, 41);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(151, 20);
            this.Phone.TabIndex = 21;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(31, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Пароль";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(103, 67);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(151, 20);
            this.Password.TabIndex = 23;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(103, 213);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 25;
            this.AddButton.Text = "Создать";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(185, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "Добавление нового пользователя:";
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.GosNum);
            this.Controls.Add(this.Auto);
            this.Controls.Add(this.FIO);
            this.Name = "AddUser";
            this.Text = "AddUser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.TextBox GosNum;
        private System.Windows.Forms.TextBox Auto;
        private System.Windows.Forms.TextBox FIO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Phone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label label5;
    }
}