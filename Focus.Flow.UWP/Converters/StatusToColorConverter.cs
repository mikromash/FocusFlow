using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using FocusFlow.Core.Models;

namespace Focus.Flow.UWP.Converters
{
    public partial class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is TaskStatus status)
            {
                return status switch
                {
                    TaskStatus.Planned => new SolidColorBrush(Colors.Gray),
                    TaskStatus.InProgress => new SolidColorBrush(Colors.Orange),
                    TaskStatus.Completed => new SolidColorBrush(Colors.Green),
                    _ => new SolidColorBrush(Colors.Black)
                };
            }

            return new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
