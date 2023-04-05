
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

namespace GovoriLegko
{
    /// <summary>
    /// Логика взаимодействия для knopkiadmin.xaml
    /// </summary>
    public partial class knopkiadmin : Page
    {
        public knopkiadmin()
        {
            InitializeComponent();
        }
        
        public void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Client());
        }

        public void BtnAttendance_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Schedule());
        }

        public void BtnLesson_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Lesson());
        }

        public void BtnGroup_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Group());
        }

        public void BtnStaff_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Staff());
        }

        public void BtnRepresentative_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Representative());
        }
        public void BtnRecord_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditRecording());
        }

        private void BtnPayment_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Payment());
        }

        private void BtnPayments_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Payments());
        }
    }
}
