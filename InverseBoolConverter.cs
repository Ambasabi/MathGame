using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace MathGame
{
    public class InverseBoolConverter : IValueConverter
    {
        /// <summary>
        /// This method allows us to inversely compare a boolean variable to disable the start game button after it is clicked and the submit button is enabled
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (targetType != typeof(bool))
            {
                throw new InvalidOperationException("The target must be a boolean");
            }
            return !(bool)value;         
        }
        /// <summary>
        /// This method allows us to inversely compare a boolean variable to disable the start game button after it is clicked and the submit button is enabled
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Convert( value,  targetType,  parameter,  culture);
        }
    }
}
