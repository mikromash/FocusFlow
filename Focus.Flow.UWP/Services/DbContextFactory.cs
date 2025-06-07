using FocusFlow.Core.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Windows.Storage;


namespace Focus.Flow.UWP.Services
{
    public static class DbContextFactory
    {
        public static FocusFlowDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<FocusFlowDbContext>();

            // Отримуємо шлях до локальної папки додатка UWP
            string localFolder = ApplicationData.Current.LocalFolder.Path;

            // Формуємо повний шлях до файлу БД у цій папці
            string dbPath = Path.Combine(localFolder, "focusflow.db");

            // Використовуємо SQLite з цим шляхом
            optionsBuilder.UseSqlite($"Data Source={dbPath}");

            return new FocusFlowDbContext(optionsBuilder.Options);
       
        }
    }
}
