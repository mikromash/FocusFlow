using FocusFlow.Core.Models;
using System;
using Windows.UI.Xaml.Data;

namespace Focus.Flow.UWP.Converters
{
    public class TaskStatusToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is TaskStatus status)
                return status == TaskStatus.Completed;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value is bool b && b)
                return TaskStatus.Completed;
            else
                return TaskStatus.InProgress;
        }
    }
}
