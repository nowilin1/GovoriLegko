using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

        private readonly ObservableCollection<Сотрудник> _allStaff;
        public Staff()
        {
            InitializeComponent();
            _allStaff = new ObservableCollection<Сотрудник>(govorilegkoEntities.GetContext().Сотрудник.ToList());
            DGStaff.ItemsSource = _allStaff;

            Auto auto = new Auto();
            string userRole = auto.Access;
            Debug.WriteLine(userRole);
            //if (userRole == "Manager")
            //{
            //    BtnAdd.DataContext = new { VisibilityRole = Visibility.Collapsed };
            //    BtnDell.DataContext = new { VisibilityRole = Visibility.Collapsed };
            //}


        }

        private void cmbPosition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedPosition = ((ComboBoxItem)cmbPosition.SelectedItem).Content.ToString();
            List<Сотрудник> filteredStaff = govorilegkoEntities.GetContext().Сотрудник.Where(s => s.Должность == selectedPosition).ToList();
            DGStaff.ItemsSource = filteredStaff;
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            var birthdateFilterDate = BirthdateFilter.SelectedDate;
            if (birthdateFilterDate != null)
            {
                var filteredStaff = govorilegkoEntities.GetContext().Сотрудник.Where(s => s.Дата_рождения == birthdateFilterDate.Value).ToList();
                DGStaff.ItemsSource = filteredStaff;
            }
        }

        private void TxtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            string filterText = TxtFilter.Text.ToLower();
            if (string.IsNullOrEmpty(filterText))
            {
                DGStaff.ItemsSource = _allStaff;
            }
            else
            {
                var filteredList = _allStaff.Where(s => s.Фамилия.ToLower().Contains(filterText)).ToList();
                DGStaff.ItemsSource = filteredList;
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditStaff((sender as Button).DataContext as Сотрудник));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditStaff(null));
        }

        void BtnDell_Click(object sender, RoutedEventArgs e)
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

        private void TxtFilter1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
