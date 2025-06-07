using FocusFlow.Core.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Focus.Flow.UWP
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void AddTask_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddTaskDialog();
            var result = await dialog.ShowAsync();

            if (dialog.NewTask != null)
            {
                TaskService.Instance.AddTask(dialog.NewTask);
                TaskService.Instance.SaveChanges();

                Frame.Navigate(typeof(TasksPage));
            }
        }



        private void OpenTasks_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TasksPage));
        }

        private void OpenTimer_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TimerPage));
        }
    }
}
