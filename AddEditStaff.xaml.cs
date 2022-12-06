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
    /// Логика взаимодействия для AddEditStaff.xaml
    /// </summary>
    public partial class AddEditStaff : Page
    {
        private Сотрудник _currentstaff = new Сотрудник();
        public AddEditStaff(Сотрудник selectedstaff)
        {
            InitializeComponent();
            if (selectedstaff != null)
                _currentstaff = selectedstaff;
            DataContext = _currentstaff;
            ComboCounties.ItemsSource = new List<string> { "Логопед", "Менеджер", "Администратор" };
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentstaff.Фамилия))
                errors.AppendLine("Укажите Фамилия");
            if (string.IsNullOrWhiteSpace(_currentstaff.Имя))
                errors.AppendLine("Укажите Имя");
            if (string.IsNullOrWhiteSpace(_currentstaff.Отчество))
                errors.AppendLine("Укажите Отчество");
            if (DatePickerSup.SelectedDate == null)
                errors.AppendLine("Выберите дату рождения");
            if (string.IsNullOrWhiteSpace(_currentstaff.Номер_телефона))
                errors.AppendLine("Укажите номер телефона");
            if (ComboCounties.SelectedItem == null)
                errors.AppendLine("Выберите должность");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentstaff.ID_Сотрудника == 0)
                govorilegkoEntities.GetContext().Сотрудник.Add(_currentstaff);
            try
            {
                _currentstaff.Дата_рождения = DatePickerSup.SelectedDate;
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
