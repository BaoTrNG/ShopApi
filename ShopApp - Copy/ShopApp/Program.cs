using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopApp.Frm;
using ShopApp.Frm.UserFrm;
namespace ShopApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static string Username { get; set; }
        [STAThread]

        static void Main()
        {
            /*  Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION",
      AppDomain.CurrentDomain.FriendlyName, 11000); */
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //  Application.Run(new Login());
            Application.Run(new Main());
            //  Application.Run(new Shop());
        }
    }
}
