using System;
using System.Collections.Generic;
using System.Linq;
using WorkPlanner.Data;
using WorkPlanner.Models;

namespace WorkPlanner.Services
{
    /// <summary>
    /// Business logic for managing tasks in-memory and persisting via DataManager.
    /// </summary>
    public class TaskService
    {
        // 1. Datanın əsl saxlandığı list
        private List<TaskItem> tasks;

        public TaskService()
        {
            // Obyekt yaradılarkən datanı yükləyir
            tasks = DataManager.LoadTasks();
        }

        public List<TaskItem> GetAll() => tasks.OrderBy(t => t.Date).ThenBy(t => t.StartTime).ToList();

        public void Add(TaskItem task)
        {
            tasks.Add(task);
            DataManager.SaveTasks(tasks);
        }

        public void Update(TaskItem task)
        {
            var idx = tasks.FindIndex(t => t.Id == task.Id);
            if (idx >= 0)
            {
                tasks[idx] = task;
                DataManager.SaveTasks(tasks);
            }
        }

        public void Delete(Guid id)
        {
            tasks.RemoveAll(t => t.Id == id);
            DataManager.SaveTasks(tasks);
        }

        // 🚨 PROBLEMİ HƏLL EDƏN YENİ METOD
        /// <summary>
        /// Yaddaşda saxlanılan bütün tapşırıqları silir və dəyişikliyi yaddaşa yazır.
        /// </summary>
        public void ClearAll()
        {
            // TaskService-in istifadə etdiyi əsl listi təmizləyir
            tasks.Clear();
            // Dəyişikliyi DataManager vasitəsilə saxlayır ki, yaddaşda da silinsin
            DataManager.SaveTasks(tasks);
        }

        public List<TaskItem> GetTasksForWeek(DateTime weekStart)
        {
            var end = weekStart.Date.AddDays(7);
            return tasks.Where(t => t.Date.Date >= weekStart.Date && t.Date.Date < end).ToList();
        }

        // Bu metodlar artıq tasks listi üzərində işləyəcək
        public List<TaskItem> Search(string query) => DataManager.SearchByTitle(tasks, query);

        public List<TaskItem> Filter(PriorityEnum? priority, StatusEnum? status) => DataManager.Filter(tasks, priority, status);
    }
}