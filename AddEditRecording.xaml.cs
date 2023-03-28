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
using static GovoriLegko.AddEditRecording;

namespace GovoriLegko
{
    /// <summary>
    /// Логика взаимодействия для AddEditRecording.xaml
    /// </summary>
    public partial class AddEditRecording : Page
    {
        public class ViewModel
        {
            public Клиент _currentclient { get; set; }
            public Группа _currentgroup { get; set; }
            public Сотрудник _currentsotr { get; set; }
            public Представитель _currentrep { get; set; }
        }
        private ViewModel _viewModel = new ViewModel();
        public AddEditRecording(Клиент selectedview, Группа selectedgroup, Сотрудник selectedsotr, Представитель selectedrep)
        {
            InitializeComponent();
            if (selectedview != null)
                _viewModel._currentclient = selectedview;

            if (selectedgroup != null)
                _viewModel._currentgroup = selectedgroup;

            if (selectedsotr != null)
                _viewModel._currentsotr = selectedsotr;

            if (selectedrep != null)
                _viewModel._currentrep = selectedrep;
            DataContext = _viewModel;
            ComboCounties.ItemsSource = new List<string> { "1", "2", "3", "4", "5" };
            ComboCounties1.ItemsSource = new List<string> { "Логопед", "Дефектолог" };
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_viewModel._currentclient.Фамилия))
                errors.AppendLine("Укажите Фамилия");
            if (string.IsNullOrWhiteSpace(_viewModel._currentclient.Имя))
                errors.AppendLine("Укажите Имя");
            if (string.IsNullOrWhiteSpace(_viewModel._currentclient.Отчество))
                errors.AppendLine("Укажите Отчество");
            if (string.IsNullOrWhiteSpace(_viewModel._currentclient.Фамилия))
                errors.AppendLine("Укажите Фамилию представителя");            
            if (string.IsNullOrWhiteSpace(_viewModel._currentrep.Имя))
                errors.AppendLine("Укажите Имя");            
            if (string.IsNullOrWhiteSpace(_viewModel._currentrep.Отчество))
                errors.AppendLine("Укажите Отчество");            
            if (string.IsNullOrWhiteSpace(_viewModel._currentrep.Номер_телефона))
                errors.AppendLine("Укажите Номер телефона");            
            if (string.IsNullOrWhiteSpace(_viewModel._currentgroup.Название))
                errors.AppendLine("Укажите Название группы");            
            if (string.IsNullOrWhiteSpace(_viewModel._currentgroup.Предмет))
                errors.AppendLine("Укажите Предмет");            
            //if (string.IsNullOrWhiteSpace(_currentsotr.Expr4))
            //    errors.AppendLine("Укажите Сотрудника");
            if (DatePickerSup.SelectedDate == null)
                errors.AppendLine("Выберите Дату рождения");
            if (ComboCounties.SelectedItem == null)
                errors.AppendLine("Выберите Уровень знания");
            if (ComboCounties1.SelectedItem == null)
                errors.AppendLine("Выберите Должность сотрудника");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_viewModel._currentclient.ID_Клиента== 0)
                govorilegkoEntities.GetContext().Клиент.Add(_viewModel._currentclient);
            try
            {
                _viewModel._currentclient.Дата_рождения = DatePickerSup.SelectedDate;
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
