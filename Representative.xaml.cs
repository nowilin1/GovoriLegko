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
    /// Логика взаимодействия для Representative.xaml
    /// </summary>
    public partial class Representative : Page
    {
        public Representative()
        {
            InitializeComponent();
            DGRepresentative.ItemsSource = govorilegkoEntities.GetContext().Представитель.ToList();

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditRepresentative(null));

        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditRepresentative((sender as Button).DataContext as Представитель));
        }
        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            var clientRemove = DGRepresentative.SelectedItems.Cast<Представитель>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {clientRemove.Count()} элементов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    govorilegkoEntities.GetContext().Представитель.RemoveRange(clientRemove);
                    govorilegkoEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные были успешно удалены!");
                    DGRepresentative.ItemsSource = govorilegkoEntities.GetContext().Представитель.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
