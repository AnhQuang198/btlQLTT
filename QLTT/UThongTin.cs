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
    public partial class UThongTin : Form
    {
        GlobalFunction gf = new GlobalFunction();
        public UThongTin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            UCapNhat form = new UCapNhat();
            form.Show();
            this.Close();
        }

        private void UThongTin_Load(object sender, EventArgs e)
        {
            txtName.ReadOnly = true;
            txtSvCode.ReadOnly = true;
            txtUsername.ReadOnly = true;

            int userId = User.UserID;
            gf.KetnoiCSDL();
            SqlCommand cmd = new SqlCommand("sp_view_student_code", gf.myCnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("userId", userId));
            string svCode = (string)cmd.ExecuteScalar();
            SqlCommand cmd2 = new SqlCommand("sp_view_student_name", gf.myCnn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.Add(new SqlParameter("userId", userId));
            string name = (string)cmd2.ExecuteScalar();
            SqlCommand cmd3 = new SqlCommand("sp_view_student_username", gf.myCnn);
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.Parameters.Add(new SqlParameter("userId", userId));
            string username = (string)cmd3.ExecuteScalar();
            txtSvCode.Text = svCode;
            txtName.Text = name;
            txtUsername.Text = username;
        }
    }
}
