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
    public partial class DangNhap : Form
    {
        GlobalFunction gf = new GlobalFunction();
        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnLogin;
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text.Trim();
            String password = txtPassword.Text.Trim();

            if (txtUsername.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tài khoản hoặc mật khẩu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtUsername.Focus();
                return;
            }
            else
            {
                gf.KetnoiCSDL();
                SqlCommand cmd = new SqlCommand("sp_login", gf.myCnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("username", username));
                cmd.Parameters.Add(new SqlParameter("password", password));

                string role = (string)cmd.ExecuteScalar();
                if (role == null) {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    if (role.Equals("USER"))
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        this.Hide();
                        MainUser userScreen = new MainUser();
                        userScreen.Show();
                    }
                    else if (role.Equals("ADMIN")) {
                        MessageBox.Show("Đăng nhập thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        this.Hide();
                        MainAdmin adminScreen = new MainAdmin();
                        adminScreen.Show();
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        this.Hide();
                        MainRoot rootScreen = new MainRoot();
                        rootScreen.Show();
                    }
                }
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            DangKy form = new DangKy();
            form.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                this.Close();
        }

        private void ckShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }
    }
}
