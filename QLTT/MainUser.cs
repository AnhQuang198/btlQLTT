using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTT
{
    public partial class MainUser : Form
    {
        public MainUser()
        {
            InitializeComponent();
        }

        private void đăngKýLớpHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ULopHoc lop = new ULopHoc();
            lop.MdiParent = this.MdiParent;
            lop.Show();
        }

        private void đăngKýThựcTậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UDoanhNghiep form = new UDoanhNghiep();
            form.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                this.Hide();
            DangNhap frm = new DangNhap();
            frm.Show();
            this.Close();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UDoiMK form = new UDoiMK();
            form.Show();
        }

        private void cậpNhậtThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCapNhat form = new UCapNhat();
            form.Show();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UThongTin form = new UThongTin();
            form.Show();
        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UBaoCao form = new UBaoCao();
            form.Show();
        }
    }
}
