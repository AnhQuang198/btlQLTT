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
    public partial class ULopHoc : Form
    {
        GlobalFunction gf = new GlobalFunction();
        string table = "view_class";
        public ULopHoc()
        {
            InitializeComponent();
        }

        private void MainUser_Load(object sender, EventArgs e)
        {
            gf.HienthiDulieutrenDatagridView(table, grwClass);
            txtClassName.ReadOnly = true;
            txtJoined.ReadOnly = true;
            txtGiangVien.ReadOnly = true;
            txtTime.ReadOnly = true;
        }

        private void grwClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grwClass.Rows.Count <= 0)
                return;
            txtClassName.Text = grwClass.CurrentRow.Cells[1].Value.ToString();
            txtGiangVien.Text = grwClass.CurrentRow.Cells[2].Value.ToString();
            txtTime.Text = grwClass.CurrentRow.Cells[6].Value.ToString();
            string svJoined = grwClass.CurrentRow.Cells[5].Value.ToString();
            string svRegMax = grwClass.CurrentRow.Cells[4].Value.ToString();
            string sv = svJoined + "/" + svRegMax;
            txtJoined.Text = sv;
        }

        private void btnJoined_Click(object sender, EventArgs e)
        {
            int classId = Int32.Parse(grwClass.CurrentRow.Cells[0].Value.ToString());
            int userId = User.UserID;
            int studentId = getStudentByUserId(userId);

            if (checkStudentRegisterClass(classId, studentId) == false)
            {
                SqlCommand cmd = new SqlCommand("sp_add_student_class", gf.myCnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("studentId", studentId));
                cmd.Parameters.Add(new SqlParameter("classId", classId));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Đăng ký lớp thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                gf.HienthiDulieutrenDatagridView(table, grwClass);
            }
        }

        private int getStudentByUserId(int userId)
        {
            string sql = "select id from tblStudent where userId='" + userId + "'";
            SqlCommand cmd = new SqlCommand(sql, gf.myCnn);
            cmd.CommandType = CommandType.Text;
            int id = (int)cmd.ExecuteScalar();
            return id;
        }

        private bool checkStudentRegisterClass(int classId, int studentId) {
            bool flag = false;
            gf.KetnoiCSDL();
            SqlCommand cmd = new SqlCommand("sp_check_regis_class", gf.myCnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("studentId", studentId));
            cmd.Parameters.Add(new SqlParameter("classId", classId));
            int id = (int)cmd.ExecuteScalar();
            if(id > 0)
            {
                MessageBox.Show("Bạn đã đăng ký lớp này!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                flag = true;
            }
            return flag;
        }
    }
}
