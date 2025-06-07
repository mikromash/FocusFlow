using FocusFlow.Core.Models;
using System;
using Windows.UI.Xaml.Controls;

namespace Focus.Flow.UWP
{
    public sealed partial class AddTaskDialog : ContentDialog
    {
        public AppTask? NewTask { get; private set; }

        public AddTaskDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text))
            {
                args.Cancel = true; // не закривати, якщо заголовок пустий
                return;
            }

            // Отримуємо пріоритет із комбобокса, за замовчуванням Medium
            var selectedPriority = (PriorityComboBox.SelectedItem as ComboBoxItem)?.Tag?.ToString() ?? "Medium";
            if (!Enum.TryParse<TaskPriority>(selectedPriority, out var priorityEnum))
            {
                priorityEnum = TaskPriority.Medium;
            }

            NewTask = new AppTask
            {
                Id = Guid.NewGuid(),
                Title = TitleTextBox.Text.Trim(),
                Status = TaskStatus.Planned,
                Priority = priorityEnum,
                CreatedDate = DateTime.UtcNow
            };
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            NewTask = null;
        }
    }
}
