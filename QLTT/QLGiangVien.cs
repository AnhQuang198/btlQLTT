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
    public partial class QLGiangVien : Form
    {
        GlobalFunction gf = new GlobalFunction();
        string table = "view_teacher";
        public QLGiangVien()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text.Trim();
            String password = txtPassword.Text.Trim();
            String name = txtName.Text.Trim();
            Boolean status = true;
            String role = "ADMIN";

            gf.KetnoiCSDL();
            SqlCommand cmd = new SqlCommand("sp_register_teacher", gf.myCnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("username", username));
            cmd.Parameters.Add(new SqlParameter("password", password));
            cmd.Parameters.Add(new SqlParameter("role", role));
            cmd.Parameters.Add(new SqlParameter("status", status));
            cmd.Parameters.Add(new SqlParameter("name", name));

            int ReturnCode = (int)cmd.ExecuteScalar();
            if (ReturnCode == -1)
            {
                MessageBox.Show("Tài khoản đã tồn tại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                txtUsername.Focus();
            }
            else
            {
                gf.HienthiDulieutrenDatagridView(table, grwTeacher);
                txtName.Text = null;
                txtPassword.Text = null;
                txtUsername.Text = null;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grwTeacher.Rows.Count <= 0)
                return;
            string id = grwTeacher.CurrentRow.Cells[0].Value.ToString();
            string name = txtName.Text;
            string password = txtPassword.Text;
            if (name != "" && password != null)
            {
                gf.KetnoiCSDL();
                SqlCommand cmd = new SqlCommand("sp_edit_teacher", gf.myCnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("id", id));
                cmd.Parameters.Add(new SqlParameter("name", name));
                cmd.Parameters.Add(new SqlParameter("password", password));
                cmd.ExecuteNonQuery();
                gf.HienthiDulieutrenDatagridView(table, grwTeacher);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }

        }

        private void QLGiangVien_Load(object sender, EventArgs e)
        {
            gf.HienthiDulieutrenDatagridView(table, grwTeacher);
            txtPassword.UseSystemPasswordChar = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (grwTeacher.Rows.Count <= 0)
                return;
            string id = grwTeacher.CurrentRow.Cells[0].Value.ToString();
            string status = grwTeacher.CurrentRow.Cells[3].Value.ToString();
            status = status.Equals("True") ? "false" : "true";
            gf.KetnoiCSDL();
            SqlCommand cmd = new SqlCommand("sp_lock_account_teacher", gf.myCnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("teacherId", id));
            cmd.Parameters.Add(new SqlParameter("status", status));
            cmd.ExecuteNonQuery();
            gf.HienthiDulieutrenDatagridView(table, grwTeacher);
        }

        private void grwTeacher_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = grwTeacher.CurrentRow.Cells[1].Value.ToString();
            txtUsername.Text = grwTeacher.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
