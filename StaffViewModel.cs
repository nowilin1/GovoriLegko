using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GovoriLegko
{
    public class StaffViewModel
    {
        public Visibility DellBtnVisibility { get; set; }
        public Visibility AddBtnVisibility { get; set; }

        public StaffViewModel()
        {
            // Получение текущего пользователя и его роли
            Auto auto = new Auto();
            string userRole = auto.Access;

            // Установка видимости кнопок в зависимости от роли пользователя
            if (userRole == "Manager")
            {
                DellBtnVisibility = Visibility.Collapsed;
                AddBtnVisibility = Visibility.Collapsed;
            }
            else
            {
                DellBtnVisibility = Visibility.Visible;
                AddBtnVisibility = Visibility.Visible;
            }
        }
    }

}
