namespace Schedule_management
{
    partial class SelectLessonForm
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
            this.listBoxShowAvaibleLessons = new System.Windows.Forms.ListBox();
            this.groupBoxShowInformationAboutSelectedLesson = new System.Windows.Forms.GroupBox();
            this.labelTeacherOfLesson = new System.Windows.Forms.Label();
            this.labelNameOfLesson = new System.Windows.Forms.Label();
            this.textBoxTeacherOfLesson = new System.Windows.Forms.TextBox();
            this.textBoxNameOfLesson = new System.Windows.Forms.TextBox();
            this.buttonSaveSelectedLesson = new System.Windows.Forms.Button();
            this.groupBoxShowInformationAboutSelectedLesson.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxShowAvaibleLessons
            // 
            this.listBoxShowAvaibleLessons.FormattingEnabled = true;
            this.listBoxShowAvaibleLessons.ItemHeight = 20;
            this.listBoxShowAvaibleLessons.Location = new System.Drawing.Point(50, 50);
            this.listBoxShowAvaibleLessons.Name = "listBoxShowAvaibleLessons";
            this.listBoxShowAvaibleLessons.Size = new System.Drawing.Size(340, 364);
            this.listBoxShowAvaibleLessons.TabIndex = 0;
            this.listBoxShowAvaibleLessons.SelectedIndexChanged += new System.EventHandler(this.listBoxShowAvaibleLessons_SelectedIndexChanged);
            // 
            // groupBoxShowInformationAboutSelectedLesson
            // 
            this.groupBoxShowInformationAboutSelectedLesson.Controls.Add(this.labelTeacherOfLesson);
            this.groupBoxShowInformationAboutSelectedLesson.Controls.Add(this.labelNameOfLesson);
            this.groupBoxShowInformationAboutSelectedLesson.Controls.Add(this.textBoxTeacherOfLesson);
            this.groupBoxShowInformationAboutSelectedLesson.Controls.Add(this.textBoxNameOfLesson);
            this.groupBoxShowInformationAboutSelectedLesson.Location = new System.Drawing.Point(429, 50);
            this.groupBoxShowInformationAboutSelectedLesson.Name = "groupBoxShowInformationAboutSelectedLesson";
            this.groupBoxShowInformationAboutSelectedLesson.Size = new System.Drawing.Size(343, 209);
            this.groupBoxShowInformationAboutSelectedLesson.TabIndex = 1;
            this.groupBoxShowInformationAboutSelectedLesson.TabStop = false;
            this.groupBoxShowInformationAboutSelectedLesson.Text = "Выбранный урок";
            // 
            // labelTeacherOfLesson
            // 
            this.labelTeacherOfLesson.AutoSize = true;
            this.labelTeacherOfLesson.Location = new System.Drawing.Point(25, 125);
            this.labelTeacherOfLesson.Name = "labelTeacherOfLesson";
            this.labelTeacherOfLesson.Size = new System.Drawing.Size(117, 20);
            this.labelTeacherOfLesson.TabIndex = 3;
            this.labelTeacherOfLesson.Text = "Преподаватель";
            // 
            // labelNameOfLesson
            // 
            this.labelNameOfLesson.AutoSize = true;
            this.labelNameOfLesson.Location = new System.Drawing.Point(25, 39);
            this.labelNameOfLesson.Name = "labelNameOfLesson";
            this.labelNameOfLesson.Size = new System.Drawing.Size(121, 20);
            this.labelNameOfLesson.TabIndex = 2;
            this.labelNameOfLesson.Text = "Название урока";
            // 
            // textBoxTeacherOfLesson
            // 
            this.textBoxTeacherOfLesson.Location = new System.Drawing.Point(25, 148);
            this.textBoxTeacherOfLesson.Name = "textBoxTeacherOfLesson";
            this.textBoxTeacherOfLesson.ReadOnly = true;
            this.textBoxTeacherOfLesson.Size = new System.Drawing.Size(290, 27);
            this.textBoxTeacherOfLesson.TabIndex = 1;
            // 
            // textBoxNameOfLesson
            // 
            this.textBoxNameOfLesson.Location = new System.Drawing.Point(25, 62);
            this.textBoxNameOfLesson.Name = "textBoxNameOfLesson";
            this.textBoxNameOfLesson.ReadOnly = true;
            this.textBoxNameOfLesson.Size = new System.Drawing.Size(290, 27);
            this.textBoxNameOfLesson.TabIndex = 0;
            // 
            // buttonSaveSelectedLesson
            // 
            this.buttonSaveSelectedLesson.Location = new System.Drawing.Point(429, 336);
            this.buttonSaveSelectedLesson.Name = "buttonSaveSelectedLesson";
            this.buttonSaveSelectedLesson.Size = new System.Drawing.Size(343, 78);
            this.buttonSaveSelectedLesson.TabIndex = 2;
            this.buttonSaveSelectedLesson.Text = "Сохранить";
            this.buttonSaveSelectedLesson.UseVisualStyleBackColor = true;
            this.buttonSaveSelectedLesson.Visible = false;
            this.buttonSaveSelectedLesson.Click += new System.EventHandler(this.buttonSaveSelectedLesson_Click);
            // 
            // SelectLessonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonSaveSelectedLesson);
            this.Controls.Add(this.groupBoxShowInformationAboutSelectedLesson);
            this.Controls.Add(this.listBoxShowAvaibleLessons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SelectLessonForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выберите урок";
            this.groupBoxShowInformationAboutSelectedLesson.ResumeLayout(false);
            this.groupBoxShowInformationAboutSelectedLesson.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox listBoxShowAvaibleLessons;
        private GroupBox groupBoxShowInformationAboutSelectedLesson;
        private Label labelNameOfLesson;
        private TextBox textBoxTeacherOfLesson;
        private TextBox textBoxNameOfLesson;
        private Label labelTeacherOfLesson;
        private Button buttonSaveSelectedLesson;
    }
}