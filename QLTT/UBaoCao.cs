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
    public partial class UBaoCao : Form
    {
        GlobalFunction gf = new GlobalFunction();
        public UBaoCao()
        {
            InitializeComponent();
        }

        private void UBaoCao_Load(object sender, EventArgs e)
        {
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            string docUrl = txtDocUrl.Text;
            string sourceUrl = txtSourceUrl.Text;
            int userId = User.UserID;
            int studentId = getStudentByUserId(userId);
            if (docUrl == "" || sourceUrl == "")
            {
                MessageBox.Show("Vui lòng nhập đủ đường dẫn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            else
            {
                    gf.KetnoiCSDL();
                    SqlCommand cmd = new SqlCommand("sp_add_intern_process", gf.myCnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@studentId", studentId));
                    cmd.Parameters.Add(new SqlParameter("@docUrl", docUrl));
                    cmd.Parameters.Add(new SqlParameter("@gitUrl", sourceUrl));
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã gửi báo cáo tới giảng viên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                    this.Close();
            }
        }

        private int getStudentByUserId(int userId)
        {
            string sql = "select id from tblStudent where userId='" + userId + "'";
            gf.KetnoiCSDL();
            SqlCommand cmd = new SqlCommand(sql, gf.myCnn);
            cmd.CommandType = CommandType.Text;
            int id = (int)cmd.ExecuteScalar();
            return id;
        }
    }
}
