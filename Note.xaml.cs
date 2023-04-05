using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Note.xaml
    /// </summary>
    public partial class Note : Page
    {
        public Note()
        {
            InitializeComponent();
            DataContext = new
            {
                Заметка = new Заметка(),
                Клиент = new Клиент()
            };
        }

        private void BtnNote_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(((dynamic)DataContext).Заметка.Фамилия))
                errors.AppendLine("Укажите Фамилию");
            if (string.IsNullOrWhiteSpace(((dynamic)DataContext).Заметка.Имя))
                errors.AppendLine("Укажите Имя");
            if (string.IsNullOrWhiteSpace(((dynamic)DataContext).Заметка.Отчество))
                errors.AppendLine("Укажите Отчество");
            if (string.IsNullOrWhiteSpace(((dynamic)DataContext).Заметка.Заметка1))
                errors.AppendLine("Укажите Зааметку");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (((dynamic)DataContext).Заметка.ID_Заметка == 0)
                govorilegkoEntities.GetContext().Заметка.Add(((dynamic)DataContext).Заметка);
            if (((dynamic)DataContext).Клиент.ID_Клиента == 0)
                govorilegkoEntities.GetContext().Клиент.Add(((dynamic)DataContext).Клиент);
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
