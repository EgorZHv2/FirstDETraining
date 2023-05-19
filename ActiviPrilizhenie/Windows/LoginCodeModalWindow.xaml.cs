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
using System.Windows.Shapes;

namespace ActiviPrilizhenie.Windows
{
    /// <summary>
    /// Interaction logic for LoginCodeModalWindow.xaml
    /// </summary>
    public partial class LoginCodeModalWindow : Window
    {

        public LoginCodeModalWindow(string code)
        {
            InitializeComponent();
            CodeBox.Text = code;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
