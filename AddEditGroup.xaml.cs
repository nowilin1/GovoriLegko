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
    /// Логика взаимодействия для AddEditGroup.xaml
    /// </summary>
    public partial class AddEditGroup : Page
    {
        private Группа _currentgroup = new Группа();
        public AddEditGroup(Группа selectedgroup)
        {
            InitializeComponent();
            if (selectedgroup != null)
                _currentgroup = selectedgroup;
            DataContext = _currentgroup;
            ComboCounties.ItemsSource = new List<string> { "Развитие речи", "Окружающий мир", "Развитие мелкой моторики", "Логоритмика" };
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentgroup.Название))
                errors.AppendLine("Укажите Название");
            if (string.IsNullOrWhiteSpace(_currentgroup.Количество_человек))
                errors.AppendLine("Укажите Количество человек");
            if (DatePickerSur.SelectedDate == null)
                errors.AppendLine("Выберите Дату начала_ занятия");
            if (DatePickerSup.SelectedDate == null)
                errors.AppendLine("Выберите Дату конца занятия");
            if (ComboCounties.SelectedItem == null)
                errors.AppendLine("Выберите предмет");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentgroup.ID_Группы == 0)
                govorilegkoEntities.GetContext().Группа.Add(_currentgroup);
            try
            {
                _currentgroup.Дата_начала_занятия = DatePickerSur.SelectedDate;
                _currentgroup.Дата_конца_занятия = DatePickerSup.SelectedDate;
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
