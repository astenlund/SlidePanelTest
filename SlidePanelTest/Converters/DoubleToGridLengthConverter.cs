using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace SlidePanelTest.Converters
{
    /// <summary>
    /// Converts a double value to a <see cref="GridLength"/> object.
    /// </summary>
    public class DoubleToGridLengthConverter : MarkupExtension, IValueConverter
    {
        private static DoubleToGridLengthConverter _converter;

        /// <summary>
        /// Returns an object that is set as the value of the target property for this markup extension. 
        /// </summary>
        /// <returns>
        /// The object value to set on the property where the extension is applied. 
        /// </returns>
        /// <param name="serviceProvider">
        /// Object that can provide services for the markup extension.
        /// </param>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = new DoubleToGridLengthConverter());
        }

        /// <summary>
        /// Converts a double value to a <see cref="GridLength"/> object.
        /// </summary>
        /// <returns>
        /// A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">
        /// The value produced by the binding source.
        /// </param>
        /// <param name="targetType">
        /// The type of the binding target property.
        /// </param>
        /// <param name="parameter">
        /// The converter parameter to use.
        /// </param>
        /// <param name="culture">
        /// The culture to use in the converter.
        /// </param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return new GridLength(double.Parse(value.ToString(), culture));
        }

        /// <summary>
        /// Does nothing.
        /// </summary>
        /// <returns>
        /// The original value.
        /// </returns>
        /// <param name="value">
        /// The value that is produced by the binding target.
        /// </param>
        /// <param name="targetType">
        /// The type to convert to.
        /// </param>
        /// <param name="parameter">
        /// The converter parameter to use.
        /// </param><param name="culture">
        /// The culture to use in the converter.
        /// </param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
