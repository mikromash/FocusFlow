using FocusFlow.Core.Models;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Focus.Flow.UWP
{
    public sealed partial class TasksPage : Page
    {
        public ObservableCollection<AppTask> Tasks => TaskService.Instance.Tasks;

        public TasksPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
            TasksListView.ItemsSource = Tasks;
        }

        private void BackButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        private void TaskCheckBox_Changed(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (sender is CheckBox cb && cb.DataContext is AppTask task)
            {
                TaskService.Instance.SaveChanges();
            }
        }
    }
}
