using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Windows;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GovoriLegko.Converters
    {
        public class AdminToVisibilityConverter : IValueConverter
        {
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                if (value == null || parameter == null)
                {
                    return Visibility.Collapsed;
                }

                string role = value.ToString();
                string requiredRole = parameter.ToString();

                if (role.Equals(requiredRole, StringComparison.InvariantCultureIgnoreCase))
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Collapsed;
                }
            }

            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
        }
    }
