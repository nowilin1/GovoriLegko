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
    /// Логика взаимодействия для Staff.xaml
    /// </summary>
    public partial class Staff : Page
    {
        public Staff()
        {
            InitializeComponent();
            DGStaff.ItemsSource = govorilegkoEntities.GetContext().Сотрудник.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditStaff((sender as Button).DataContext as Сотрудник));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditStaff(null));
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            var clientRemove = DGStaff.SelectedItems.Cast<Сотрудник>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {clientRemove.Count()} элементов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    govorilegkoEntities.GetContext().Сотрудник.RemoveRange(clientRemove);
                    govorilegkoEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные были успешно удалены!");
                    DGStaff.ItemsSource = govorilegkoEntities.GetContext().Сотрудник.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
