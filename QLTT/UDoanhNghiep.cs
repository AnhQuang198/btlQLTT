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
            ComboboxItem intern = new ComboboxItem();
            intern.Text = "INTERN";
            intern.Value = "INTERN";
            position.Items.Add(intern);

            ComboboxItem cnpm = new ComboboxItem();
            cnpm.Text = "CNPM";
            cnpm.Value = "CNPM";
            specilized.Items.Add(cnpm);

            ComboboxItem cndpt = new ComboboxItem();
            cndpt.Text = "CNPM";
            cndpt.Value = "CNPM";
            specilized.Items.Add(cndpt);

            gf.HienthiDulieutrenDatagridView(table, grwCompany);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (grwCompany.Rows.Count <= 0)
                return;
            string id = grwCompany.CurrentRow.Cells[0].Value.ToString();
            int userId = User.UserID;
            gf.KetnoiCSDL();
            SqlCommand cmd = new SqlCommand("sp_add_student_company", gf.myCnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("companyId", id));
            cmd.Parameters.Add(new SqlParameter("userId", userId));
            cmd.Parameters.Add(new SqlParameter("timeStart", dateStart.Value.ToString("yyyy-MM-dd")));
            cmd.Parameters.Add(new SqlParameter("timeEnd", dateEnd.Value.ToString("yyyy-MM-dd")));
            cmd.Parameters.Add(new SqlParameter("position", position.SelectedValue.ToString()));
            cmd.Parameters.Add(new SqlParameter("specialized", specilized.SelectedValue.ToString()));
            cmd.ExecuteNonQuery();
            MessageBox.Show("Đăng ký thực tập thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            gf.HienthiDulieutrenDatagridView(table, grwCompany);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
