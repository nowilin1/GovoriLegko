using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GovoriLegko
{
    /// <summary>
    /// Логика взаимодействия для Record.xaml
    /// </summary>
    public partial class Record : Window
    {
        public Record()
        {
            InitializeComponent();
            DGRecord.ItemsSource = govorilegkoEntities.GetContext().View_1.ToList();
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            //Manager.MainFrame.Navigate(new AddEditStaff((sender as Button).DataContext as View_1));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Manager.MainFrame.Navigate(new AddEditStaff(null));
        }
        
        private void BtnDell_Ckick(object sender, RoutedEventArgs e)
        {
            //Manager.MainFrame.Navigate(new AddEditStaff(null));
        }
    }
}
