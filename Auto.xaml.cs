using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
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

using System.Security.Cryptography;

namespace GovoriLegko
{
    /// <summary>
    /// Логика взаимодействия для Auto.xaml
    /// </summary>
    /// 

    public partial class Auto : Page
    {

        public string Access;

        public Auto()
        {
            InitializeComponent();

        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {

            knopkiadmin myPage = new knopkiadmin();
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(login_Box.Text))
            {
                errors.AppendLine("Укажите логин");
            }
            if (string.IsNullOrWhiteSpace(pass_Box.Text))
            {
                errors.AppendLine("Укажите пароль");
            }
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Ошибка входа!");
                return;
            }
            string login = login_Box.Text;
            string password = pass_Box.Text;
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string admin = "Admin";
            string sotr = "Sotr";
            string manager = "Manager";
            string querystring = $"SELECT Login, Password, Access  FROM Users_company where Login ='{login}' and Password = '{password}'";
            SqlConnection SqlConnection = new SqlConnection(@"Data Source = LAPTOP-5H358NNC; Initial Catalog=govorilegko; Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand(querystring, SqlConnection);
            sqlDataAdapter.SelectCommand = sqlCommand;
            sqlDataAdapter.Fill(table);
            if (table.Rows.Count == 1)
            {
                MessageBox.Show("Вы успешно вошли!", "Успешно!", MessageBoxButton.OK);
                Access = table.Rows[0][2].ToString();
                if (Access == admin)
                {
                    
                    Manager.MainFrame.Navigate(new knopkiadmin());
                    SqlConnection.Close();
                }
                else if (Access == manager)
                {
                    Manager.MainFrame.Navigate(new knopkiadmin());
                    SqlConnection.Close();
                }
                else if (Access == sotr)
                {
                    Manager.MainFrame.Navigate(new knopkiadmin());
                    SqlConnection.Close();
                }
                
            }
            else
                MessageBox.Show("Логин или пароль неверный. Если Вы забыли пароль - обратитесь к администрации", "Аккаунт не обнаружен!", MessageBoxButton.OK);

        }

        private void pass_Box_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
