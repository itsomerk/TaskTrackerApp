using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace TaskTrackerApp
{
    public class TaskManager
    {
        string connectionString = "Data Source=tasks.db";

        public TaskManager()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                string tableQuery = @"
                CREATE TABLE IF NOT EXISTS Tasks (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT,
                    Description TEXT,
                    IsCompleted INTEGER,
                    DueDate TEXT
                );";

                var command = new SqliteCommand(tableQuery, connection);
                command.ExecuteNonQuery();
            }
        }

        public List<TaskItem> GetAllTasks()
        {
            var list = new List<TaskItem>();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = new SqliteCommand("SELECT * FROM Tasks", connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new TaskItem
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        IsCompleted = Convert.ToInt32(reader["IsCompleted"]) == 1,
                        DueDate = DateTime.Parse(reader["DueDate"].ToString())
                    });
                }
            }

            return list;
        }

        public void AddTask(TaskItem task)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = new SqliteCommand(
                    "INSERT INTO Tasks (Title, Description, IsCompleted, DueDate) VALUES (@title,@desc,@comp,@date)",
                    connection);

                command.Parameters.AddWithValue("@title", task.Title);
                command.Parameters.AddWithValue("@desc", task.Description);
                command.Parameters.AddWithValue("@comp", task.IsCompleted ? 1 : 0);
                command.Parameters.AddWithValue("@date", task.DueDate.ToString());

                command.ExecuteNonQuery();
            }
        }

        public void DeleteTask(int id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = new SqliteCommand("DELETE FROM Tasks WHERE Id=@id", connection);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }

        public void MarkAsCompleted(int id)
        {
            UpdateStatus(id, true);
        }

        public void MarkAsNotCompleted(int id)
        {
            UpdateStatus(id, false);
        }

        private void UpdateStatus(int id, bool status)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = new SqliteCommand(
                    "UPDATE Tasks SET IsCompleted=@status WHERE Id=@id", connection);

                command.Parameters.AddWithValue("@status", status ? 1 : 0);
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
        }
    }
}