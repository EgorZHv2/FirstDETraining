using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace ActiviPrilizhenie
{
    public class NavigationHelper
    {
        private static Page CurrentMainPage { get; set; }
        private static Page CurrentMenuPage { get; set; }
        public delegate void NavigationDelegate();
        private static event NavigationDelegate MainPageChanged;
        private static event NavigationDelegate MenuPageChanged;

        public static void ChangeMainPage(Page page)
        {
            CurrentMainPage = page;
            MainPageChanged();
        }
        public static void AddMainPageChangedEventHandler(NavigationDelegate handler)
        {
            MainPageChanged += handler;
        }
        public static Page GetCurrentMainPage()
        {
            return CurrentMainPage;
        }

        public static void ChangeMenuPage(Page page)
        {
            CurrentMenuPage = page;
            MenuPageChanged();
        }
        public static void AddMenuPageChangedEventHandler(NavigationDelegate handler)
        {
            MenuPageChanged += handler;
        }
        public static Page GetCurrentMenuPage()
        {
            return CurrentMenuPage;
        }
    }
}