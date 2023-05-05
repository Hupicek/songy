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
using System.Media;
using Microsoft.Win32;
using System.IO;

namespace b
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string cesta = Environment.GetFolderPath (Environment.SpecialFolder.ApplicationData) + "\\hymny\\vyber.txt";
        string obsah = "";

        public MainWindow()
        {
            InitializeComponent();
         
            

           



           
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            SoundPlayer prehravac = new SoundPlayer();

            obsah = File.ReadAllText(cesta);

            if (obsah == "1")
            {
                prehravac.SoundLocation = "C:\\Users\\jan.ptacek\\AppData\\Roaming\\hymny\\hymny\\polska.wav";


            }
            else if (obsah == "2")
            {
                prehravac.SoundLocation = "C:\\Users\\jan.ptacek\\AppData\\Roaming\\hymny\\hymny\\ceska.wav";

            }

            else if (obsah == "3")
            {
                prehravac.SoundLocation = "C:\\Users\\jan.ptacek\\AppData\\Roaming\\hymny\\hymny\\slovenska.wav";

            }

            prehravac.Play();
            prehravac.PlayLooping();
            
        }

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SoundPlayer prehravac = new SoundPlayer();
            prehravac.Stop();

            using (StreamWriter writer = new StreamWriter(cesta))
            {
                writer.Write("1");
            }
            
        }

        public void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog oteviraciDialog = new OpenFileDialog();
            oteviraciDialog.Filter = "Textové soubory (*.csv)|*.csv";
            oteviraciDialog.Title = "Výběr souboru CSV";
            string obsah = "";
            if (oteviraciDialog.ShowDialog() == true)
            {
                obsah = File.ReadAllText(oteviraciDialog.FileName);
                MessageBox.Show(obsah);
            }

            
        }

        public void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SoundPlayer prehravac = new SoundPlayer();
            prehravac.Stop();
            using (StreamWriter writer = new StreamWriter(cesta))
            {
                writer.Write("2");
            }



        }

        public void Button_Click_4(object sender, RoutedEventArgs e)
        {

            SoundPlayer prehravac = new SoundPlayer();
            prehravac.Stop();
            using (StreamWriter writer = new StreamWriter(cesta))
            {
                writer.Write("3");
            }

        }
    }
}
