namespace QLTT
{
    partial class UDoanhNghiep
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grwCompany = new System.Windows.Forms.DataGridView();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.specilized = new System.Windows.Forms.ComboBox();
            this.position = new System.Windows.Forms.ComboBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grwCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grwCompany);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(721, 250);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Doanh Nghiệp";
            // 
            // grwCompany
            // 
            this.grwCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grwCompany.Location = new System.Drawing.Point(6, 19);
            this.grwCompany.Name = "grwCompany";
            this.grwCompany.Size = new System.Drawing.Size(709, 225);
            this.grwCompany.TabIndex = 0;
            // 
            // dateStart
            // 
            this.dateStart.Location = new System.Drawing.Point(126, 276);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(225, 20);
            this.dateStart.TabIndex = 1;
            // 
            // dateEnd
            // 
            this.dateEnd.Location = new System.Drawing.Point(126, 322);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(225, 20);
            this.dateEnd.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thời gian bắt đầu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Thời gian kết thúc:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 409);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Vị trí:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Chuyên ngành:";
            // 
            // specilized
            // 
            this.specilized.FormattingEnabled = true;
            this.specilized.Items.AddRange(new object[] {
            "CNPM",
            "CNĐPT"});
            this.specilized.Location = new System.Drawing.Point(126, 362);
            this.specilized.Name = "specilized";
            this.specilized.Size = new System.Drawing.Size(225, 21);
            this.specilized.TabIndex = 7;
            // 
            // position
            // 
            this.position.FormattingEnabled = true;
            this.position.Items.AddRange(new object[] {
            "INTERN"});
            this.position.Location = new System.Drawing.Point(126, 406);
            this.position.Name = "position";
            this.position.Size = new System.Drawing.Size(225, 21);
            this.position.TabIndex = 8;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(448, 276);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(279, 23);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "Đăng Ký";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(448, 323);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(279, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Đóng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UDoanhNghiep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 443);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.position);
            this.Controls.Add(this.specilized);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateEnd);
            this.Controls.Add(this.dateStart);
            this.Controls.Add(this.groupBox1);
            this.Name = "UDoanhNghiep";
            this.Text = "UDoanhNghiep";
            this.Load += new System.EventHandler(this.UDoanhNghiep_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grwCompany)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grwCompany;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox specilized;
        private System.Windows.Forms.ComboBox position;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button button1;
    }
}