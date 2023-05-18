using ActiviPrilizhenie.Pages;
using System;
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

namespace ActiviPrilizhenie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigationHelper.AddPageChangedEventHandler(ChangePageHandler);
            NavigationHelper.ChangePage(new LoginPage());
           
        }
        public void ChangePageHandler()
        {
            MainFrame.Content = NavigationHelper.GetCurrentPage();
        }
    }
}
