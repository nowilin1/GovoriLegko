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
    /// Логика взаимодействия для AddEditRecording.xaml
    /// </summary>
    public partial class AddEditRecording : Page
    {
        private RecordingViewModel _viewModel = new RecordingViewModel();
        public AddEditRecording()
        {
            InitializeComponent();
            DataContext = new
            {
                Клиент = new Клиент(),
                Группа = new Группа(),
                Сотрудники = new Сотрудник(),
                Представитель = new Представитель()
            };
            ComboCounties.ItemsSource = new List<string> { "1", "2", "3", "4", "5" };
            ComboCounties1.ItemsSource = new List<string> { "Группа раннего развития" };
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(((dynamic)DataContext).Клиент.Фамилия))
                errors.AppendLine("Укажите Фамилия");
            if (string.IsNullOrWhiteSpace(((dynamic)DataContext).Клиент.Имя))
                errors.AppendLine("Укажите Имя");
            if (string.IsNullOrWhiteSpace(((dynamic)DataContext).Клиент.Отчество))
                errors.AppendLine("Укажите Отчество");      
            if (string.IsNullOrWhiteSpace(((dynamic)DataContext).Представитель.Фамилия))
                errors.AppendLine("Укажите Фамилия");
            if (string.IsNullOrWhiteSpace(((dynamic)DataContext).Представитель.Имя))
                errors.AppendLine("Укажите Имя");
            if (string.IsNullOrWhiteSpace(((dynamic)DataContext).Представитель.Отчество))
                errors.AppendLine("Укажите Отчество");         
            if (string.IsNullOrWhiteSpace(((dynamic)DataContext).Представитель.Номер_телефона))
                errors.AppendLine("Укажите Номер телефона");           
            if (DatePickerSup.SelectedDate == null)
                errors.AppendLine("Выберите Дату рождения");
            if (ComboCounties.SelectedItem == null)
                errors.AppendLine("Выберите Уровень знания");
            if (ComboCounties1.SelectedItem == null)
                errors.AppendLine("Выберите Название группы");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (((dynamic)DataContext).Клиент.ID_Клиента== 0)
                govorilegkoEntities.GetContext().Клиент.Add(((dynamic)DataContext).Клиент);
            if (((dynamic)DataContext).Представитель.ID_Представитель == 0)
                govorilegkoEntities.GetContext().Представитель.Add(((dynamic)DataContext).Представитель);
            try
            {
                ((dynamic)DataContext).Клиент.Дата_рождения = DatePickerSup.SelectedDate;
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
