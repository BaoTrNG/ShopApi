namespace ShopApp.Frm
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.Shopbtn = new DevExpress.XtraBars.BarButtonItem();
            this.Cartbtn = new DevExpress.XtraBars.BarButtonItem();
            this.Orderbtn = new DevExpress.XtraBars.BarButtonItem();
            this.Userbtn = new DevExpress.XtraBars.BarButtonItem();
            this.AdminItems = new DevExpress.XtraBars.BarButtonItem();
            this.AdminOrder = new DevExpress.XtraBars.BarButtonItem();
            this.AdminUser = new DevExpress.XtraBars.BarButtonItem();
            this.Userpage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.AdminPage = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataSource = typeof(ShopApp.Model_Class.Items);
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup1;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup1});
            this.navBarControl1.Location = new System.Drawing.Point(0, 183);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 200;
            this.navBarControl1.Size = new System.Drawing.Size(200, 267);
            this.navBarControl1.TabIndex = 1;
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "navBarGroup1";
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // ribbonPageCategory1
            // 
            this.ribbonPageCategory1.Name = "ribbonPageCategory1";
            this.ribbonPageCategory1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage2});
            this.ribbonPageCategory1.Text = "ribbonPageCategory1";
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(26, 30, 26, 30);
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.Shopbtn,
            this.Cartbtn,
            this.Orderbtn,
            this.Userbtn,
            this.AdminItems,
            this.AdminOrder,
            this.AdminUser});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 9;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsMenuMinWidth = 289;
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.Userpage,
            this.AdminPage});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2019;
            this.ribbonControl1.Size = new System.Drawing.Size(1339, 193);
            // 
            // Shopbtn
            // 
            this.Shopbtn.Caption = "Shop";
            this.Shopbtn.Id = 1;
            this.Shopbtn.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Shopbtn.ImageOptions.Image")));
            this.Shopbtn.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("Shopbtn.ImageOptions.LargeImage")));
            this.Shopbtn.Name = "Shopbtn";
            this.Shopbtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Shopbtn_ItemClick);
            // 
            // Cartbtn
            // 
            this.Cartbtn.Caption = "Giỏ Hàng";
            this.Cartbtn.Id = 2;
            this.Cartbtn.ImageOptions.ImageIndex = 1;
            this.Cartbtn.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("Cartbtn.ImageOptions.LargeImage")));
            this.Cartbtn.Name = "Cartbtn";
            this.Cartbtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Cartbtn_ItemClick);
            // 
            // Orderbtn
            // 
            this.Orderbtn.Caption = "Đơn Hàng";
            this.Orderbtn.Id = 4;
            this.Orderbtn.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("Orderbtn.ImageOptions.LargeImage")));
            this.Orderbtn.Name = "Orderbtn";
            this.Orderbtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Orderbtn_ItemClick);
            // 
            // Userbtn
            // 
            this.Userbtn.Caption = "User";
            this.Userbtn.Id = 5;
            this.Userbtn.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("Userbtn.ImageOptions.LargeImage")));
            this.Userbtn.Name = "Userbtn";
            this.Userbtn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.Userbtn_ItemClick);
            // 
            // AdminItems
            // 
            this.AdminItems.Caption = "Quản Lý Sản Phẩm";
            this.AdminItems.Id = 6;
            this.AdminItems.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("AdminItems.ImageOptions.LargeImage")));
            this.AdminItems.Name = "AdminItems";
            this.AdminItems.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.AdminItems_ItemClick);
            // 
            // AdminOrder
            // 
            this.AdminOrder.Caption = "Quản Lý Đơn Hàng";
            this.AdminOrder.Id = 7;
            this.AdminOrder.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("AdminOrder.ImageOptions.LargeImage")));
            this.AdminOrder.Name = "AdminOrder";
            this.AdminOrder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.AdminOrder_ItemClick);
            // 
            // AdminUser
            // 
            this.AdminUser.Caption = "Quản Lý User";
            this.AdminUser.Id = 8;
            this.AdminUser.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("AdminUser.ImageOptions.LargeImage")));
            this.AdminUser.Name = "AdminUser";
            this.AdminUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.AdminUser_ItemClick);
            // 
            // Userpage
            // 
            this.Userpage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.Userpage.Name = "Userpage";
            this.Userpage.Text = "Người Dùng";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.Shopbtn, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.Cartbtn, true);
            this.ribbonPageGroup1.ItemLinks.Add(this.Orderbtn);
            this.ribbonPageGroup1.ItemLinks.Add(this.Userbtn);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // AdminPage
            // 
            this.AdminPage.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4});
            this.AdminPage.Name = "AdminPage";
            this.AdminPage.Text = "Admin";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.AdminItems);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.AdminOrder);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.AdminUser);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1339, 800);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Location = new System.Drawing.Point(260, 100);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Main";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_Closing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem Shopbtn;
        private DevExpress.XtraBars.BarButtonItem Cartbtn;
        private DevExpress.XtraBars.Ribbon.RibbonPage Userpage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem Orderbtn;
        private DevExpress.XtraBars.BarButtonItem Userbtn;
        private DevExpress.XtraBars.Ribbon.RibbonPage AdminPage;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem AdminItems;
        private DevExpress.XtraBars.BarButtonItem AdminOrder;
        private DevExpress.XtraBars.BarButtonItem AdminUser;
    }
}