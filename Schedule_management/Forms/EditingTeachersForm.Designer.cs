namespace Schedule_management.Forms
{
    partial class EditingTeachersForm
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
            listBoxShowTeachers = new ListBox();
            groupBoxEditTeacher = new GroupBox();
            buttonRemove = new Button();
            buttonSave = new Button();
            buttonDontSave = new Button();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            textBoxCalculation = new TextBox();
            textBoxWorkload = new TextBox();
            textBoxNormOfHours = new TextBox();
            textBoxBaseRate = new TextBox();
            checkBoxDetail = new CheckBox();
            label7 = new Label();
            label6 = new Label();
            textBoxSalary = new TextBox();
            comboBoxEducation = new ComboBox();
            comboBoxSkill = new ComboBox();
            comboBoxGender = new ComboBox();
            textBoxExperience = new TextBox();
            textBoxFullName = new TextBox();
            groupBoxEditTeacher.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxShowTeachers
            // 
            listBoxShowTeachers.FormattingEnabled = true;
            listBoxShowTeachers.ItemHeight = 20;
            listBoxShowTeachers.Location = new Point(52, 58);
            listBoxShowTeachers.Name = "listBoxShowTeachers";
            listBoxShowTeachers.Size = new Size(305, 464);
            listBoxShowTeachers.TabIndex = 0;
            listBoxShowTeachers.SelectedIndexChanged += listBoxShowTeachers_SelectedIndexChanged;
            // 
            // groupBoxEditTeacher
            // 
            groupBoxEditTeacher.Controls.Add(buttonRemove);
            groupBoxEditTeacher.Controls.Add(buttonSave);
            groupBoxEditTeacher.Controls.Add(buttonDontSave);
            groupBoxEditTeacher.Controls.Add(label5);
            groupBoxEditTeacher.Controls.Add(label4);
            groupBoxEditTeacher.Controls.Add(label3);
            groupBoxEditTeacher.Controls.Add(label2);
            groupBoxEditTeacher.Controls.Add(label1);
            groupBoxEditTeacher.Controls.Add(groupBox2);
            groupBoxEditTeacher.Controls.Add(comboBoxEducation);
            groupBoxEditTeacher.Controls.Add(comboBoxSkill);
            groupBoxEditTeacher.Controls.Add(comboBoxGender);
            groupBoxEditTeacher.Controls.Add(textBoxExperience);
            groupBoxEditTeacher.Controls.Add(textBoxFullName);
            groupBoxEditTeacher.Location = new Point(387, 58);
            groupBoxEditTeacher.Name = "groupBoxEditTeacher";
            groupBoxEditTeacher.Size = new Size(543, 464);
            groupBoxEditTeacher.TabIndex = 1;
            groupBoxEditTeacher.TabStop = false;
            groupBoxEditTeacher.Text = "Новый преподаватель:";
            // 
            // buttonRemove
            // 
            buttonRemove.Location = new Point(32, 356);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(474, 34);
            buttonRemove.TabIndex = 13;
            buttonRemove.Text = "Удалить";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Visible = false;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // buttonSave
            // 
            buttonSave.Enabled = false;
            buttonSave.Location = new Point(272, 396);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(234, 51);
            buttonSave.TabIndex = 12;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // buttonDontSave
            // 
            buttonDontSave.Location = new Point(32, 396);
            buttonDontSave.Name = "buttonDontSave";
            buttonDontSave.Size = new Size(234, 51);
            buttonDontSave.TabIndex = 11;
            buttonDontSave.Text = "Не сохранять";
            buttonDontSave.UseVisualStyleBackColor = true;
            buttonDontSave.Click += buttonDontSave_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 290);
            label5.Name = "label5";
            label5.Size = new Size(107, 20);
            label5.TabIndex = 10;
            label5.Text = "Образование:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 220);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 9;
            label4.Text = "Категория:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 157);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 8;
            label3.Text = "Стаж:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 100);
            label2.Name = "label2";
            label2.Size = new Size(40, 20);
            label2.TabIndex = 7;
            label2.Text = "Пол:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 40);
            label1.Name = "label1";
            label1.Size = new Size(45, 20);
            label1.TabIndex = 6;
            label1.Text = "ФИО:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(textBoxCalculation);
            groupBox2.Controls.Add(textBoxWorkload);
            groupBox2.Controls.Add(textBoxNormOfHours);
            groupBox2.Controls.Add(textBoxBaseRate);
            groupBox2.Controls.Add(checkBoxDetail);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(textBoxSalary);
            groupBox2.Location = new Point(290, 21);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(232, 320);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(26, 243);
            label11.Name = "label11";
            label11.Size = new Size(64, 20);
            label11.TabIndex = 17;
            label11.Text = "Рассчёт:";
            label11.Visible = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(26, 198);
            label10.Name = "label10";
            label10.Size = new Size(75, 20);
            label10.TabIndex = 16;
            label10.Text = "Нагрузка:";
            label10.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(26, 165);
            label9.Name = "label9";
            label9.Size = new Size(104, 20);
            label9.TabIndex = 15;
            label9.Text = "Норма часов:";
            label9.Visible = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(26, 132);
            label8.Name = "label8";
            label8.Size = new Size(117, 20);
            label8.TabIndex = 14;
            label8.Text = "Базовая ставка:";
            label8.Visible = false;
            // 
            // textBoxCalculation
            // 
            textBoxCalculation.Location = new Point(26, 266);
            textBoxCalculation.Name = "textBoxCalculation";
            textBoxCalculation.ReadOnly = true;
            textBoxCalculation.Size = new Size(185, 27);
            textBoxCalculation.TabIndex = 13;
            textBoxCalculation.Text = "-";
            textBoxCalculation.Visible = false;
            // 
            // textBoxWorkload
            // 
            textBoxWorkload.Location = new Point(151, 195);
            textBoxWorkload.Name = "textBoxWorkload";
            textBoxWorkload.ReadOnly = true;
            textBoxWorkload.Size = new Size(60, 27);
            textBoxWorkload.TabIndex = 12;
            textBoxWorkload.Visible = false;
            textBoxWorkload.TextChanged += textBoxWorkload_TextChanged;
            // 
            // textBoxNormOfHours
            // 
            textBoxNormOfHours.Location = new Point(151, 162);
            textBoxNormOfHours.Name = "textBoxNormOfHours";
            textBoxNormOfHours.Size = new Size(60, 27);
            textBoxNormOfHours.TabIndex = 11;
            textBoxNormOfHours.Text = "20";
            textBoxNormOfHours.Visible = false;
            textBoxNormOfHours.TextChanged += textBoxNormOfHours_TextChanged;
            // 
            // textBoxBaseRate
            // 
            textBoxBaseRate.Location = new Point(151, 129);
            textBoxBaseRate.Name = "textBoxBaseRate";
            textBoxBaseRate.Size = new Size(60, 27);
            textBoxBaseRate.TabIndex = 10;
            textBoxBaseRate.Text = "250";
            textBoxBaseRate.Visible = false;
            textBoxBaseRate.TextChanged += textBoxBaseRate_TextChanged;
            // 
            // checkBoxDetail
            // 
            checkBoxDetail.AutoSize = true;
            checkBoxDetail.Location = new Point(26, 78);
            checkBoxDetail.Name = "checkBoxDetail";
            checkBoxDetail.Size = new Size(111, 24);
            checkBoxDetail.TabIndex = 9;
            checkBoxDetail.Text = "Подробнее";
            checkBoxDetail.UseVisualStyleBackColor = true;
            checkBoxDetail.CheckedChanged += checkBoxDetail_CheckedChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(174, 45);
            label7.Name = "label7";
            label7.Size = new Size(37, 20);
            label7.TabIndex = 8;
            label7.Text = "BYN";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(26, 19);
            label6.Name = "label6";
            label6.Size = new Size(142, 20);
            label6.TabIndex = 7;
            label6.Text = "Примерный оклад:";
            // 
            // textBoxSalary
            // 
            textBoxSalary.Location = new Point(26, 42);
            textBoxSalary.Name = "textBoxSalary";
            textBoxSalary.ReadOnly = true;
            textBoxSalary.Size = new Size(142, 27);
            textBoxSalary.TabIndex = 0;
            textBoxSalary.Text = "-";
            // 
            // comboBoxEducation
            // 
            comboBoxEducation.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxEducation.FormattingEnabled = true;
            comboBoxEducation.Items.AddRange(new object[] { "среднее специальное", "высшее" });
            comboBoxEducation.Location = new Point(32, 313);
            comboBoxEducation.Name = "comboBoxEducation";
            comboBoxEducation.Size = new Size(234, 28);
            comboBoxEducation.TabIndex = 4;
            comboBoxEducation.SelectedIndexChanged += comboBoxEducation_SelectedIndexChanged;
            // 
            // comboBoxSkill
            // 
            comboBoxSkill.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSkill.FormattingEnabled = true;
            comboBoxSkill.Items.AddRange(new object[] { "без категории", "вторая категория", "первая категория", "высшая категория", "учитель-методист" });
            comboBoxSkill.Location = new Point(32, 243);
            comboBoxSkill.Name = "comboBoxSkill";
            comboBoxSkill.Size = new Size(234, 28);
            comboBoxSkill.TabIndex = 3;
            comboBoxSkill.SelectedIndexChanged += comboBoxSkill_SelectedIndexChanged;
            // 
            // comboBoxGender
            // 
            comboBoxGender.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGender.FormattingEnabled = true;
            comboBoxGender.Items.AddRange(new object[] { "муж", "жен" });
            comboBoxGender.Location = new Point(32, 123);
            comboBoxGender.Name = "comboBoxGender";
            comboBoxGender.Size = new Size(234, 28);
            comboBoxGender.TabIndex = 2;
            comboBoxGender.SelectedIndexChanged += comboBoxGender_SelectedIndexChanged;
            // 
            // textBoxExperience
            // 
            textBoxExperience.Location = new Point(32, 180);
            textBoxExperience.Name = "textBoxExperience";
            textBoxExperience.Size = new Size(234, 27);
            textBoxExperience.TabIndex = 1;
            textBoxExperience.TextChanged += textBoxExperience_TextChanged;
            // 
            // textBoxFullName
            // 
            textBoxFullName.Location = new Point(32, 63);
            textBoxFullName.Name = "textBoxFullName";
            textBoxFullName.Size = new Size(234, 27);
            textBoxFullName.TabIndex = 0;
            textBoxFullName.TextChanged += textBoxFullName_TextChanged;
            // 
            // EditingTeachersForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(983, 572);
            Controls.Add(groupBoxEditTeacher);
            Controls.Add(listBoxShowTeachers);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "EditingTeachersForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Список преподавателей";
            groupBoxEditTeacher.ResumeLayout(false);
            groupBoxEditTeacher.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxShowTeachers;
        private GroupBox groupBoxEditTeacher;
        private ComboBox comboBoxEducation;
        private ComboBox comboBoxSkill;
        private ComboBox comboBoxGender;
        private TextBox textBoxExperience;
        private TextBox textBoxFullName;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private GroupBox groupBox2;
        private Button buttonDontSave;
        private Button buttonRemove;
        private Button buttonSave;
        private TextBox textBoxSalary;
        private Label label6;
        private CheckBox checkBoxDetail;
        private Label label7;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private TextBox textBoxCalculation;
        private TextBox textBoxWorkload;
        private TextBox textBoxNormOfHours;
        private TextBox textBoxBaseRate;
    }
}