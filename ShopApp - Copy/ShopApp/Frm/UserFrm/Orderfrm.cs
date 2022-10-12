using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp.Frm.UserFrm
{
    public partial class Orderfrm : DevExpress.XtraEditors.XtraForm
    {
        public Orderfrm()
        {
            InitializeComponent();
        }

        private void Order_Load(object sender, EventArgs e)
        {
            Program.tempOrder.OrderBy(p => p.status);
            gridControl1.DataSource = Program.tempOrder;

            gridView1.OptionsBehavior.Editable = false;
            //  gridView1.Columns["admins"].Visible = false;

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Clicked");



        }
    }
}