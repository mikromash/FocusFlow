using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Focus.Flow.UWP
{
    public sealed partial class App : Application
    {
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;

#if DEBUG
            this.DebugSettings.BindingFailed += (sender, args) =>
            {
                System.Diagnostics.Debug.WriteLine("XAML Binding Failed: " + args.Message);
            };

            this.UnhandledException += (sender, e) =>
            {
                System.Diagnostics.Debug.WriteLine("Unhandled Exception: " + e.Exception.Message);
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    // Тимчасово закоментуй, щоб не зупиняти дебаггер
                    // System.Diagnostics.Debugger.Break();
                }
            };
#endif
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            if (Window.Current.Content is not Frame rootFrame)
            {
                rootFrame = new Frame();
                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // TODO: Load state from previously suspended application
                }

                Window.Current.Content = rootFrame;
            }

            if (!e.PrelaunchActivated)
            {
                if (rootFrame.Content == null)
                {
                    rootFrame.Navigate(typeof(MainPage), e.Arguments);
                }
                Window.Current.Activate();
            }
        }

        private void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            var message = $"Failed to load Page: {e.SourcePageType.FullName}. Exception: {e.Exception?.Message}";
            System.Diagnostics.Debug.WriteLine(message);
            throw new Exception(message);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            // TODO: Save app state
            deferral.Complete();
        }
    }
}
