﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ActiviPrilizhenie.Pages
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
            NavigationHelper.AddMenuPageChangedEventHandler(ChangePageHandler);
            NavigationHelper.ChangeMenuPage(new NewsPage());
        }
        public void ChangePageHandler()
        {
            MenuFrame.Content = NavigationHelper.GetCurrentMenuPage();
        }

        private void ToNews_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.ChangeMenuPage(new NewsPage());
        }

        private void ToTarifs_Click(object sender, RoutedEventArgs e)
        {
            NavigationHelper.ChangeMenuPage(new TarifiPage());
        }
    }
}
