using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTT
{
    public partial class DangKy : Form
    {
        GlobalFunction gf = new GlobalFunction();

        public DangKy()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text.Trim();
            String password = txtPassword.Text.Trim();
            String rePassword = txtRePassword.Text.Trim();
            String name = txtSvName.Text.Trim();
            String svCode = txtSvCode.Text.Trim();
            Boolean status = true;
            String role = "USER";

            if (txtUsername.Text == "" || txtPassword.Text == "" || txtRePassword.Text == "" || txtSvName.Text == "" || txtSvCode.Text == "" || gf.checkLengthText(password) || gf.checkLengthText(rePassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtUsername.Focus();
                return;
            }
            else {
                if (!password.Equals(rePassword)) {
                    MessageBox.Show("Mật khẩu nhập lại không khớp!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    gf.KetnoiCSDL();
                    SqlCommand cmd = new SqlCommand("sp_register", gf.myCnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("username", username));
                    cmd.Parameters.Add(new SqlParameter("password", password));
                    cmd.Parameters.Add(new SqlParameter("role", role));
                    cmd.Parameters.Add(new SqlParameter("status", status));
                    cmd.Parameters.Add(new SqlParameter("name", name));
                    cmd.Parameters.Add(new SqlParameter("svCode", svCode));

                    int ReturnCode = (int)cmd.ExecuteScalar();
                    if (ReturnCode == -1)
                    {
                        MessageBox.Show("Tài khoản đã tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        txtUsername.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Đăng ký thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        this.Hide();
                        DangNhap dn = new DangNhap();
                        dn.Show();
                    }
                    
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                this.Close();
        }

        private void DangKy_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnRegister;
            txtPassword.UseSystemPasswordChar = true;
            txtRePassword.UseSystemPasswordChar = true;
        }
    }
}
