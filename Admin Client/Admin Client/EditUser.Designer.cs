namespace Admin_Client
{
    partial class EditUser
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
            this.FIO = new System.Windows.Forms.TextBox();
            this.Auto = new System.Windows.Forms.TextBox();
            this.GosNum = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.Role = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.UserLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FIO
            // 
            this.FIO.Location = new System.Drawing.Point(107, 52);
            this.FIO.Name = "FIO";
            this.FIO.Size = new System.Drawing.Size(151, 20);
            this.FIO.TabIndex = 0;
            // 
            // Auto
            // 
            this.Auto.Location = new System.Drawing.Point(107, 78);
            this.Auto.Name = "Auto";
            this.Auto.Size = new System.Drawing.Size(151, 20);
            this.Auto.TabIndex = 1;
            // 
            // GosNum
            // 
            this.GosNum.Location = new System.Drawing.Point(107, 104);
            this.GosNum.Name = "GosNum";
            this.GosNum.Size = new System.Drawing.Size(151, 20);
            this.GosNum.TabIndex = 2;
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(107, 130);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(151, 20);
            this.Email.TabIndex = 4;
            // 
            // Role
            // 
            this.Role.FormattingEnabled = true;
            this.Role.Items.AddRange(new object[] {
            "Админ",
            "Клиент",
            "Водитель"});
            this.Role.Location = new System.Drawing.Point(107, 157);
            this.Role.Name = "Role";
            this.Role.Size = new System.Drawing.Size(151, 21);
            this.Role.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "ФИО";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Марка авто";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Гос номер";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(37, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Роль";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(96, 215);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 11;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // UserLable
            // 
            this.UserLable.AutoSize = true;
            this.UserLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserLable.Location = new System.Drawing.Point(35, 18);
            this.UserLable.Name = "UserLable";
            this.UserLable.Size = new System.Drawing.Size(106, 16);
            this.UserLable.TabIndex = 12;
            this.UserLable.Text = "Пользователь ";
            // 
            // EditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 261);
            this.Controls.Add(this.UserLable);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Role);
            this.Controls.Add(this.Email);
            this.Controls.Add(this.GosNum);
            this.Controls.Add(this.Auto);
            this.Controls.Add(this.FIO);
            this.Name = "EditUser";
            this.Text = "Редактировать пользователя";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FIO;
        private System.Windows.Forms.TextBox Auto;
        private System.Windows.Forms.TextBox GosNum;
        private System.Windows.Forms.TextBox Email;
        private System.Windows.Forms.ComboBox Role;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label UserLable;
    }
}