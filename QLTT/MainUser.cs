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
        GlobalFunction gf = new GlobalFunction();
        string table = "view_class";
        public MainUser()
        {
            InitializeComponent();
        }

        private void MainUser_Load(object sender, EventArgs e)
        {
            gf.HienthiDulieutrenDatagridView(table, grwClass);
        }
    }
}
