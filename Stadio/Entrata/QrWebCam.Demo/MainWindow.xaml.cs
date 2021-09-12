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

namespace QrWebCam.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ticket t;
        Concerto p;
        Gestione g;
        public MainWindow()
        {
            InitializeComponent();
            t = new ticket();
            p = new Concerto();
            g = new Gestione(@"C:\Users\locat\Desktop\Stadio\Memoria.txt");
            p.carica();
        }

        private void camSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            webCam.CameraIndex = camSelect.SelectedIndex;
        }

        private void QrWebCamControl_QrDecoded(object sender, string e)
        {
            t = new ticket();
            t.Nome = e.Split(';')[0];
            t.Cognome = e.Split(';')[1];
            t.partita = e.Split(';')[3];
            t.settore = e.Split(';')[2];
            t.posto = Convert.ToInt32(e.Split(';')[4]);
            t.prezzo = Convert.ToInt32(e.Split(';')[5]);
            Risultato.Content = "Questo biglietto e' di: " + t.Cognome + t.Nome + " \n " + " ed e' della partita: " + t.partita + " nel settore: " + t.settore + " al posto: " + t.posto + " al prezzo: " + t.prezzo + " euro ";
            bool esiste = p.trovaBiglietto(t);
            if (esiste == true)
                entrata.Content = " Questo biglietto e' valido \n" + "BUONA PARTITA ";
            else
                entrata.Content = " Questo biglietto  non e' valido ";

            info.Content = " l'incasso dello stadio e' di: " + p.calcolaIncasso();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            camSelect.ItemsSource = webCam.CameraNames;        
        }
    }
}
