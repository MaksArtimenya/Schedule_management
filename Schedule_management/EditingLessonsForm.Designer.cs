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
            this.listBoxShowLessons = new System.Windows.Forms.ListBox();
            this.groupBoxNewLesson = new System.Windows.Forms.GroupBox();
            this.buttonRemoveLesson = new System.Windows.Forms.Button();
            this.buttonDontSaveLesson = new System.Windows.Forms.Button();
            this.buttonSaveLesson = new System.Windows.Forms.Button();
            this.labelTeacherOfLesson = new System.Windows.Forms.Label();
            this.labelNameOfLesson = new System.Windows.Forms.Label();
            this.textBoxTeacherOfLesson = new System.Windows.Forms.TextBox();
            this.textBoxNameOfLesson = new System.Windows.Forms.TextBox();
            this.groupBoxNewLesson.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxShowLessons
            // 
            this.listBoxShowLessons.FormattingEnabled = true;
            this.listBoxShowLessons.ItemHeight = 20;
            this.listBoxShowLessons.Location = new System.Drawing.Point(50, 50);
            this.listBoxShowLessons.Name = "listBoxShowLessons";
            this.listBoxShowLessons.Size = new System.Drawing.Size(290, 304);
            this.listBoxShowLessons.TabIndex = 0;
            this.listBoxShowLessons.SelectedIndexChanged += new System.EventHandler(this.listBoxShowLessons_SelectedIndexChanged);
            // 
            // groupBoxNewLesson
            // 
            this.groupBoxNewLesson.Controls.Add(this.buttonRemoveLesson);
            this.groupBoxNewLesson.Controls.Add(this.buttonDontSaveLesson);
            this.groupBoxNewLesson.Controls.Add(this.buttonSaveLesson);
            this.groupBoxNewLesson.Controls.Add(this.labelTeacherOfLesson);
            this.groupBoxNewLesson.Controls.Add(this.labelNameOfLesson);
            this.groupBoxNewLesson.Controls.Add(this.textBoxTeacherOfLesson);
            this.groupBoxNewLesson.Controls.Add(this.textBoxNameOfLesson);
            this.groupBoxNewLesson.Location = new System.Drawing.Point(371, 50);
            this.groupBoxNewLesson.Name = "groupBoxNewLesson";
            this.groupBoxNewLesson.Size = new System.Drawing.Size(388, 304);
            this.groupBoxNewLesson.TabIndex = 1;
            this.groupBoxNewLesson.TabStop = false;
            this.groupBoxNewLesson.Text = "Новый урок";
            // 
            // buttonRemoveLesson
            // 
            this.buttonRemoveLesson.Location = new System.Drawing.Point(24, 191);
            this.buttonRemoveLesson.Name = "buttonRemoveLesson";
            this.buttonRemoveLesson.Size = new System.Drawing.Size(341, 29);
            this.buttonRemoveLesson.TabIndex = 6;
            this.buttonRemoveLesson.Text = "Удалить";
            this.buttonRemoveLesson.UseVisualStyleBackColor = true;
            this.buttonRemoveLesson.Visible = false;
            this.buttonRemoveLesson.Click += new System.EventHandler(this.buttonRemoveLesson_Click);
            // 
            // buttonDontSaveLesson
            // 
            this.buttonDontSaveLesson.Location = new System.Drawing.Point(24, 226);
            this.buttonDontSaveLesson.Name = "buttonDontSaveLesson";
            this.buttonDontSaveLesson.Size = new System.Drawing.Size(165, 51);
            this.buttonDontSaveLesson.TabIndex = 5;
            this.buttonDontSaveLesson.Text = "Сбросить";
            this.buttonDontSaveLesson.UseVisualStyleBackColor = true;
            this.buttonDontSaveLesson.Click += new System.EventHandler(this.buttonDontSaveLesson_Click);
            // 
            // buttonSaveLesson
            // 
            this.buttonSaveLesson.Location = new System.Drawing.Point(195, 226);
            this.buttonSaveLesson.Name = "buttonSaveLesson";
            this.buttonSaveLesson.Size = new System.Drawing.Size(170, 51);
            this.buttonSaveLesson.TabIndex = 4;
            this.buttonSaveLesson.Text = "Сохранить";
            this.buttonSaveLesson.UseVisualStyleBackColor = true;
            this.buttonSaveLesson.Click += new System.EventHandler(this.buttonSaveLesson_Click);
            // 
            // labelTeacherOfLesson
            // 
            this.labelTeacherOfLesson.AutoSize = true;
            this.labelTeacherOfLesson.Location = new System.Drawing.Point(24, 129);
            this.labelTeacherOfLesson.Name = "labelTeacherOfLesson";
            this.labelTeacherOfLesson.Size = new System.Drawing.Size(117, 20);
            this.labelTeacherOfLesson.TabIndex = 3;
            this.labelTeacherOfLesson.Text = "Преподаватель";
            // 
            // labelNameOfLesson
            // 
            this.labelNameOfLesson.AutoSize = true;
            this.labelNameOfLesson.Location = new System.Drawing.Point(24, 40);
            this.labelNameOfLesson.Name = "labelNameOfLesson";
            this.labelNameOfLesson.Size = new System.Drawing.Size(121, 20);
            this.labelNameOfLesson.TabIndex = 2;
            this.labelNameOfLesson.Text = "Название урока";
            // 
            // textBoxTeacherOfLesson
            // 
            this.textBoxTeacherOfLesson.Location = new System.Drawing.Point(24, 152);
            this.textBoxTeacherOfLesson.Name = "textBoxTeacherOfLesson";
            this.textBoxTeacherOfLesson.Size = new System.Drawing.Size(341, 27);
            this.textBoxTeacherOfLesson.TabIndex = 1;
            // 
            // textBoxNameOfLesson
            // 
            this.textBoxNameOfLesson.Location = new System.Drawing.Point(24, 63);
            this.textBoxNameOfLesson.Name = "textBoxNameOfLesson";
            this.textBoxNameOfLesson.Size = new System.Drawing.Size(341, 27);
            this.textBoxNameOfLesson.TabIndex = 0;
            // 
            // EditingLessonsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxNewLesson);
            this.Controls.Add(this.listBoxShowLessons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EditingLessonsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Список уроков";
            this.groupBoxNewLesson.ResumeLayout(false);
            this.groupBoxNewLesson.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox listBoxShowLessons;
        private GroupBox groupBoxNewLesson;
        private Button buttonDontSaveLesson;
        private Button buttonSaveLesson;
        private Label labelTeacherOfLesson;
        private Label labelNameOfLesson;
        private TextBox textBoxTeacherOfLesson;
        private TextBox textBoxNameOfLesson;
        private Button buttonRemoveLesson;
    }
}