using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopApp.Model_Class;

using System.IO; //Stream writer, reader 
using System.Net; //WebClient
using System.Text.Json; //Json serializer

using ShopApp.Frm.UserFrm;

namespace ShopApp.Frm
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public Main()
        {
            InitializeComponent();
            IsMdiContainer = true;
        }

        //  Shop Shopfrm = new Shop();
        //Cart Cartfrm = new Cart();
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }
        private void Main_Load(object sender, EventArgs e)
        {
            //  this.MdiParent = true;
            /*     Shop f = new Shop();
                 f.MdiParent = this;
                 f.Show(); */
            Shop f = new Shop();
            f.MdiParent = this;
            f.Show();
        }


        private void Shopbtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(Shop));
            if (frm != null) frm.Activate();
            else
            {
                Shop f = new Shop();
                f.MdiParent = this;
                f.Show();
            }
        }
    }
}
