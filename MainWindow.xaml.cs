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
using System.Windows.Threading;//lisätään kyseinen kirjasto, jotta voidaan käyttää Timeria

namespace AlytalosovellusAnneVaittinen2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //olioiden Olohuone ja Keittiö alustaminen
        public Lights Olohuone = new Lights();
        public Lights Keittio = new Lights();

        //olion Sauna alustaminen
        public Sauna Sauna = new Sauna();

        //olion LampotilanKasvu alustus, toiminto, joka ohjaa saunan lämpötilan kasvua
        public DispatcherTimer LampotilanKasvu = new DispatcherTimer();

        //olion LampotilanLasku alustus, ohjaa saunan lämpötilan laskua
        public DispatcherTimer LampotilanLasku = new DispatcherTimer();

        //Olion TalonLampotila alustaminen
        public Thermostat TalonLampotila = new Thermostat();

        //Astemerkin alustaminen ie asetetaan tietotyyppi
        public Char Astemerkki;

        //Prosenttimerkin alustaminen ie tietotyypin asettaminen
        public Char Prosenttimerkki;

        public MainWindow()
            //Public MainWindow() {sisältämä koodi suoritetaan kun käyttöliittymä avataan}
        {
            InitializeComponent();

            //Astemerkki
            Astemerkki = Convert.ToChar(176);

            //Prosenttimerkki
            Prosenttimerkki = Convert.ToChar(37);

            //olohuoneen valot
            Olohuone.Switched = false;
            Olohuone.Dimmer = "0";
            OlohuoneTekstikentta.Text = "off";

            //keittiön valot
            Keittio.Switched = false;
            Keittio.Dimmer = "0";
            KeittioTekstikentta.Text = "off";

            //talon lämpötila
            TalonLampotila.LampotilanAsettaminen(21);
            ViimeksiAsetettuLampotila.Text = "21" + Astemerkki + "C";
            AsetettuUusiLampotila.Text = "";

            //sauna
            Sauna.Switched = false;
            Sauna.SaunaLampotila = 0;
            Sauna.SaunaLampotilanAsetus(0);
            SaunanTila.Text = "off";

            //saunan lampötilan kasvutimer
            LampotilanKasvu.Tick += LampotilanKasvu_Tick;
            LampotilanKasvu.Interval = new TimeSpan(0, 0, 1);
            SaunanLampotilaLabel.Content = "0" + Astemerkki + "C";

            //saunan lämpötilan laskutimer
            LampotilanLasku.Tick += LampotilanLasku_Tick;
            LampotilanLasku.Interval = new TimeSpan(0, 0, 1);

           

        }


        private void OlohuonePois_Click(object sender, RoutedEventArgs e)
        {

            Olohuone.Switched = false;
            int OlohuonePois = 0;
            Olohuone.Dimmer = OlohuonePois.ToString();
            OlohuoneTekstikentta.Text = Olohuone.Dimmer + Prosenttimerkki;
            OlohuoneLiukus.Value = 0;
        }

        private void OlohuoneHamara_Click(object sender, RoutedEventArgs e)
        {
            Olohuone.Switched = true;
            int OlohuoneHamara = 33;
            Olohuone.Dimmer = OlohuoneHamara.ToString();
            OlohuoneTekstikentta.Text = Olohuone.Dimmer + Prosenttimerkki;
            OlohuoneLiukus.Value = 0;
        }

        private void OlohuonePuolivalot_Click(object sender, RoutedEventArgs e)
        {
            Olohuone.Switched = true;
            int OlohuonePuolivalot = 66;
            Olohuone.Dimmer = OlohuonePuolivalot.ToString();
            OlohuoneTekstikentta.Text = Olohuone.Dimmer + Prosenttimerkki;
            OlohuoneLiukus.Value = 0;
        }

        private void OlohuoneKirkas_Click(object sender, RoutedEventArgs e)
        {
            Olohuone.Switched = true;
            int OlohuonePuolivalot = 100;
            Olohuone.Dimmer = OlohuonePuolivalot.ToString();
            OlohuoneTekstikentta.Text = Olohuone.Dimmer + Prosenttimerkki;
            OlohuoneLiukus.Value = 0;

        }
        private void KeittioPois_Click(object sender, RoutedEventArgs e)
        {
            Keittio.Switched = false;
            int KeittioPois = 0;
            Keittio.Dimmer = KeittioPois.ToString();
            KeittioTekstikentta.Text = Keittio.Dimmer + Prosenttimerkki;
            KeittioLiukus.Value = 0;
        }

        private void KeittioHamara_Click(object sender, RoutedEventArgs e)
        {
            Keittio.Switched = true;
            int KeittioHamara = 33;
            Keittio.Dimmer = KeittioHamara.ToString();
            KeittioTekstikentta.Text = Keittio.Dimmer + Prosenttimerkki;
            KeittioLiukus.Value = 0;
        }

        private void KeittioPuolivalot_Click(object sender, RoutedEventArgs e)
        {
            Keittio.Switched = true;
            int KeittioPuolivalot = 66;
            Keittio.Dimmer = KeittioPuolivalot.ToString();
            KeittioTekstikentta.Text = Keittio.Dimmer + Prosenttimerkki;
            KeittioLiukus.Value = 0;
        }

        private void KeittioKirkas_Click(object sender, RoutedEventArgs e)
        {
            Keittio.Switched = true;
            int KeittioKirkas = 100;
            Keittio.Dimmer = KeittioKirkas.ToString();
            KeittioTekstikentta.Text = Keittio.Dimmer + Prosenttimerkki;
            KeittioLiukus.Value = 0;
        }


        private void OlohuoneLiukus_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            OlohuoneLabel.Content = (int)OlohuoneLiukus.Value + Prosenttimerkki;
            OlohuoneTekstikentta.Text = "liukukytkin käytössä";
        }

        private void KeittioLiukus_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            KeittioLabel.Content = (int)KeittioLiukus.Value + "%";
            KeittioTekstikentta.Text = "liukukytkin käytössä";
        }


        private void SaunaPaalle_Click(object sender, RoutedEventArgs e)
        {
             if (Sauna.Switched == true)
             {
                 Sauna.Switched = false;
                 Sauna.EiPaalla();
                 SaunanTila.Text = "SAUNA EI PÄÄLLÄ";
                 LampotilanLasku.Start(); //aloittaa saunan lämpötilan laskemisen (laskutimer)
             }
             else  //niin sanottu saunan normaalitila kun sauna on päällä
             {
                 Sauna.Switched = true;
                 Sauna.Paalla();
                 LampotilanKasvu.Start(); //aloittaa saunan lämpötilan nostamisen (kasvutimer)
                 SaunanTila.Text = "SAUNA PÄÄLLÄ";
             }

        }

        //saunan lämpötilan kasvutimer
        private void LampotilanKasvu_Tick(object sender, EventArgs e)

        {
            if (Sauna.SaunaLampotila > 55)
            {
                LampotilanKasvu.Stop();
            }
            Sauna.SaunaLampotila = Sauna.SaunaLampotila + 3;
            SaunanLampotilaLabel.Content = Sauna.SaunaLampotila.ToString() + Astemerkki + "C";
        }


        //saunan lämpötilan laskutimer
        private void LampotilanLasku_Tick(object sender, EventArgs e)

        {
            if (Sauna.SaunaLampotila < 8)

            {
                LampotilanLasku.Stop();
            }
            Sauna.SaunaLampotila = Sauna.SaunaLampotila - 4;
            SaunanLampotilaLabel.Content = Sauna.SaunaLampotila.ToString() + Astemerkki + "C";
        }

        private void UusiLampotila_Click(object sender, RoutedEventArgs e)
        {
            
            //try/catch menetelmällä mahdollistetaan pelkän kokonaisluvun asettaminen tekstikenttään
            int Lampotila;
            try
            {
                Lampotila = int.Parse(AsetettuUusiLampotila.Text);
                TalonLampotila.LampotilanAsettaminen(Lampotila);
                TalonLampotila.Temperature = int.Parse(AsetettuUusiLampotila.Text);//ominaisuuteen tallennetaan tavoitelämpötila
                ViimeksiAsetettuLampotila.Text = TalonLampotila.Temperature.ToString() + Astemerkki + "C";
                AsetettuUusiLampotila.Clear();
            }
            catch
            {
                MessageBox.Show("Syötä lämpötila kokonaislukuna");

            }
           
        }

    }
}




