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
    public partial class QLLopHoc : Form
    {
        GlobalFunction gf = new GlobalFunction();
        string table = "view_class";
        public QLLopHoc()
        {
            InitializeComponent();
        }

        private void QLLopHoc_Load(object sender, EventArgs e)
        {
            gf.HienthiDulieutrenDatagridView(table, grwClass);
            gf.HienthiDulieutrenComboBox("tblTeacher", "name", "name", comboBox1);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
                SqlCommand cmd = new SqlCommand("sp_add_class", gf.myCnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("name", txtName.Text));
                cmd.Parameters.Add(new SqlParameter("svMin", txtSvRegMin.Text));
                cmd.Parameters.Add(new SqlParameter("svMax", txtSvRegMax.Text));
                cmd.Parameters.Add(new SqlParameter("gvName", comboBox1.SelectedValue));
                cmd.Parameters.Add(new SqlParameter("time", dateTimeline.Value.ToString("yyyy-MM-dd")));
                cmd.ExecuteNonQuery();
                gf.HienthiDulieutrenDatagridView(table, grwClass);
                txtName.Text = null;
                txtSvRegMin.Text = null;
                txtSvRegMax.Text = null;
                cmd.Dispose();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (grwClass.Rows.Count <= 0)
                return;
            string id = grwClass.CurrentRow.Cells[0].Value.ToString();
            SqlCommand cmd = new SqlCommand("sp_edit_class", gf.myCnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("id", id));
            cmd.Parameters.Add(new SqlParameter("name", txtName.Text));
            cmd.Parameters.Add(new SqlParameter("svMin", txtSvRegMin.Text));
            cmd.Parameters.Add(new SqlParameter("svMax", txtSvRegMax.Text));
            cmd.Parameters.Add(new SqlParameter("gvName", comboBox1.SelectedValue));
            cmd.Parameters.Add(new SqlParameter("time", dateTimeline.Value.ToString("yyyy-MM-dd")));
            cmd.ExecuteNonQuery();
            gf.HienthiDulieutrenDatagridView(table, grwClass);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = grwClass.CurrentRow.Cells[0].Value.ToString();
            gf.KetnoiCSDL();
            SqlCommand cmd = new SqlCommand("sp_delete_class", gf.myCnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("classId", id));
            cmd.ExecuteNonQuery();
            gf.HienthiDulieutrenDatagridView(table, grwClass);
            txtName.Text = null;
            txtSvRegMin.Text = null;
            txtSvRegMax.Text = null;
            cmd.Dispose();
        }

        private void grwClass_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = grwClass.CurrentRow.Cells[1].Value.ToString();
            txtSvRegMin.Text = grwClass.CurrentRow.Cells[3].Value.ToString();
            txtSvRegMax.Text = grwClass.CurrentRow.Cells[4].Value.ToString();
        }

    }
}
