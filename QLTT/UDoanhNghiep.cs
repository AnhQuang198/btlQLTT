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
    public partial class UDoanhNghiep : Form
    {
        GlobalFunction gf = new GlobalFunction();
        string table = "view_company";
        public UDoanhNghiep()
        {
            InitializeComponent();
        }

        private void UDoanhNghiep_Load(object sender, EventArgs e)
        {
            position.SelectedIndex = 0;
            specilized.SelectedIndex = 0;
            specilized.SelectedIndex = 1;
            gf.HienthiDulieutrenDatagridView(table, grwCompany);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (grwCompany.Rows.Count <= 0)
                return;
            int id = Int32.Parse(grwCompany.CurrentRow.Cells[0].Value.ToString());
            int userId = User.UserID;
            int studentId = getStudentByUserId(userId);
            if (checkStudentRegisterCompany(id, studentId) == false)
            {
                gf.KetnoiCSDL();
                SqlCommand cmd = new SqlCommand("sp_add_student_company", gf.myCnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("companyId", id));
                cmd.Parameters.Add(new SqlParameter("userId", userId));
                cmd.Parameters.Add(new SqlParameter("timeStart", dateStart.Value.ToString("yyyy-MM-dd")));
                cmd.Parameters.Add(new SqlParameter("timeEnd", dateEnd.Value.ToString("yyyy-MM-dd")));
                cmd.Parameters.Add(new SqlParameter("position", position.SelectedItem.ToString()));
                cmd.Parameters.Add(new SqlParameter("specialized", specilized.SelectedItem.ToString()));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Đăng ký thực tập thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                gf.HienthiDulieutrenDatagridView(table, grwCompany);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool checkStudentRegisterCompany(int companyId, int studentId)
        {
            bool flag = false;
            gf.KetnoiCSDL();
            SqlCommand cmd = new SqlCommand("sp_check_regis_company", gf.myCnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("studentId", studentId));
            cmd.Parameters.Add(new SqlParameter("companyId", companyId));
            int id = (int)cmd.ExecuteScalar();
            if (id > 0)
            {
                MessageBox.Show("Bạn đã đăng ký thực tập tại doanh nghiệp này!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                flag = true;
            }
            return flag;
        }

        private int getStudentByUserId(int userId)
        {
            string sql = "select id from tblStudent where userId='" + userId + "'";
            SqlCommand cmd = new SqlCommand(sql, gf.myCnn);
            cmd.CommandType = CommandType.Text;
            int id = (int)cmd.ExecuteScalar();
            return id;
        }
    }
}
