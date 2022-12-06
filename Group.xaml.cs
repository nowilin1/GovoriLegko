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
    public partial class Group : Page
    {
        public Group()
        {
            InitializeComponent();
            DGGroup.ItemsSource = govorilegkoEntities.GetContext().Группа.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditGroup((sender as Button).DataContext as Группа));
        }
    }
}
