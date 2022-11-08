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


        public static string JwtToken;

        //thay doi dia chi call api tại đây
        //api login
        public const string APILogin = "https://shopapiptithcm.azurewebsites.net/api/loginv2";
        public const string APIRegister = "https://shopapiptithcm.azurewebsites.net/api/createuser";
        public const string APICheckid = "https://shopapiptithcm.azurewebsites.net/api/create/checkid";
        public const string APICheckMail = "https://shopapiptithcm.azurewebsites.net/api/create/checkemail";
        public const string APICreateTempCart = "https://shopapiptithcm.azurewebsites.net/api/createcart";
        public const string APIGetAdminPhone = "https://shopapiptithcm.azurewebsites.net/api/getadminphone";

        //api shop
        public const string APIGetItems = "https://shopapiptithcm.azurewebsites.net/api/getitemsv2";
        public const string APIFindOrder = "https://shopapiptithcm.azurewebsites.net/api/findorder";
        public const string APIFindCart = "https://shopapiptithcm.azurewebsites.net/api/findcart";
        public const string APICheckRemain = "https://shopapiptithcm.azurewebsites.net/api/checkremain";
        public const string APIUpdateCart = "https://shopapiptithcm.azurewebsites.net/api/updatecart";

        //api cart
        public const string APICreateOrder = "https://shopapiptithcm.azurewebsites.net/api/createorder";
        public const string APICheckItem = "https://shopapiptithcm.azurewebsites.net/api/checkitemv2";
        //APIUpdateCart
        //APIFindCart

        //api order
        public const string APIUpdateOrder = "https://shopapiptithcm.azurewebsites.net/api/updateorder";
        public const string APIGetOrderStatus = "https://shopapiptithcm.azurewebsites.net/api/getorderstatus/";

        //api user
        public const string APIUpdateUser = "https://shopapiptithcm.azurewebsites.net/api/userorders";
        public const string APIUpdatePhone = "https://shopapiptithcm.azurewebsites.net/api/updatephone";
        public const string APIUpdatePass = "https://shopapiptithcm.azurewebsites.net/api/updatepass";

        ////ADMIN API 
        ///Admin Shop
        // APIGetItems
        public const string APICheckItemId = "https://shopapiptithcm.azurewebsites.net/api/checkitemid/";
        public const string APICreateItem = "https://shopapiptithcm.azurewebsites.net/api/createitem";
        public const string APIDeleteItem = "https://shopapiptithcm.azurewebsites.net/api/deleteitem/";
        public const string APIUpdateItem = "https://shopapiptithcm.azurewebsites.net/api/updateitem";


        /// Admin Order
        public const string APIGetOrders = "https://shopapiptithcm.azurewebsites.net/api/getorder";
        public const string APIUpdateOrderAdmin = "https://shopapiptithcm.azurewebsites.net/api/updateorderadmin";

        ///Admin user
        public const string APIGetUsers = "https://shopapiptithcm.azurewebsites.net/api/getalluser";
        public const string APIUpdateUserAdmin = "https://shopapiptithcm.azurewebsites.net/api/updateuseradmin";
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
