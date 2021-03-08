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
    public partial class UCapNhat : Form
    {
        GlobalFunction gf = new GlobalFunction();
        public UCapNhat()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string maSv = txtMaSV.Text;
            string name = txtName.Text;
            int userId = User.UserID;

            if (maSv != "" && name != "") 
            {
                gf.KetnoiCSDL();
                SqlCommand cmd = new SqlCommand("sp_edit_user", gf.myCnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("userId", userId));
                cmd.Parameters.Add(new SqlParameter("svCode", maSv));
                cmd.Parameters.Add(new SqlParameter("name", name));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
        }

        private void UCapNhat_Load(object sender, EventArgs e)
        {
            int userId = User.UserID;
            gf.KetnoiCSDL();
            SqlCommand cmd = new SqlCommand("sp_view_student_code", gf.myCnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("userId", userId));
            string svCode = (string)cmd.ExecuteScalar();
            SqlCommand cmd2 = new SqlCommand("sp_view_student_name", gf.myCnn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(new SqlParameter("userId", userId));
            string name = (string)cmd2.ExecuteScalar();
            txtMaSV.Text = svCode;
            txtName.Text = name;
        }
    }
}
