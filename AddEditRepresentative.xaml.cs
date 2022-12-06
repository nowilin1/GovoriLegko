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
    /// Логика взаимодействия для AddEditRepresentative.xaml
    /// </summary>
    public partial class AddEditRepresentative : Page
    {
        private Представитель _currentrep = new Представитель();
        public AddEditRepresentative(Представитель selectedrep)
        {
            InitializeComponent();
            if (selectedrep != null)
                _currentrep = selectedrep;
            DataContext = _currentrep;

        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentrep.Фамилия))
                errors.AppendLine("Укажите Фамилия");
            if (string.IsNullOrWhiteSpace(_currentrep.Имя))
                errors.AppendLine("Укажите Имя");
            if (string.IsNullOrWhiteSpace(_currentrep.Отчество))
                errors.AppendLine("Укажите Отчество");
            if (string.IsNullOrWhiteSpace(_currentrep.Номер_телефона))
                errors.AppendLine("Укажите Номер телефона");
            
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentrep.ID_Представитель == 0)
                govorilegkoEntities.GetContext().Представитель.Add(_currentrep);
            try
            {
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
