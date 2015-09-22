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

namespace MNN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            idade.Visibility = Visibility.Hidden;
            //tabelaPitagorica tp = new tabelaPitagorica();
            //leitura l = tp.efetuaLeitura("Diogo Bernini Milagres", DateTime.Today);
        }

        private int calculaIdade(){
            DateTime atual = DateTime.Today;
            DateTime usuario = new DateTime();
            usuario = data.SelectedDate.Value;
            idade.Visibility = Visibility.Visible;
            int id;

            if (atual.Month < usuario.Month || (usuario.Month == atual.Month && atual.Day < usuario.Day)){
                id = (atual.Year - 1 - usuario.Year);
            } else {
                id = (atual.Year - usuario.Year);
            }

            idade.Content = id.ToString();
            return id;
        }


        private void gerar_Click(object sender, RoutedEventArgs e)
        {
            calculaIdade();
            tabelaPitagorica tp = new tabelaPitagorica();
            leitura l = tp.efetuaLeitura(nome.Text, data.SelectedDate.Value);
            MO.Content = l.MO.ToString();
            EU.Content = l.EU.ToString();
            EX.Content = l.EX.ToString();
            CD.Content = l.CD.ToString();
            C1.Content = l.C1.ToString();
            C2.Content = l.C2.ToString();
            C3.Content = l.C3.ToString();
            D1.Content = l.D1.ToString();
            D2.Content = l.D2.ToString();
            DM.Content = l.DM.ToString();
            R1.Content = l.R1.ToString();
            R2.Content = l.R2.ToString();
            R3.Content = l.R3.ToString();
            R4.Content = l.R4.ToString();
        }
    }
}
