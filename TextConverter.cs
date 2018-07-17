using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace MathGame
{
    class TextConverter : IValueConverter
    {
            /// <summary>
            /// Converts bool to text for the question results located in all the game. tells the user whether they got it correct or incorrect
            /// </summary>
            /// <param name="value"></param>
            /// <param name="targetType"></param>
            /// <param name="parameter"></param>
            /// <param name="language"></param>
            /// <returns></returns>
            public object Convert(object value, Type targetType, object parameter, CultureInfo language)
            {
                return (value is bool && (bool)value) ? "Correct" : "Incorrect";
            }
            /// <summary>
            /// This implementation not used
            /// </summary>
            /// <param name="value"></param>
            /// <param name="targetType"></param>
            /// <param name="parameter"></param>
            /// <param name="language"></param>
            /// <returns></returns>
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
            {
                throw new NotImplementedException();
            }
       }
    
}
