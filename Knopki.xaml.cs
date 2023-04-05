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
    /// Логика взаимодействия для Knopki.xaml
    /// </summary>
    public partial class Knopki : Page
    {
        public Knopki()
        {
            InitializeComponent();
        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Client());

        }

        private void BtnGroup_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Group());
        }

        private void BtnLesson_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Lesson());
        }

        private void BtnAttendance_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Schedule());
        }

        private void BtnNote_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Note());
        }
    }
}
