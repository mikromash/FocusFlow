#nullable enable

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;

namespace FocusFlow.UWP.ViewModels
{
    public class TimerViewModel : INotifyPropertyChanged
    {
        private readonly DispatcherTimer _timer;
        private TimeSpan _remainingTime;
        private bool _isRunning;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string TimerText => _remainingTime.ToString(@"mm\:ss");

        public TimerViewModel()
        {
            _remainingTime = TimeSpan.FromMinutes(25);
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += Timer_Tick!;
        }

        private void Timer_Tick(object? sender, object e)
        {
            if (_remainingTime.TotalSeconds > 0)
            {
                _remainingTime = _remainingTime.Subtract(TimeSpan.FromSeconds(1));
                OnPropertyChanged(nameof(TimerText));
            }
            else
            {
                Stop();
                
            }
        }

        public void Start()
        {
            if (!_isRunning)
            {
                _timer.Start();
                _isRunning = true;
            }
        }

        public void Pause()
        {
            _timer.Stop();
            _isRunning = false;
        }

        public void Skip()
        {
            Stop();
            _remainingTime = TimeSpan.Zero;
            OnPropertyChanged(nameof(TimerText));
        }

        public void Stop()
        {
            _timer.Stop();
            _isRunning = false;
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
