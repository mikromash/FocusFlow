using FocusFlow.Core.Data;
using FocusFlow.Core.Models;
using Focus.Flow.UWP.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Focus.Flow.UWP
{
    public class TaskService
    {
        private static readonly Lazy<TaskService> _instance = new(() => new TaskService());
        public static TaskService Instance => _instance.Value;

        private readonly FocusFlowDbContext _dbContext;
        public ObservableCollection<AppTask> Tasks { get; private set; }

        private TaskService()
        {
            _dbContext = DbContextFactory.CreateDbContext();
            _dbContext.Database.EnsureCreated();

            // Ініціалізуємо та сортуємо при старті
            RefreshTasks();
        }

        private void RefreshTasks()
        {
            var sorted = _dbContext.Tasks
                .OrderByDescending(t => t.Priority)
                .ThenBy(t => t.CreatedDate)
                .ToList();

            Tasks = new ObservableCollection<AppTask>(sorted);
        }

        public void AddTask(AppTask task)
        {
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();
            RefreshTasks();    // перезаповнюємо колекцію в новому порядку
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
            RefreshTasks();    // оновлюємо порядок, якшо змінив пріоритет чи інші дані
        }
    }
}
