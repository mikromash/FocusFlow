using FocusFlow.Core.Models;
using System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Focus.Flow.UWP
{
    public sealed partial class TimerPage : Page
    {
        private PomodoroTimer _pomodoroTimer;
        private readonly TimeSpan _interval = TimeSpan.FromMinutes(25);
        private const double CircleCircumference = 2 * Math.PI * 90; // 2πr, радіус 90 (половина 200 - StrokeThickness)

        public TimerPage()
        {
            this.InitializeComponent();

            _pomodoroTimer = new PomodoroTimer(_interval);
            _pomodoroTimer.Tick += PomodoroTimer_Tick;
            _pomodoroTimer.TimerFinished += PomodoroTimer_TimerFinished;

            TimerTextBlock.Text = "25:00";
            ProgressCircle.StrokeDashOffset = 0;
        }

        private async void PomodoroTimer_Tick(object? sender, TimeSpan e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                TimerTextBlock.Text = $"{e.Minutes:D2}:{e.Seconds:D2}";

                // progress: від 0 (початок) до 1 (кінець)
                double progress = (1 - e.TotalSeconds / _interval.TotalSeconds); // залишок часу
                double dashOffset = CircleCircumference * (1 - progress); // зростає з 0 до повного кола

                ProgressCircle.StrokeDashOffset = dashOffset;
            });
        }


        private async void PomodoroTimer_TimerFinished(object? sender, EventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                TimerTextBlock.Text = "00:00";
                ProgressCircle.StrokeDashOffset = CircleCircumference;

                PauseButton.IsEnabled = false;
                SkipButton.IsEnabled = false;
            });
        }

        private void StartTimer_Click(object sender, RoutedEventArgs e)
        {
            _pomodoroTimer.Start();
            PauseButton.IsEnabled = true;
            SkipButton.IsEnabled = true;
         
        }

        private void PauseTimer_Click(object sender, RoutedEventArgs e)
        {
            _pomodoroTimer.Pause();
        }

        private void SkipTimer_Click(object sender, RoutedEventArgs e)
        {
            _pomodoroTimer.Reset();
            TimerTextBlock.Text = $"{_interval.Minutes:D2}:00";
            ProgressCircle.StrokeDashOffset = 0;

            PauseButton.IsEnabled = false;
            SkipButton.IsEnabled = false;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }
    }
}
