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
    public partial class MainRoot : Form
    {
        public MainRoot()
        {
            InitializeComponent();
        }

        private void thêmTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLGiangVien form = new QLGiangVien();
            form.Show();
        }

        private void thêmLớpHọcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLLopHoc form = new QLLopHoc();
            form.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap dn = new DangNhap();
            dn.Show();
        }

        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLSinhVien form = new QLSinhVien();
            form.Show();
        }
    }
}
