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
    public partial class LopHoc : Form
    {
        GlobalFunction gf = new GlobalFunction();
        string table = "view_class";
        public LopHoc()
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

            //SqlCommand cmd = new SqlCommand("sp_add_student_class", gf.myCnn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add(new SqlParameter("studentId", 5));
            //cmd.Parameters.Add(new SqlParameter("classId", classId));
            //cmd.ExecuteNonQuery();

            MessageBox.Show(studentId.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private int getStudentByUserId(int userId)
        {
            string sql = "select id from tblStudent where userId='" + userId + "'";
            SqlCommand cmd = new SqlCommand(sql, gf.myCnn);
            cmd.CommandType = CommandType.Text;

            int id = (int)cmd.ExecuteScalar();

            //int id = Convert.ToInt32(cmd.ExecuteScalar());

            MessageBox.Show(id.ToString(), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            return id;
        }
    }
}
