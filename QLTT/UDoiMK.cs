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
    public partial class UDoiMK : Form
    {
        GlobalFunction gf = new GlobalFunction();
        public UDoiMK()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string newPass = txtNewPass.Text;
            string rePass = txtRePass.Text;
            int userId = User.UserID;
            if ( newPass == "" || rePass == "" || gf.checkLengthText(newPass) || gf.checkLengthText(rePass))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }else
            {
                if (!newPass.Equals(rePass))
                {
                    MessageBox.Show("Mật khẩu mới và mật khẩu nhập lại không trùng khớp!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    gf.KetnoiCSDL();
                    SqlCommand cmd = new SqlCommand("sp_edit_password", gf.myCnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("userId", userId));
                    cmd.Parameters.Add(new SqlParameter("password", newPass));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cập nhật mật khẩu thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    this.Close();
                }
            }
        }

        private void UDoiMK_Load(object sender, EventArgs e)
        {
            txtNewPass.UseSystemPasswordChar = true;
            txtRePass.UseSystemPasswordChar = true;
        }
    }
}
