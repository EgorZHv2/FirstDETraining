using ActiviPrilizhenie.Data;
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
    /// Interaction logic for AddZayavkaPage.xaml
    /// </summary>
    public partial class AddZayavkaPage : Page
    {
        public AddZayavkaPage()
        {
            InitializeComponent();
        }

        private void SubmitBT_Click(object sender, RoutedEventArgs e)
        {
            var entity = new Adresa();
            entity.Strana = Strana.Text;
            entity.Oblast = Oblast.Text;
            entity.Rayon = Rayon.Text;
            entity.Gorod = Gorod.Text;
            entity.Ulica = Ulica.Text;
            entity.Dom = Dom.Text;
            entity.Dolgota = Dolgota.Text;
            entity.Shirota = Shirota.Text;
            entity.Id = Guid.NewGuid();
            ApplicationContext.GetContext().Adresa.Add(entity);
            ApplicationContext.GetContext().SaveChanges();
            var zayavka = new Zayavki();
            string nazvanieTipa = "";
            if(UserData.Role == UserRole.None)
            {
                nazvanieTipa = "Подключение";
            }
            else if(UserData.Role == UserRole.Abonent) 
            {
                nazvanieTipa = "Обслуживание";
                zayavka.IdPolzovatela = UserData.UserId;
            }

            var tipzayavki = ApplicationContext.GetContext().TipiZayavok.FirstOrDefault(ee => ee.Nazvanie == nazvanieTipa);
            zayavka.IdTipaZayavki = tipzayavki.Id;
            zayavka.TextZayavki = TextZayavki.Text;
            zayavka.IdAdresa = entity.Id;
            ApplicationContext.GetContext().Zayavki.Add(zayavka);
            ApplicationContext.GetContext().SaveChanges();
        }
    }
}
