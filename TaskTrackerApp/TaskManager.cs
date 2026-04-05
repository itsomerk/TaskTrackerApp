using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TaskTrackerApp
{
    public class TaskManager
    {
        string connectionString = "Server=DESKTOP-T8NAD5P\\SQLEXPRESS;Database=TaskTrackerDB;Trusted_Connection=True;";

        public void TestConnection()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                MessageBox.Show("SQL Connected!");
            }
        }

        public List<TaskItem> GetAllTasks()
        {
            List<TaskItem> tasks = new List<TaskItem>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Tasks";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    tasks.Add(new TaskItem
                    {
                        Id = (int)reader["Id"],
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        IsCompleted = (bool)reader["IsCompleted"],
                        DueDate = (DateTime)reader["DueDate"]
                    });
                }
            }

            return tasks;
        }

        public void AddTask(TaskItem task)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Tasks (Title, Description, IsCompleted, DueDate) VALUES (@title, @desc, @comp, @date)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@title", task.Title);
                cmd.Parameters.AddWithValue("@desc", task.Description);
                cmd.Parameters.AddWithValue("@comp", task.IsCompleted);
                cmd.Parameters.AddWithValue("@date", task.DueDate);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteTask(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM Tasks WHERE Id=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        public void MarkAsCompleted(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE Tasks SET IsCompleted = 1 WHERE Id=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }

        public void MarkAsNotCompleted(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE Tasks SET IsCompleted = 0 WHERE Id=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}