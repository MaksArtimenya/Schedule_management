namespace Schedule_management
{
    partial class ConfirmationForm
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
            this.labelQuession = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelQuession
            // 
            this.labelQuession.AutoSize = true;
            this.labelQuession.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelQuession.Location = new System.Drawing.Point(142, 64);
            this.labelQuession.Name = "labelQuession";
            this.labelQuession.Size = new System.Drawing.Size(196, 41);
            this.labelQuession.TabIndex = 0;
            this.labelQuession.Text = "Вы уверены?";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(43, 183);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(135, 42);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Нет";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(298, 183);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(135, 42);
            this.buttonConfirm.TabIndex = 2;
            this.buttonConfirm.Text = "Да";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // ConfirmationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 253);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.labelQuession);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ConfirmationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Подтверждение действия";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelQuession;
        private Button buttonCancel;
        private Button buttonConfirm;
    }
}