namespace Schedule_management.Forms
{
    partial class ReportsForm
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
            comboBoxTypeOfReport = new ComboBox();
            panelReport = new Panel();
            labelReport = new Label();
            buttonSaveReport = new Button();
            saveFileDialog1 = new SaveFileDialog();
            panelReport.SuspendLayout();
            SuspendLayout();
            // 
            // comboBoxTypeOfReport
            // 
            comboBoxTypeOfReport.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTypeOfReport.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxTypeOfReport.FormattingEnabled = true;
            comboBoxTypeOfReport.Items.AddRange(new object[] { "Отчет о нагрузке преподавателей", "Отчет о занятости обучающихся" });
            comboBoxTypeOfReport.Location = new Point(45, 74);
            comboBoxTypeOfReport.Name = "comboBoxTypeOfReport";
            comboBoxTypeOfReport.Size = new Size(481, 36);
            comboBoxTypeOfReport.TabIndex = 0;
            comboBoxTypeOfReport.SelectedIndexChanged += comboBoxTypeOfReport_SelectedIndexChanged;
            // 
            // panelReport
            // 
            panelReport.AutoScroll = true;
            panelReport.BackColor = SystemColors.ControlLight;
            panelReport.Controls.Add(labelReport);
            panelReport.Location = new Point(45, 140);
            panelReport.Name = "panelReport";
            panelReport.Size = new Size(673, 493);
            panelReport.TabIndex = 1;
            // 
            // labelReport
            // 
            labelReport.AutoSize = true;
            labelReport.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelReport.Location = new Point(21, 15);
            labelReport.Name = "labelReport";
            labelReport.Size = new Size(0, 23);
            labelReport.TabIndex = 0;
            // 
            // buttonSaveReport
            // 
            buttonSaveReport.Enabled = false;
            buttonSaveReport.Location = new Point(541, 74);
            buttonSaveReport.Name = "buttonSaveReport";
            buttonSaveReport.Size = new Size(177, 36);
            buttonSaveReport.TabIndex = 2;
            buttonSaveReport.Text = "Сохранить отчет";
            buttonSaveReport.UseVisualStyleBackColor = true;
            buttonSaveReport.Click += buttonSaveReport_Click;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.Filter = "Текстовый файл|*.txt";
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(766, 679);
            Controls.Add(buttonSaveReport);
            Controls.Add(panelReport);
            Controls.Add(comboBoxTypeOfReport);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ReportsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Отчеты";
            panelReport.ResumeLayout(false);
            panelReport.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox comboBoxTypeOfReport;
        private Panel panelReport;
        private Button buttonSaveReport;
        private Label labelReport;
        private SaveFileDialog saveFileDialog1;
    }
}