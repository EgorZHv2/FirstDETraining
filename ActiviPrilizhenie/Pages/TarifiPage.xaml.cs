using ActiviPrilizhenie.Data;
using ActiviPrilizhenie.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for TarifiPage.xaml
    /// </summary>
    public partial class TarifiPage : Page
    {
        public Visibility SubsctibeVisibility { get; set; }

        private List<TarifiOutputModel> Tarifis = new List<TarifiOutputModel>();

        public TarifiPage()
        {
            InitializeComponent();

            var dBTarifi = ApplicationContext.GetContext().Tarifi.ToList();
            foreach (var item in dBTarifi)
            {
                Tarifis.Add(
                    new TarifiOutputModel
                    {
                        Id = item.Id,
                        Cost = item.CenaZaMesatc,
                        Name = item.Nazvanie,
                        Opisanie = item.Opisanie
                    }
                );
            }
            TarifisList.ItemsSource = Tarifis;
            
            TarifisList.Items.Refresh();
        }

        

        private void Subscribe_Click(object sender, RoutedEventArgs e) 
        {
            var abonent = ApplicationContext
                .GetContext()
                .Abonenti.FirstOrDefault(en => en.IdPolzovatela == UserData.UserId);
            var userTarif = ApplicationContext
                .GetContext()
                .TarifiAbonentov.FirstOrDefault(en => en.IdAbonenta == abonent.Id);
            var a =   TarifisList.SelectedItem as TarifiOutputModel;
           
            if(a.Id == userTarif.IdTarifa)
            {
                MessageBox.Show("У вас уже есть этот тариф");
                return;
            }
            userTarif.IdTarifa = a.Id;
            ApplicationContext.GetContext().TarifiAbonentov.AddOrUpdate(userTarif);
            ApplicationContext.GetContext().SaveChanges();
            TarifisList.Items.Refresh();
            TarifisList.UpdateLayout();
            var aaa = Tarifis.FirstOrDefault(ee => ee.Id == userTarif.IdTarifa);
            var item = (ListBoxItem)TarifisList.ItemContainerGenerator.ContainerFromItem(aaa);
            item.Background = new SolidColorBrush(Colors.Red);
        }

        private void TarifisList_Loaded(object sender, RoutedEventArgs e)
        {
            var abonent = ApplicationContext
                .GetContext()
                .Abonenti.FirstOrDefault(en => en.IdPolzovatela == UserData.UserId);
            var userTarif = ApplicationContext
                .GetContext()
                .TarifiAbonentov.FirstOrDefault(en => en.IdAbonenta == abonent.Id);
            var aaa = Tarifis.FirstOrDefault(ee => ee.Id == userTarif.IdTarifa);
            var item = (ListBoxItem)TarifisList.ItemContainerGenerator.ContainerFromItem(aaa);
            item.Background = new SolidColorBrush(Colors.Red);

           
        }
       
    }
}
