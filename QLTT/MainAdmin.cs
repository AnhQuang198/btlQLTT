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
    public partial class MainAdmin : Form
    {
        public MainAdmin()
        {
            InitializeComponent();
        }

        private void doanhNghiệpThựcTậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ADoanhNghiep form = new ADoanhNghiep();
            form.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DangNhap form = new DangNhap();
            form.Show();
            this.Hide();
        }

        private void kếtQuảHọcTậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ABaoCao form = new ABaoCao();
            form.Show();
        }
    }
}
