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
    public partial class ADoanhNghiep : Form
    {
        GlobalFunction gf = new GlobalFunction();
        string table = "view_company";
        public ADoanhNghiep()
        {
            InitializeComponent();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (grwCompany.Rows.Count <= 0)
                return;
            string id = grwCompany.CurrentRow.Cells[0].Value.ToString();
            gf.KetnoiCSDL();
            SqlCommand cmd = new SqlCommand("sp_del_company", gf.myCnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("companyId", id));
            cmd.ExecuteNonQuery();
            gf.HienthiDulieutrenDatagridView(table, grwCompany);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string address = txtAdd.Text;
            int userId = User.UserID;

            if(name != "" && phone != "" && address != "")
            {
                gf.KetnoiCSDL();
                SqlCommand cmd = new SqlCommand("sp_add_company", gf.myCnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("name", name));
                cmd.Parameters.Add(new SqlParameter("phone", phone));
                cmd.Parameters.Add(new SqlParameter("address", address));
                cmd.Parameters.Add(new SqlParameter("userId", userId));
                cmd.ExecuteNonQuery();
                gf.HienthiDulieutrenDatagridView(table, grwCompany);
            }
            else
            {
                if (MessageBox.Show("Vui lòng nhập đủ thông tin!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK);
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grwCompany.Rows.Count <= 0)
                return;
            string id = grwCompany.CurrentRow.Cells[0].Value.ToString();

            gf.KetnoiCSDL();
            SqlCommand cmd = new SqlCommand("sp_edit_company", gf.myCnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("name", txtName.Text));
            cmd.Parameters.Add(new SqlParameter("phone", txtPhone.Text));
            cmd.Parameters.Add(new SqlParameter("address", txtAdd.Text));
            cmd.Parameters.Add(new SqlParameter("id", id));
            cmd.ExecuteNonQuery();
            gf.HienthiDulieutrenDatagridView(table, grwCompany);
        }

        private void ADoanhNghiep_Load(object sender, EventArgs e)
        {
            gf.HienthiDulieutrenDatagridView(table, grwCompany);
        }

        private void grwCompany_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = grwCompany.CurrentRow.Cells[1].Value.ToString();
            txtPhone.Text = grwCompany.CurrentRow.Cells[2].Value.ToString();
            txtAdd.Text = grwCompany.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
