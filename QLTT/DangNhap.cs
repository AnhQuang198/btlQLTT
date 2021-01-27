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
                
                if (role.Equals("none"))
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không chính xác!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        txtUsername.Focus();
                    }
                    if (role.Equals("USER"))
                    {
                        MessageBox.Show("Đăng nhập thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        this.Hide();
                    getUserId(username, password);
                    MainUser userScreen = new MainUser();
                        userScreen.Show();
                    }
                    else if (role.Equals("ADMIN")) {
                        MessageBox.Show("Đăng nhập thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        this.Hide();
                    getUserId(username, password);
                    MainAdmin adminScreen = new MainAdmin();
                        adminScreen.Show();

                    }
                    else if(role.Equals("ROOT")) {
                        MessageBox.Show("Đăng nhập thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                        this.Hide();
                    getUserId(username, password);
                    MainRoot rootScreen = new MainRoot();
                        rootScreen.Show();
                    }
            }
        }

        private void getUserId(string username, string password) {
            SqlCommand cmd2 = new SqlCommand("sp_login_return_id", gf.myCnn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(new SqlParameter("username", username));
            cmd2.Parameters.Add(new SqlParameter("password", password));
            int userId = (Int32)cmd2.ExecuteScalar();
            User.UserID = userId;
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
