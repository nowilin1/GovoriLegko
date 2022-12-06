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
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Page
    {
        public Client()
        {
            InitializeComponent();

            //UpdateClient();
            DGClient.ItemsSource = govorilegkoEntities.GetContext().Клиент.ToList();
            //ComboType.ItemsSource = new List<string> { "1", "2", "3", "4", "5" };
            //ComboType.SelectedIndex = 0;
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Клиент));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnDell_Click(object sender, RoutedEventArgs e)
        {
            var clientRemove = DGClient.SelectedItems.Cast<Клиент>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {clientRemove.Count()} элементов?", "Внимание",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    govorilegkoEntities.GetContext().Клиент.RemoveRange(clientRemove);
                    govorilegkoEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные были успешно удалены!");
                    DGClient.ItemsSource = govorilegkoEntities.GetContext().Клиент.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        //private void UpdateClient()
        //{
        //    var currentmat = DGClient.SelectedItems.Cast<Клиент>().ToList();
        //    if (ComboType.SelectedIndex > 0)
        //    {
        //        currentmat = currentmat.Where(p => p.Уровень_знаний.Contains(ComboType.SelectedItem.ToString())).ToList();
        //    }
        //    currentmat = currentmat.Where(p => p.Фамилия.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();


        //}

        //private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    UpdateClient();
        //}

        //private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    UpdateClient();
        //}
    }
}

