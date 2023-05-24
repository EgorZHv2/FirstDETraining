using Microsoft.Win32;
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
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using ActiviPrilizhenie.Data;

namespace ActiviPrilizhenie.Pages
{
    /// <summary>
    /// Interaction logic for OplataPage.xaml
    /// </summary>
    public partial class OplataPage : Page
    {
        public OplataPage()
        {
            InitializeComponent();
        }

        private void GenerateOrderBT_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Pdf files(*.pfd)|*.pdf";
            
            dialog.ShowDialog();
            var filepath = dialog.FileName;
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            var abonent = ApplicationContext.GetContext().Abonenti.FirstOrDefault(ee => ee.IdPolzovatela == UserData.UserId);
            var tarifabonenta = ApplicationContext.GetContext().TarifiAbonentov.FirstOrDefault(ee => ee.IdAbonenta == abonent.Id);
            var tarif = ApplicationContext.GetContext().Tarifi.FirstOrDefault(ee => ee.Id == tarifabonenta.IdTarifa);
            XFont font = new XFont("Calibri", 20, XFontStyle.Regular);
            gfx.DrawString("Квитанция:",font,XBrushes.Black,0,10);
            gfx.DrawString("Абонент: " + abonent.Familia + " " + abonent.Imya,font,XBrushes.Black,0,30);
            gfx.DrawString("Тариф: " + tarif.Nazvanie,font,XBrushes.Black,0,50);
            gfx.DrawString("Стоимость: " + tarif.CenaZaMesatc,font,XBrushes.Black,0,70);
            document.Save(filepath);
        }
    }
}
