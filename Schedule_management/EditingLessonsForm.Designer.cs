namespace Schedule_management
{
    partial class EditingLessonsForm
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
            listBoxShowLessons = new ListBox();
            groupBoxNewLesson = new GroupBox();
            comboBoxTeacherOfLesson = new ComboBox();
            buttonRemoveLesson = new Button();
            buttonDontSaveLesson = new Button();
            buttonSaveLesson = new Button();
            labelTeacherOfLesson = new Label();
            labelNameOfLesson = new Label();
            textBoxNameOfLesson = new TextBox();
            buttonClearLessons = new Button();
            groupBoxNewLesson.SuspendLayout();
            SuspendLayout();
            // 
            // listBoxShowLessons
            // 
            listBoxShowLessons.FormattingEnabled = true;
            listBoxShowLessons.ItemHeight = 20;
            listBoxShowLessons.Location = new Point(50, 50);
            listBoxShowLessons.Name = "listBoxShowLessons";
            listBoxShowLessons.Size = new Size(290, 304);
            listBoxShowLessons.TabIndex = 0;
            listBoxShowLessons.SelectedIndexChanged += listBoxShowLessons_SelectedIndexChanged;
            // 
            // groupBoxNewLesson
            // 
            groupBoxNewLesson.Controls.Add(comboBoxTeacherOfLesson);
            groupBoxNewLesson.Controls.Add(buttonRemoveLesson);
            groupBoxNewLesson.Controls.Add(buttonDontSaveLesson);
            groupBoxNewLesson.Controls.Add(buttonSaveLesson);
            groupBoxNewLesson.Controls.Add(labelTeacherOfLesson);
            groupBoxNewLesson.Controls.Add(labelNameOfLesson);
            groupBoxNewLesson.Controls.Add(textBoxNameOfLesson);
            groupBoxNewLesson.Location = new Point(371, 50);
            groupBoxNewLesson.Name = "groupBoxNewLesson";
            groupBoxNewLesson.Size = new Size(388, 304);
            groupBoxNewLesson.TabIndex = 1;
            groupBoxNewLesson.TabStop = false;
            groupBoxNewLesson.Text = "Новый урок";
            // 
            // comboBoxTeacherOfLesson
            // 
            comboBoxTeacherOfLesson.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxTeacherOfLesson.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTeacherOfLesson.FormattingEnabled = true;
            comboBoxTeacherOfLesson.Location = new Point(24, 152);
            comboBoxTeacherOfLesson.Name = "comboBoxTeacherOfLesson";
            comboBoxTeacherOfLesson.Size = new Size(341, 28);
            comboBoxTeacherOfLesson.Sorted = true;
            comboBoxTeacherOfLesson.TabIndex = 7;
            // 
            // buttonRemoveLesson
            // 
            buttonRemoveLesson.Location = new Point(24, 191);
            buttonRemoveLesson.Name = "buttonRemoveLesson";
            buttonRemoveLesson.Size = new Size(341, 29);
            buttonRemoveLesson.TabIndex = 6;
            buttonRemoveLesson.Text = "Удалить";
            buttonRemoveLesson.UseVisualStyleBackColor = true;
            buttonRemoveLesson.Visible = false;
            buttonRemoveLesson.Click += buttonRemoveLesson_Click;
            // 
            // buttonDontSaveLesson
            // 
            buttonDontSaveLesson.Location = new Point(24, 226);
            buttonDontSaveLesson.Name = "buttonDontSaveLesson";
            buttonDontSaveLesson.Size = new Size(165, 51);
            buttonDontSaveLesson.TabIndex = 5;
            buttonDontSaveLesson.Text = "Не сохранять";
            buttonDontSaveLesson.UseVisualStyleBackColor = true;
            buttonDontSaveLesson.Click += buttonDontSaveLesson_Click;
            // 
            // buttonSaveLesson
            // 
            buttonSaveLesson.Location = new Point(195, 226);
            buttonSaveLesson.Name = "buttonSaveLesson";
            buttonSaveLesson.Size = new Size(170, 51);
            buttonSaveLesson.TabIndex = 4;
            buttonSaveLesson.Text = "Сохранить";
            buttonSaveLesson.UseVisualStyleBackColor = true;
            buttonSaveLesson.Click += buttonSaveLesson_Click;
            // 
            // labelTeacherOfLesson
            // 
            labelTeacherOfLesson.AutoSize = true;
            labelTeacherOfLesson.Location = new Point(24, 129);
            labelTeacherOfLesson.Name = "labelTeacherOfLesson";
            labelTeacherOfLesson.Size = new Size(117, 20);
            labelTeacherOfLesson.TabIndex = 3;
            labelTeacherOfLesson.Text = "Преподаватель";
            // 
            // labelNameOfLesson
            // 
            labelNameOfLesson.AutoSize = true;
            labelNameOfLesson.Location = new Point(24, 40);
            labelNameOfLesson.Name = "labelNameOfLesson";
            labelNameOfLesson.Size = new Size(121, 20);
            labelNameOfLesson.TabIndex = 2;
            labelNameOfLesson.Text = "Название урока";
            // 
            // textBoxNameOfLesson
            // 
            textBoxNameOfLesson.Location = new Point(24, 63);
            textBoxNameOfLesson.Name = "textBoxNameOfLesson";
            textBoxNameOfLesson.Size = new Size(341, 27);
            textBoxNameOfLesson.TabIndex = 0;
            // 
            // buttonClearLessons
            // 
            buttonClearLessons.Location = new Point(50, 379);
            buttonClearLessons.Name = "buttonClearLessons";
            buttonClearLessons.Size = new Size(290, 47);
            buttonClearLessons.TabIndex = 2;
            buttonClearLessons.Text = "Очистить список";
            buttonClearLessons.UseVisualStyleBackColor = true;
            buttonClearLessons.Click += buttonClearLessons_Click;
            // 
            // EditingLessonsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonClearLessons);
            Controls.Add(groupBoxNewLesson);
            Controls.Add(listBoxShowLessons);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "EditingLessonsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Список уроков";
            groupBoxNewLesson.ResumeLayout(false);
            groupBoxNewLesson.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxShowLessons;
        private GroupBox groupBoxNewLesson;
        private Button buttonDontSaveLesson;
        private Button buttonSaveLesson;
        private Label labelTeacherOfLesson;
        private Label labelNameOfLesson;
        private TextBox textBoxNameOfLesson;
        private Button buttonRemoveLesson;
        private Button buttonClearLessons;
        private ComboBox comboBoxTeacherOfLesson;
    }
}