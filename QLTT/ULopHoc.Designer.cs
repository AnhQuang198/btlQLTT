namespace QLTT
{
    partial class ULopHoc
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
            this.grwClass = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.txtJoined = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnJoined = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtGiangVien = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grwClass)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grwClass);
            this.groupBox1.Location = new System.Drawing.Point(12, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(720, 258);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách lớp đăng ký";
            // 
            // grwClass
            // 
            this.grwClass.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grwClass.Location = new System.Drawing.Point(6, 19);
            this.grwClass.Name = "grwClass";
            this.grwClass.Size = new System.Drawing.Size(708, 231);
            this.grwClass.TabIndex = 0;
            this.grwClass.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grwClass_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên lớp:";
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(85, 299);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(214, 20);
            this.txtClassName.TabIndex = 3;
            // 
            // txtJoined
            // 
            this.txtJoined.Location = new System.Drawing.Point(498, 299);
            this.txtJoined.Name = "txtJoined";
            this.txtJoined.Size = new System.Drawing.Size(214, 20);
            this.txtJoined.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(414, 302);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Đã đăng ký";
            // 
            // btnJoined
            // 
            this.btnJoined.Location = new System.Drawing.Point(127, 393);
            this.btnJoined.Name = "btnJoined";
            this.btnJoined.Size = new System.Drawing.Size(158, 23);
            this.btnJoined.TabIndex = 6;
            this.btnJoined.Text = "Đăng Ký";
            this.btnJoined.UseVisualStyleBackColor = true;
            this.btnJoined.Click += new System.EventHandler(this.btnJoined_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(429, 393);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Thoát";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txtGiangVien
            // 
            this.txtGiangVien.Location = new System.Drawing.Point(85, 345);
            this.txtGiangVien.Name = "txtGiangVien";
            this.txtGiangVien.Size = new System.Drawing.Size(214, 20);
            this.txtGiangVien.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Giảng viên:";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(498, 345);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(214, 20);
            this.txtTime.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(426, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Lịch học:";
            // 
            // LopHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 444);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtGiangVien);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnJoined);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtJoined);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Name = "LopHoc";
            this.Text = "MainUser";
            this.Load += new System.EventHandler(this.MainUser_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grwClass)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grwClass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.TextBox txtJoined;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnJoined;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtGiangVien;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label4;
    }
}