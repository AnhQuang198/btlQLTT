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
    public partial class ABaoCao : Form
    {
        GlobalFunction gf = new GlobalFunction();
        string table = "view_process";
        public ABaoCao()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABaoCao_Load(object sender, EventArgs e)
        {
            gf.HienthiDulieutrenDatagridView(table, gwBaoCao);
        }

        private void btnDanhGia_Click(object sender, EventArgs e)
        {
            int processId = Int32.Parse(gwBaoCao.CurrentRow.Cells[0].Value.ToString());
            int point = Int32.Parse(txtPoint.Text);

            if (txtPoint.Text != "")
            {
                gf.KetnoiCSDL();
                SqlCommand cmd = new SqlCommand("sp_add_result_process", gf.myCnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@pocess", processId));
                cmd.Parameters.Add(new SqlParameter("@point", point));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Đã đánh giá báo cáo sinh viên!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            else
            {

                MessageBox.Show("Vui lòng nhập điểm!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }
    }
}
