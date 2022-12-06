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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Клиент _currentclient = new Клиент();
        public AddEditPage(Клиент selectedclient)
        {
            InitializeComponent();
            if (selectedclient != null)
                _currentclient = selectedclient;
            DataContext = _currentclient;
            ComboCounties.ItemsSource = new List<string> { "1", "2", "3", "4", "5"};

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentclient.Фамилия))
                errors.AppendLine("Укажите Фамилия");
            if (string.IsNullOrWhiteSpace(_currentclient.Имя))
                errors.AppendLine("Укажите Имя");
            if (string.IsNullOrWhiteSpace(_currentclient.Отчество))
                errors.AppendLine("Укажите Отчество");
            if (DatePickerSup.SelectedDate == null)
                errors.AppendLine("Выберите Дату рождения");
            if (ComboCounties.SelectedItem == null)
                errors.AppendLine("Выберите уровень знания");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentclient.ID_Клиента == 0)
                govorilegkoEntities.GetContext().Клиент.Add(_currentclient);
            try
            {
                _currentclient.Дата_рождения = DatePickerSup.SelectedDate;
                govorilegkoEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
