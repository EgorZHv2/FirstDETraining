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
        private static Page CurrentPage { get; set; }
        public delegate void NavigationDelegate();
        private static event NavigationDelegate PageChanged;

        public static void ChangePage(Page page)
        {
            CurrentPage = page;
            PageChanged();
        }
        public static void AddPageChangedEventHandler(NavigationDelegate handler)
        {
            PageChanged += handler;
        }
        public static Page GetCurrentPage()
        {
            return CurrentPage;
        }
    }
}