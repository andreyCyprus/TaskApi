using TaskApi.Models;

namespace TaskApi.Services
{
    public class TaskService
    {
        private readonly List<TaskItem> _tasks = new();
        private int _nextId = 1;

        public List<TaskItem> GetAll() => _tasks;

        public TaskItem Add(TaskItem task)
        {
            task.Id = _nextId++;
            _tasks.Add(task);
            return task;
        }

        public bool Delete(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return false;
            _tasks.Remove(task);
            return true;
        }

        public bool MarkCompleted(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null) return false;
            task.IsCompleted = true;
            return true;
        }
    }
}
