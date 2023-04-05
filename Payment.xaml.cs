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
    /// Логика взаимодействия для Payment.xaml
    /// </summary>
    public partial class Payment : Page
    {
        public Payment()
        {
            InitializeComponent();
            DataContext = new
            {
                Оплата = new Оплата(),
                Представитель = new Представитель()
            };
        }

        private void BtnPayment_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(((dynamic)DataContext).Оплата.Сумма))
                errors.AppendLine("Укажите Сумма");
            if (string.IsNullOrWhiteSpace(((dynamic)DataContext).Оплата.Номер_карты))
                errors.AppendLine("Укажите Номер карты");
            if (string.IsNullOrWhiteSpace(((dynamic)DataContext).Оплата.Номер_телефона))
                errors.AppendLine("Укажите Дата оплаты");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (((dynamic)DataContext).Оплата.ID_Оплата == 0)
                govorilegkoEntities.GetContext().Оплата.Add(((dynamic)DataContext).Оплата);
            if (((dynamic)DataContext).Представитель.ID_Представитель == 0)
                govorilegkoEntities.GetContext().Представитель.Add(((dynamic)DataContext).Представитель);
            try
            {
                ((dynamic)DataContext).Оплата.Дата_оплаты = DatePickerSup.SelectedDate;
                govorilegkoEntities.GetContext().SaveChanges();
                string Номер_карты = nomer.Text;
                decimal Сумма = decimal.Parse(summ.Text);
                StringBuilder receipt = new StringBuilder();
                receipt.AppendLine("ЧЕК ОПЛАТЫ");
                receipt.AppendLine("--------------------------");
                receipt.AppendLine($"Номер карты: {Номер_карты}");
                receipt.AppendLine($"Сумма оплаты: {Сумма:C}");
                receipt.AppendLine($"Дата оплаты: {DateTime.Now.ToString()}");
                receipt.AppendLine("--------------------------");
                receipt.AppendLine("Спасибо за оплату!!!");
                MessageBox.Show(receipt.ToString(), "Чек оплаты");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
