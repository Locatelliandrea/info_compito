using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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

namespace QrWebCam.Demo
{
    /// <summary>
    /// Logica di interazione per Biglietteria.xaml
    /// </summary>
    public partial class Biglietteria : Window
    {
        ticket t;
        Concerto p;
        Gestione g;
        public Biglietteria()
        {
            InitializeComponent();
            t = new ticket();
            p = new Concerto();
            g = new Gestione(@"C:\Users\locat\Desktop\Stadio\Memoria.txt");
            p.carica();

            Settore.Items.Add("Tribuna d'onore");
            Settore.Items.Add("Curva sud");
            Settore.Items.Add("Curva nord");
            Settore.Items.Add("Lato destro");
            Settore.Items.Add("Lato sinistro");

            artista.Items.Add("Milan-Inter");
            artista.Items.Add("Milan-Roma");
            artista.Items.Add("Milan-Formellese");
            artista.Items.Add("Milan-Napoli");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int posto = 0;
            t = new ticket();
            p = new Concerto();
            t.Nome = nome.Text;
            t.Cognome = Cognome.Text;
            SetSettore();
            SetSettore();
            bool controllo = false;
            do
            {
                do
                {
                    posto = random.Next(50);
                } while (posto == 0);
                t.posto = posto;
                controllo = p.Controllo(t);
            } while (controllo == false);
            generaQr();
            p.setLista(t);
            g.aggiungi(t);
            
            Risultato.Content = "il biglietto di: " + t.Cognome + t.Nome + " e stato acquistato con successo \n";
            posti.Content = "il tuo posto e: " + t.posto + "e il costo e' di:" + t.prezzo + "Euro";
            nome.Text = "";
            Cognome.Text = "";
        }
        public void generaQr()
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(generaString(), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            try
            {
                qrCodeImage.Save(@"C:\Users\locat\Desktop\Stadio\QRcode\" + t.toCSV() + ".jpeg", ImageFormat.Jpeg);
            }
            catch (Exception)
            {
            }
        }
        public string generaString()
        {
            string tmp = t.Nome + ";" + t.Cognome + ";" + t.settore + ";" + t.artista + ";" + t.posto + ";"+ t.prezzo + ";";
            return tmp;
        }
        private void SetSettore()
        {
            if (Settore.SelectedIndex == 0)
            {
                t.settore = "Tribuna d'onore";
                t.prezzo = 100;
            }
            if (Settore.SelectedIndex == 1)
            {
                t.settore = "Rosso";
                t.prezzo = 40;
            }
            if (Settore.SelectedIndex == 2)
            {
                t.settore = "Blu";
                t.prezzo = 40;
            }

            if (Settore.SelectedIndex == 3)
            {
                t.settore = "Giallo";
                t.prezzo = 60;
            }
            if (Settore.SelectedIndex == 4)
            {
                t.settore = "Verde";
                t.prezzo = 60;
            }

        }
        private void Setartista()
        {

            if (artista.SelectedIndex == 0)
                t.artista = "Tedua";
            if (artista.SelectedIndex == 1)
                t.artista = "blanco";
            if (artista.SelectedIndex == 2)
                t.artista = "il tre";
            if (artista.SelectedIndex == 3)
                t.artista = "lazza";

        }

        private void cerca_Click(object sender, RoutedEventArgs e)
        {
            MainWindow a = new MainWindow(p);
            this.Hide();
            a.Show();
        }
    }
}

