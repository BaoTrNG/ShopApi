using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopApp.Frm;
using ShopApp.Frm.UserFrm;
using ShopApp.Model_Class;
namespace ShopApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static string Username;
        public static TempCart tempCart;
        public static TempCart testCart;
        public static bool isload;
        public static List<Order> tempOrder;
        public static bool isdoneload;
        public static string UserType;
        public static string phone;
        [STAThread]

        static void Main()
        {
            tempOrder = new List<Order>();
            isload = false;
            isdoneload = false;
            // IsValid = 0;
            /*  Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
      AppDomain.CurrentDomain.FriendlyName, 11000); */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
            // Application.Run(new Main());
            //  Application.Run(new Shop());
        }
    }
}
