using System;
using System.Windows.Data;
using DevExpress.Xpf.Docking;

namespace Example2 {
    public class Converter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            BaseLayoutItem item = value as BaseLayoutItem;
            MainViewModel model = parameter as MainViewModel;
            return value.ToString(); ;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            string name = value.ToString();
            MainViewModel model = parameter as MainViewModel;
            return name;
        }
    }
}