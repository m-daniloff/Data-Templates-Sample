using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Data_Templates_Sample.Models;

namespace Data_Templates_Sample.ViewModels
{
    public class SettingsTemplateSelector : DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            DataTemplate dt = null;

            if (item is BooleanSetting)
                dt = App.Current.FindResource("boolTemplate") as DataTemplate;

            if (item is StringSetting)
                dt = App.Current.FindResource("stringTemplate") as DataTemplate;

            return dt;
        }
    }
}
