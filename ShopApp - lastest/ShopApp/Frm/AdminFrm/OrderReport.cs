using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ShopApp.Model_Class;
using System.Text.Json;
using System.Collections.Generic;
using DevExpress.XtraPrinting;

namespace ShopApp.Frm.AdminFrm
{
    partial class OrderReport : DevExpress.XtraReports.UI.XtraReport
    {

        public OrderReport(Order order)
        {
            InitializeComponent();
            DateTime dateTime = DateTime.Now;

            IDlb.Text = "Mã Đơn Hàng: " + order.id;
            Buyerlb.Text = "Người Mua: " + order.buyer;
            Addresslb.Text = "Địa Chỉ: " + order.address;
            Phonelb.Text = "Số Điện Thoại: " + order.phone;
            Datelb.Text = "Ngày Đặt: " + order.date;
            Paymentlb.Text = "Phương Thức Thanh Toán: " + order.payment;
            DeliDatelb.Text = "Ngày Giao: " + dateTime.ToString("dd-MM-yyyy HH:mm:ss"); // for 24hr format
            string Price = string.Format("{0:#,##0.00}", order.total);

            Totallb.Text = "Tổng Tiền: " + Price + "VNĐ";
            //  string json = JsonSerializer.Serialize(order);
            //  Console.WriteLine(json);
            //   ReportPrintTool printTool = new ReportPrintTool(new OrderReport(order));
            // printTool.ShowRibbonPreview();
            //printTool.ShowPreview();
        }

        public void createtable(Order order)
        {

        }

    }
}
