using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Todo.Models;

namespace Todo.Services
{
    public class TaskService : ITaskService
    {
        private readonly string tasksFilePath = Path.Combine(AppContext.BaseDirectory, "Tasks.json");

        public async Task SaveTaskAsync(Tasks task)
        {
            var tasks = await LoadTasksAsync();
            tasks.Add(task);
            await SaveTaskAsync(tasks);
        }

        public async Task<List<Tasks>> LoadTasksAsync()
        {
            if (!File.Exists(tasksFilePath))
            {
                return new List<Tasks>();
            }

            var json = await File.ReadAllTextAsync(tasksFilePath);
            return JsonSerializer.Deserialize<List<Tasks>>(json) ?? new List<Tasks>();
        }

        private async Task SaveTaskAsync(List<Tasks> tasks)
        {
            var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(tasksFilePath, json);
        }
    }
}

