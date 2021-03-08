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
    public partial class QLSinhVien : Form
    {
        GlobalFunction gf = new GlobalFunction();
        string table = "view_student";
        public QLSinhVien()
        {
            InitializeComponent();
        }


        private void btnLock_Click(object sender, EventArgs e)
        {
            if (grwStudent.Rows.Count <= 0)
                return;
            string id = grwStudent.CurrentRow.Cells[0].Value.ToString();
            string status = grwStudent.CurrentRow.Cells[4].Value.ToString();
            status = status.Equals("True") ? "false" : "true";
            gf.KetnoiCSDL();
            SqlCommand cmd = new SqlCommand("sp_lock_account_student", gf.myCnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("studentId", id));
            cmd.Parameters.Add(new SqlParameter("status", status));
            cmd.ExecuteNonQuery();
            gf.HienthiDulieutrenDatagridView(table, grwStudent);
            MessageBox.Show("Khóa/Mở khóa thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
        }

        private void QLSinhVien_Load(object sender, EventArgs e)
        {
            gf.HienthiDulieutrenDatagridView(table, grwStudent);
        }
    }
}
