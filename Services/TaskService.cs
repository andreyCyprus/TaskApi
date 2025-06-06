using TaskApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;

namespace TaskApi.Services
{
    public class TaskService
    {
        private readonly string _filePath = "tasks.json";
        private readonly List<TaskItem> _tasks;
        private int _nextId;

        public TaskService()
        {
            _tasks = LoadTasks();
            _nextId = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;
        }

        public List<TaskItem> GetAll() => _tasks;

        public TaskItem Add(TaskItem task)
        {
            task.Id = _nextId++;
            _tasks.Add(task);
            SaveTasks();
            return task;
        }

        public bool Delete(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return false;
            _tasks.Remove(task);
            SaveTasks();
            return true;
        }

        public bool MarkCompleted(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return false;
            task.IsCompleted = true;
            SaveTasks();
            return true;
        }

        private List<TaskItem> LoadTasks()
        {
            if (!File.Exists(_filePath))
                return new List<TaskItem>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }

        private void SaveTasks()
        {
            var json = JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }
}
