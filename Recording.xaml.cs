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
    /// Логика взаимодействия для Recording.xaml
    /// </summary>
    public partial class Recording : Page
    {
        public Recording()
        {
            InitializeComponent();
            DGRecord.ItemsSource = govorilegkoEntities.GetContext().View_1.ToList();
        }
        //private void BtnEdit_Click(object sender, RoutedEventArgs e)
        //{
        //    Manager.MainFrame.Navigate(new AddEditRecording((sender as Button).DataContext as Клиент ));
        //}

        //private void BtnDell_Click(object sender, RoutedEventArgs e)
        //{
        //    var clientRemove = DGRecord.SelectedItems.Cast<View_1>().ToList();
        //    if (MessageBox.Show($"Вы точно хотите удалить следующие {clientRemove.Count()} элементов?", "Внимание",
        //            MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        //    {
        //        try
        //        {
        //            govorilegkoEntities.GetContext().View_1.RemoveRange(clientRemove);
        //            govorilegkoEntities.GetContext().SaveChanges();
        //            MessageBox.Show("Данные были успешно удалены!");
        //            DGRecord.ItemsSource = govorilegkoEntities.GetContext().View_1.ToList();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message.ToString());
        //        }
        //    }
        //}

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditRecording());
            DGRecord.ItemsSource = govorilegkoEntities.GetContext().View_1.ToList();

        }
    }
}
