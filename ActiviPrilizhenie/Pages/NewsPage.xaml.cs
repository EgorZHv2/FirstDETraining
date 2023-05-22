using ActiviPrilizhenie.Data;
using ActiviPrilizhenie.Models;
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

namespace ActiviPrilizhenie.Pages
{
    /// <summary>
    /// Interaction logic for NewsPage.xaml
    /// </summary>
    public partial class NewsPage : Page
    {
        private List<NewsOutputModel> News = new List<NewsOutputModel>();
        public NewsPage()
        {
            InitializeComponent();
            var dbNews = ApplicationContext.GetContext().Novosti.ToList();
            foreach(var item in dbNews) 
            {
                News.Add(new NewsOutputModel
                {
                    Date = item.Data.ToShortDateString(),
                    Text = item.Text
                });
            }
            NewsList.ItemsSource = News;
            NewsList.Items.Refresh();
        }
    }
}
