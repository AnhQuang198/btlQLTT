using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTT
{
    class GlobalFunction
    {
        //Biến dùng chung:
        public string strCon = @"Data Source=DESKTOP-8Q53BL7\SQLEXPRESS;Initial Catalog=QLTT;Integrated Security=True";
        public SqlConnection myCnn = new SqlConnection();

        //Các hàm dùng chung

        //1. Hàm kết nối cơ sở dữ liệu
        public bool KetnoiCSDL()
        {
            try
            {
                if (myCnn.State == ConnectionState.Open)
                    myCnn.Close();
                myCnn.ConnectionString = strCon;
                myCnn.Open();
            }
            catch
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu", "Thông báo");
                return false;
            }
            return true;
        }
        public void DongKetnoi()
        {
            if (myCnn.State != 0)
            {
                myCnn.Close();
            }
        }
        //2. Lấy dữ liệu đưa vào DataGridView
        public void HienthiDulieutrenDatagridView(string strSQL, DataGridView dgr)
        {
            if (KetnoiCSDL() == false)
                return;
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("Select * from " + strSQL, myCnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgr.DataSource = dt;
                da.Dispose();
                dt.Dispose();
            }
            catch
            {
                MessageBox.Show("Lỗi hiển thị dữ liệu", "Thông báo");
                return;
            }

        }

        //Phương thức xem DL
        public DataTable XemDL(string sql)
        {
            KetnoiCSDL();

            SqlDataAdapter adap = new SqlDataAdapter(sql, myCnn);
            DataTable dt = new DataTable();
            adap.Fill(dt);

            return dt;
            DongKetnoi();
        }

        //3. Lấy dữ liệu từ Combobox
        public void HienthiDulieutrenComboBox(string sTenbang, string sCotHienthi, string sCotKhoa, ComboBox cbo)
        {
            if (!KetnoiCSDL())
                return;
            string strSQL = "Select * from " + sTenbang;
            SqlDataAdapter da = new SqlDataAdapter(strSQL, myCnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbo.DataSource = dt;
            cbo.DisplayMember = sCotHienthi;
            cbo.ValueMember = sCotKhoa;

            da.Dispose();
        }
        public void dongketnoi()
        {
            if (myCnn.State == ConnectionState.Open)
            { myCnn.Close(); }
        }
        public DataTable laybang(string caulenh)
        {
            DataTable bangdulieu = new DataTable();
            try
            {
                KetnoiCSDL();
                SqlDataAdapter Adapter = new SqlDataAdapter(caulenh, myCnn);
                DataSet ds = new DataSet();

                Adapter.Fill(bangdulieu);
            }
            catch (System.Exception)
            {
                bangdulieu = null;
            }
            finally
            {
                dongketnoi();
            }

            return bangdulieu;
        }



        //4. Các hàm thao tác dữ liệu

        //4.1. Xóa
        public void Xoadulieu(string sTenbang, string sTentruongKhoa, string sGiatri)
        {
            SqlCommand cmd = new SqlCommand(sTenbang, myCnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(sTentruongKhoa, sGiatri);
            cmd.ExecuteNonQuery();
        }
    }
}
