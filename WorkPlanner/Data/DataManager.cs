using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using WorkPlanner.Models;

namespace WorkPlanner.Data
{
    /// <summary>
    /// Handles loading and saving tasks to JSON file.
    /// </summary>
    public static class DataManager
    {
        private static readonly string AppDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WorkPlanner");
        private static readonly string DataFile = Path.Combine(AppDataFolder, "tasks.json");

        /// <summary>
        /// Load tasks from JSON file. Returns empty list if file missing or on error.
        /// </summary>
        public static List<TaskItem> LoadTasks()
        {
            try
            {
                if (!Directory.Exists(AppDataFolder)) Directory.CreateDirectory(AppDataFolder);
                if (!File.Exists(DataFile)) return new List<TaskItem>();

                var json = File.ReadAllText(DataFile);
                var opts = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var tasks = JsonSerializer.Deserialize<List<TaskItem>>(json, opts);
                return tasks ?? new List<TaskItem>();
            }
            catch
            {
                return new List<TaskItem>();
            }
        }

        /// <summary>
        /// Save tasks to JSON file. Swallows exceptions (could be logged).
        /// </summary>
        public static void SaveTasks(List<TaskItem> tasks)
        {
            try
            {
                if (!Directory.Exists(AppDataFolder)) Directory.CreateDirectory(AppDataFolder);
                var opts = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(tasks, opts);
                File.WriteAllText(DataFile, json);
            }
            catch
            {
                // In production, log exception
            }
        }

        /// <summary>
        /// Simple search by title.
        /// </summary>
        public static List<TaskItem> SearchByTitle(List<TaskItem> tasks, string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return tasks;
            return tasks.Where(t => t.Title.Contains(query, StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        /// <summary>
        /// Filter by priority and/or status. Pass null to ignore filters.
        /// </summary>
        public static List<TaskItem> Filter(List<TaskItem> tasks, PriorityEnum? priority, StatusEnum? status)
        {
            var q = tasks.AsEnumerable();
            if (priority.HasValue) q = q.Where(t => t.Priority == priority.Value);
            if (status.HasValue) q = q.Where(t => t.Status == status.Value);
            return q.ToList();
        }
    }
}
