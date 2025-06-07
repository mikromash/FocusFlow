using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using FocusFlow.Core.Models;

namespace Focus.Flow.UWP.Converters
{
    public class PriorityToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is TaskPriority priority)
            {
                return priority switch
                {
                    TaskPriority.Critical => new SolidColorBrush(Colors.Red),
                    TaskPriority.High => new SolidColorBrush(Colors.Orange),
                    TaskPriority.Medium => new SolidColorBrush(Colors.YellowGreen),
                    TaskPriority.Low => new SolidColorBrush(Colors.Gray),
                    _ => new SolidColorBrush(Colors.Black),
                };
            }
            return new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
            => throw new NotImplementedException();
    }
}
